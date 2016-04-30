using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabAuto.Repository
{
    public class TechnicalProblemRepository
    {
        UniversityResursesEntities xEntity = new UniversityResursesEntities();

        public void Insert(int TechnicalProblemID,string ProblemDescription, bool ProblemStatus, int TimetableID)
        {
            //New object
            TechnicalProblem objNewTechnicalProblem = new TechnicalProblem();
            //Assign fucntion input parameteres to new object

            objNewTechnicalProblem.ProblemDescription = ProblemDescription;
            objNewTechnicalProblem.ProblemStatus = ProblemStatus;
            objNewTechnicalProblem.TechnicalProblemID = TechnicalProblemID;
            objNewTechnicalProblem.TimetableID = TimetableID;

            //Add New Object to Entity
            xEntity.TechnicalProblems.Add(objNewTechnicalProblem);

            //Entity save changes to database
            xEntity.SaveChanges();

        }
        //for Update should take id also
        public void Update(int TechnicalProblemID, string ProblemDescription, bool ProblemStatus, int TimetableID)
        {
            //get Object from database
            TechnicalProblem objNewTechnicalProblem = (from x in xEntity.TechnicalProblems where x.TechnicalProblemID == TechnicalProblemID select x).FirstOrDefault();
            //Add new object to Entity
            xEntity.TechnicalProblems.Attach(objNewTechnicalProblem);

            //Assign function input parameters to new object
            objNewTechnicalProblem.ProblemDescription = ProblemDescription;
            objNewTechnicalProblem.ProblemStatus = ProblemStatus;
            objNewTechnicalProblem.TechnicalProblemID = TechnicalProblemID;
            objNewTechnicalProblem.TimetableID = TimetableID;
            //Entity save chnages to database
            xEntity.SaveChanges();
        }

        public void Delete(int TechnicalProblemID)
        {
            //Get object from database
            TechnicalProblem objNewTechnicalProblem = (from x in xEntity.TechnicalProblems where x.TechnicalProblemID == TechnicalProblemID select x).FirstOrDefault();
            //Add new object to Entity
            xEntity.TechnicalProblems.Attach(objNewTechnicalProblem);
            xEntity.TechnicalProblems.Remove(objNewTechnicalProblem);
            //Entity save chnages to database
            xEntity.SaveChanges();

        }
        public Models.TechnicalProblem getTechnicalProblem(int TechnicalProblemID)

        {
            Models.TechnicalProblem objTechnicalProblem = (from x in xEntity.TechnicalProblems where x.TechnicalProblemID == TechnicalProblemID select new Models.TechnicalProblem { TechnicalProblemID = x.TechnicalProblemID, ProblemDescription = x.ProblemDescription, ProblemStatus = x.ProblemStatus, TimetableID = x.TimetableID }).FirstOrDefault();
            return objTechnicalProblem;
        }
        public List<Models.TechnicalProblem> getTechnicalProblems()
        {
            List<Models.TechnicalProblem> objTechnicalProblems = (from x in xEntity.TechnicalProblems select new Models.TechnicalProblem { TechnicalProblemID = x.TechnicalProblemID, ProblemDescription = x.ProblemDescription, ProblemStatus = x.ProblemStatus, TimetableID = x.TimetableID }).ToList();
            return objTechnicalProblems;
        }
        public List<TechnicalProblem> getTechnicalProblems(string problemdescription)
        {
            List<TechnicalProblem> objTechnicalproblem = (from x in xEntity.TechnicalProblems where x.ProblemDescription == problemdescription select x).ToList();
            return objTechnicalproblem;
        }
    }
}