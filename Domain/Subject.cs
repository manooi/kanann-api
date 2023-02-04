using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public int AcademicYearId { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public string StudyPlan { get; set; }
        public decimal? Credit { get; set; }

        public List<Teacher> Teachers { get; set; }
        public List<ClassRoom> ClassRooms { get; set; }

        public Subject()
        {
            Teachers = new List<Teacher>();
            ClassRooms = new List<ClassRoom>();
        }
    }
}