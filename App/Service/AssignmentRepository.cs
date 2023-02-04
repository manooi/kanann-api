using App.Model;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace App.Service;

public class AssignmentRepository : IAssignmentRepository
{
    private readonly KananContext _context;

    public AssignmentRepository(KananContext _ctx)
    {
        _context = _ctx;
    }

    public IEnumerable<GetAssignmentResponse> GetAssignment(GetAssignmentQuery req)
    {
        var assignments = _context.Assignments.Where(a =>
            a.AcademicYearId == req.AcademicYearId && a.Subject.SubjectCode == req.SubjectCode);

        if (req.AssignmentId != null)
        {
            assignments = assignments.Where(a => a.AssignmentId == req.AssignmentId);
        }

        var assignedClassRooms = assignments.Join(_context.AssignmentMappings, a => a.AssignmentId,
                am => am.AssignmentId,
                (a, am) => new AssignedClassRoom()
                {
                    AssignmentId = a.AssignmentId,
                    ClassRoomId = am.ClassRoomId,
                    ClassRoomName = am.ClassRoom.ClassRoomName
                })
            .ToList();

        var result = new List<GetAssignmentResponse>() { };

        foreach (var assignment in assignments)
        {
            result.Add(new GetAssignmentResponse()
            {
                AssignmentId = assignment.AssignmentId,
                AssignmentName = assignment.AssignmentName,
                SubjectId = assignment.SubjectId,
                AcademicYearId = assignment.AssignmentId,
                TotalScore = assignment.TotalScore,
                AssignedClassRooms = assignedClassRooms.Where(c => c.AssignmentId == assignment.AssignmentId).ToList()
            });
        }

        return result;
    }

    public void CreateAssignment(CreateAssignmentRequest req)
    {
        using var transaction = _context.Database.BeginTransaction();
        try
        {
            #region Add record in Assignment table

            var subject = _context.Subjects.FirstOrDefault(s => s.SubjectCode == req.SubjectCode);
            var newAssignment = new Assignment()
            {
                AssignmentName = req.AssignmentName,
                SubjectId = subject.SubjectId,
                AcademicYearId = req.AcademicYearId,
                TotalScore = req.TotalScore
            };

            _context.Assignments.Add(newAssignment);
            _context.SaveChanges();

            #endregion

            #region Add record in AssignmentMapping table

            var classRoomIds = req.AssignedClassRooms;
            var assignmentMappings = new List<AssignmentMapping>();

            foreach (var classRoomId in classRoomIds)
            {
                assignmentMappings.Add(new AssignmentMapping()
                {
                    AssignmentId = newAssignment.AssignmentId,
                    ClassRoomId = classRoomId,
                    AssignedDate = DateTime.UtcNow,
                    DeadlineDate = null
                });
            }

            _context.AssignmentMappings.AddRange(assignmentMappings);
            _context.SaveChanges();

            #endregion

            #region Add record in Transaction Assignment table

            // Get all students in assigned classrooms
            var studentIdDict = new List<Dictionary<string, int>>();

            int idx = 0;
            foreach (var classRoomId in classRoomIds)
            {
                var studentsInCurrentClassRoom = _context.Students
                    .Where(s => s.ClassRoom.ClassRoomId == classRoomId)
                    .Select(s => new { StudentId = s.StudentId })
                    .ToList();

                if (studentsInCurrentClassRoom.Count == 0)
                {
                    throw new Exception("No student in the classroom");
                }

                studentIdDict.AddRange(studentsInCurrentClassRoom.Select(student => new Dictionary<string, int>()
                {
                    { student.StudentId, assignmentMappings[idx].AssignmentMappingId }
                }));
                idx++;
            }

            // Prepare transaction
            var newTransactions = new List<TransactionAssignment>();
            foreach (var studentId in studentIdDict)
            {
                newTransactions.Add(new TransactionAssignment()
                {
                    AssignmentMappingId = studentId.Values.FirstOrDefault(),
                    StudentId = studentId.Keys.FirstOrDefault(),
                    Score = 0
                });
            }

            _context.TransactionAssignment.AddRange(newTransactions);
            _context.SaveChanges();

            #endregion

            transaction.Commit();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public void DeleteAsisgment(int assignmentId)
    {
        var assignmentTobeDeleted = new Assignment() { AssignmentId = assignmentId };
        _context.Assignments.Remove(assignmentTobeDeleted);
        _context.SaveChanges();
    }

    public void UpdateAssignmentById(int assignmentId, UpdateAssignmentRequest req)
    {
        var assignment = _context.Assignments.Find(assignmentId);

        if (assignment != null)
        {
            assignment.AssignmentName = req.AssignmentName;
            assignment.TotalScore = req.TotalScore;
        }
        else
        {
            throw new Exception("AssignmentId not found");
        }
        
        _context.SaveChanges();
    }

    public GetScoringResponse GetScoring(GetTransactionAssignmentQuery req)
    {
        // Get assignment with subjectId and academicYearId
        var assignments = _context.Assignments
            .Where(a => a.Subject.SubjectCode.Equals(req.SubjectCode) && a.AcademicYearId == req.AcademicYearId)
            .ToList();

        var assignmentMappings =
            _context.AssignmentMappings
                .Where(am => assignments.Select(a => a.AssignmentId).Contains(am.AssignmentId))
                .Where(am => am.ClassRoomId == req.ClassRoomId)
                .Include(am => am.ClassRoom)
                .ToList();

        var subject = _context.Subjects.FirstOrDefault(s => s.SubjectCode == req.SubjectCode);

        var result = new GetScoringResponse()
        {
            AcademicYearId = req.AcademicYearId,
            AcademicYearName = _context.MasterAcademicYears.FirstOrDefault(a => a.AcademicYearId == req.AcademicYearId)
                .AcademicYearName,
            SubjectCode = subject.SubjectCode,
            SubjectName = subject.SubjectName,
            ClassRoomId = req.ClassRoomId,
            ClassRoomName = _context.ClassRooms.FirstOrDefault(c => c.ClassRoomId == req.ClassRoomId).ClassRoomName,
            AssignmentHeaders = new List<AssignmentHeader>()
        };

        foreach (var assignmentMapping in assignmentMappings)
        {
            result.AssignmentHeaders.Add(new AssignmentHeader()
            {
                AssignmentMappingId = assignmentMapping.AssignmentMappingId,
                AssignmentId = assignmentMapping.AssignmentId,
                AssignmentName = assignmentMapping.Assignment.AssignmentName,
                TotalScore = assignmentMapping.Assignment.TotalScore,
                Scores = _context.TransactionAssignment
                    .Where(ta => ta.AssignmentMappingId == assignmentMapping.AssignmentMappingId)
                    .Select(ta => new AssignmentScore()
                    {
                        AssignmentMappingId = ta.AssignmentMappingId,
                        StudentId = ta.StudentId,
                        Sequence = ta.Student.Sequence,
                        FirstName = ta.Student.FirstName,
                        LastName = ta.Student.LastName,
                        Score = ta.Score
                    })
                    .OrderBy(a => a.AssignmentMappingId)
                    .ThenBy(a => a.Sequence)
                    .ToList()
            });
        }

        return result;
    }

    public void UpdateScoring(UpdateScoringRequest req)
    {
        var updatedScore = req.Scores.Select(s => new TransactionAssignment()
        {
            AssignmentMappingId = s.AssignmentMappingId,
            StudentId = s.StudentId,
            Score = s.Score
        });

        _context.TransactionAssignment.UpdateRange(updatedScore);
        _context.ChangeTracker.DetectChanges();
        _context.SaveChanges();
    }
}