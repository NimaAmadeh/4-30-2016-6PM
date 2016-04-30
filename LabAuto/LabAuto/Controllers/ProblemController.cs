using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LabAuto.Controllers
{
    [RoutePrefix("api")]
    public class ProblemController : ApiController
    {
        [Route("Problem", Name = "getTechnicalProblems")]
        [HttpGet]
        public IHttpActionResult getTechnicalProblems()
        {
            Repository.TechnicalProblemRepository technicalproblemRepo = new Repository.TechnicalProblemRepository();

            List<Models.TechnicalProblem> objList = technicalproblemRepo.getTechnicalProblems();

            if (objList == null)
            {
                return NotFound();
            }
            return Ok(objList);
        }

        [Route("Problem/{TechnicalProblemID}", Name = "getTechnicalProblemByID")]
        [HttpGet]
        public IHttpActionResult getTechnicalProblem(int TechnicalProblemID)
        {
            Repository.TechnicalProblemRepository technicalproblemRepo = new Repository.TechnicalProblemRepository();

            Models.TechnicalProblem objList = technicalproblemRepo.getTechnicalProblem(TechnicalProblemID);

            if (objList == null)
            {
                return NotFound();
            }
            return Ok(objList);
        }



        [Route("Problem/{TechnicalProblemID}", Name = "DeleteTechnicalProblemByID")]
        [HttpDelete]
        public IHttpActionResult Delete(int TechnicalProblemID)
        {
            Repository.TechnicalProblemRepository technicalproblemRepo = new Repository.TechnicalProblemRepository();
            technicalproblemRepo.Delete(TechnicalProblemID);
            return Ok();
        }

       //Put Method
       [Route("Problem/{TechnicalProblemID}", Name = "PutTechnicalProblemByID")]
       [HttpPut]
       public void Put(int TechnicalProblemID, LabAuto.Models.TechnicalProblem objTechnicalProblem)
        {
            Repository.TechnicalProblemRepository technicalRepo = new Repository.TechnicalProblemRepository();
            technicalRepo.Update(TechnicalProblemID, objTechnicalProblem.ProblemDescription, objTechnicalProblem.ProblemStatus, objTechnicalProblem.TimetableID);

        }

        //Post Method
        [Route("Problem")]
        [HttpPost]
        public void Post(LabAuto.Models.TechnicalProblem objTechnicalProblem)
        {
            Repository.TechnicalProblemRepository technicalRepo = new Repository.TechnicalProblemRepository();
            technicalRepo.Insert(objTechnicalProblem.TechnicalProblemID, objTechnicalProblem.ProblemDescription, objTechnicalProblem.ProblemStatus, objTechnicalProblem.TimetableID);
        }


    }
}
