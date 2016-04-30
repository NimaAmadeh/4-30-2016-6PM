using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabAuto.Models
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string TeacherFirstname { get; set; }
        public string TeacherLastname { get; set; }

        public string TeacherEmail { get; set; }

        public int TeacherPhonenum { get; set; }
        public string TeacherTPnumber { get; set; }
    }
    public class TeacherSearchOptions
    {
        public int TeacherID { get; set; }
        public string TeacherTPnumber { get; set; }
    }
    public class TeacherLoginOptions
    {
        public int TeacherID { get; set; }
        public string TeacherTPnumber { get; set; }

    }
}