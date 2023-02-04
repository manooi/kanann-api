using App.Model;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace App.Service;

public class TransactionClassRepository : ITransactionClassRepository
{
    private readonly KananContext _context;

    public TransactionClassRepository(KananContext _ctx)
    {
        _context = _ctx;
    }


    public IEnumerable<TransactionClassDTO> GetTransactionClass(GetTransactionClassQuery query)
    {
        return _context.TransactionClasses
            .Where(c => c.AcademicYearId == query.AcademicYearId && c.Subject.SubjectCode == query.SubjectCode &&
                        c.ClassRoomId == query.ClassRoomId)
            .Select(c => new TransactionClassDTO()
            {
                TransactionClassId = c.TransactionClassId,
                AcademicYearName = c.AcademicYear.AcademicYearName,
                AcademicYearId = c.AcademicYearId,
                StartDate = c.StartDateTime.AddHours(7.00),
                ClassRoomName = c.ClassRoom.ClassRoomName,
                ClassWeight = c.ClassWeight
            })
            .OrderByDescending(c => c.StartDate);
    }

    public void AddTransaction(PostTransactionClass req)
    {
        var students = _context.Students.Where(s => s.ClassRoom.ClassRoomId == req.ClassRoomId).ToList();

        if (students.Count == 0)
        {
            throw new Exception("No students.");
        }

        var attendances = students.Select(s => new TransactionAttendance()
        {
            StudentId = s.StudentId,
            AttendTime = null,
            Remark = null,
            AttendanceStatusId = 4
        }).ToList();

        var subjectId = _context.Subjects.FirstOrDefault(s => s.SubjectCode == req.SubjectCode);

        var transaction = new TransactionClass()
        {
            AcademicYearId = req.AcademicYearId,
            SubjectId = subjectId.SubjectId,
            ClassRoomId = req.ClassRoomId,
            StartDateTime = req.StartDateTime ?? new DateTime(),
            EndDateTime = new DateTime(),
            Attendance = attendances,
            ClassWeight = req.ClassWeight
        };
        _context.TransactionClasses.Add(transaction);
        _context.SaveChanges();
    }

    public GetCheck GetCheck(int transactionClassId)
    {
        var subjectAndClassRoom = _context.TransactionClasses
            .FirstOrDefault(t => t.TransactionClassId == transactionClassId);

        var subject = _context.Subjects.FirstOrDefault(s => s.SubjectId == subjectAndClassRoom.SubjectId);
        var classRoom =
            _context.ClassRooms.Where(s => s.ClassRoomId == subjectAndClassRoom.ClassRoomId)
                .Select(s => new
                {
                    ClassRoomName = s.ClassRoomName,
                    ClassRoomId = s.ClassRoomId
                })
                .FirstOrDefault();

        var attendacePercentage =
            _context.AttendacePercentages
                .Where(ap =>
                    ap.SubjectId == subject.SubjectId && ap.ClassRoomId == classRoom.ClassRoomId &&
                    ap.AcademicYearId == subject.AcademicYearId)
                .ToList();

        var hash = attendacePercentage
            .ToDictionary(ap => ap.StudentId, ap => new { ap.GainedClassWeight, ap.TotalClassWeight });

        var result = _context.TransactionAttendances
            .Where(t => t.TransactionClassId == transactionClassId)
            .Include(t => t.Student)
            .OrderBy(t => t.Student.Sequence)
            .Select(t => new AttendanceCheckResult()
            {
                StudentId = t.StudentId,
                AttendTime = t.AttendTime,
                Remark = t.Remark,
                AttendanceStatusId = t.AttendanceStatusId,
                Student = t.Student,
                TransactionClassId = t.TransactionClassId,
                AttendanceStatus = t.AttendanceStatus,
                GainedClassWeight = hash[t.StudentId].GainedClassWeight,
                TotalClassWeight = hash[t.StudentId].TotalClassWeight
            })
            .ToList();

        return new GetCheck()
        {
            TransactionAttendance = result,
            SubjectCode = subject.SubjectCode,
            SubjectName = subject.SubjectName,
            ClassRoomName = classRoom.ClassRoomName,
            ClassDate = subjectAndClassRoom.StartDateTime
        };
    }

    public void UpdateAttendance(UpdateAttendance req)
    {
        var transactionAttendace =
            _context.TransactionAttendances
                .Where(t => t.TransactionClassId == req.TransactionClassId).ToList();

        foreach (var eachStudentAttendance in req.StudentAttendances)
        {
            var studentId = eachStudentAttendance.StudentId;
            var student = transactionAttendace.FirstOrDefault(t => t.StudentId == studentId);
            student.AttendTime = eachStudentAttendance.AttendTime;
            student.AttendanceStatusId = eachStudentAttendance.AttendanceStatusId;
        }

        _context.SaveChanges();
    }

    public void RemoveTransaction(int transactionClassId)
    {
        var transactionToBeDeleted = new TransactionClass() { TransactionClassId = transactionClassId };
        _context.TransactionClasses.Remove(transactionToBeDeleted);
        _context.SaveChanges();
    }
}