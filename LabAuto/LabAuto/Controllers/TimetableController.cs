using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LabAuto.Controllers
{

    [RoutePrefix("api")]
    [EnableCorsAttribute("http://localhost:60587", "*", "*")]
    public class TimetableController : ApiController
    {
        //Get Today Timetables only
        [Route("Timetables/today", Name = "GettodayTimetables")]
        [HttpGet]
        public IHttpActionResult GetTimetables()
        {
            Repository.TimetableRepository timetableRepo = new Repository.TimetableRepository();


            List<Models.Timetable> objList = timetableRepo.getTodayTimetables();
            if (objList == null)
            {
                return NotFound();
            }
            return Ok(objList);

        }

        //Get Timetable By LABID
        //[Route("Timetable/{LabID}", Name = "GetTimetablesbyLabID")]
        //[HttpGet]
        //public IHttpActionResult GetTimetables( int LabID)
        //{
        //    Repository.TimetableRepository timetableRepo = new Repository.TimetableRepository();

        //    Models.Timetable objList = timetableRepo.getTimetable(LabID);
                        
        //    if (objList == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(objList);

        //}


        //Get Method
        [Route("Timetable/{LabID}", Name = "GetTimetableByID")]
        [HttpGet]
        public IHttpActionResult GetTimetable(int LabID)
        {
            Repository.TimetableRepository timetableRepo = new Repository.TimetableRepository();

            Models.Timetable objList = timetableRepo.getTimetable(LabID);

            if (objList == null)
            {
                return NotFound();
            }
            return Ok(objList);

        }

        //Delete Method
        [Route("Timetable/{TimetableID}", Name = "DeleteTimetableByID")]
        [HttpDelete]
        public IHttpActionResult DeleteTimetable(int TimetableID)
        {
            Repository.TimetableRepository timetableRepo = new Repository.TimetableRepository();
            timetableRepo.Delete(TimetableID);
            return Ok();
        }

        //Put Method
        [Route("Timetable/{TimetableID}", Name = "PutTimetableByID")]
        [HttpPut]
        public void Put(int TimetableID, LabAuto.Models.Timetable objTimetable)
        {
            Repository.TimetableRepository timetableRepo = new Repository.TimetableRepository();
            timetableRepo.Update(objTimetable.Date, objTimetable.Starttime, objTimetable.Finishtime, objTimetable.TimetableStatus, objTimetable.LabID, objTimetable.TeacherID, objTimetable.CourseID, objTimetable.TimetableID);

        }

        //Post Method
        [Route("Timetable")]
        [HttpPost]
        public HttpResponseMessage Post(LabAuto.Models.Timetable objTimetable)
        {
            //For Returning somthing should be function the Must use Bool
            Repository.TimetableRepository timetableRepo = new Repository.TimetableRepository();
            bool registerResult = timetableRepo.RegisterTimeTable(objTimetable.Date, objTimetable.Starttime, objTimetable.Finishtime, objTimetable.TimetableStatus, objTimetable.LabID, objTimetable.TeacherID, objTimetable.CourseID, objTimetable.TimetableID);

            HttpResponseMessage message;

            if (registerResult == false)
            {
                message = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else {
                message = Request.CreateResponse(HttpStatusCode.Created);
            }
            return message;
        }

        //Serach Timetable By Lab Id Option

        //[Route("Timetable/show/{id}", Name = "TimetableSearchOptions")]
        //[HttpGet]
        //public IHttpActionResult GetTimetableByID(int LabID)
        //{
        //    Repository.TimetableRepository timetableRepobyid = new Repository.TimetableRepository();

        //    Models.Timetable objList = timetableRepobyid.getTimetablebyid(LabID);

        //    if (objList == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(objList);
        //}
    }

}

