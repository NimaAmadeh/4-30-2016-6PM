using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabAuto.Models
{
    public class Attendance
    {
        public int AttendanceID { get; set; }

        public string AttendanceStatus { get; set; }

        public int TimetableID { get; set; }

        public TimeSpan EnteringTime { get; set; }

        public TimeSpan ExitingTime { get; set; }

    }

}




