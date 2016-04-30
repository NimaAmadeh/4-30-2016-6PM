using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabAuto.Models
{
    public class Timetable
    {
        public int TimetableID { get; set; }

        public int TeacherID { get; set; }

        public int CourseID { get; set; }

        public int LabID { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan Starttime { get; set; }

        public TimeSpan Finishtime { get; set; }

        public bool TimetableStatus { get; set; }

        public String TeacherFirstname { get; set; }
        public String TeacherLastname { get; set; }

        public String LabLocation { get; set; }

        public String CourseName { get; set; }

        public class TimetableByLabIDOption
        {
            public int LabID { get; set; }
            public int TimetableID { get; set; }

            public int TeacherID { get; set; }

            public int CourseID { get; set; }
            
            public DateTime Date { get; set; }

            public TimeSpan Starttime { get; set; }

            public TimeSpan Finishtime { get; set; }

            public bool TimetableStatus { get; set; }

        }

    }
}