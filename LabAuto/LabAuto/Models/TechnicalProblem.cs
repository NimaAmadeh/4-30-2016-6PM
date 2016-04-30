using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabAuto.Models
{
    public class TechnicalProblem
    {
        public int TechnicalProblemID { get; set; }
        public string ProblemDescription { get; set; }
        public int TimetableID { get; set; }
        public bool ProblemStatus { get; set; }
    }
}