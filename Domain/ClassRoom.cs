using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ClassRoom
    {
        public int ClassRoomId { get; set; }

        public string ClassRoomName { get; set; }
        
        public int MasterAcademicYearId { get; set; }

        public string? Description { get; set; }

        public List<Student> Students { get; set; }

        public List<Subject> Subjects { get; set; }

        public ClassRoom()
        {
            Students = new List<Student>();
            Subjects = new List<Subject>();
        }
    }
}