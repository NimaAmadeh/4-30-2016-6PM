using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LabAuto.Controllers
{
    [RoutePrefix("api")]
    public class TeacherController : ApiController
    {
        [Route("Teacher", Name = "GetTeachers")]
        [HttpGet]
        public IHttpActionResult GetTeachers()
        {
            Repository.TeacherRepository teacherRepo = new Repository.TeacherRepository();

            List<Models.Teacher> objList = teacherRepo.getTeachers();

            if (objList == null)
            {
                return NotFound();
            }
            return Ok(objList);
        }

        [Route("Teacher/{TeacherID}", Name = "GetTeacherByID")]
        //[Route("Teacher/{TeacherID}/{phone}", Name = "GetTeacherByID")]
        [HttpGet]
        //public IHttpActionResult GetTeacher(int TeacherID, int phone)
        public IHttpActionResult GetTeacher(int TeacherID)
        {
            Repository.TeacherRepository teacherRepo = new Repository.TeacherRepository();

            Models.Teacher objList = teacherRepo.getTeacher(TeacherID);

            if (objList == null)
            {
                return NotFound();
            }
            return Ok(objList);
        }


        //Delete Method
        [Route("Teacher/{TeacherID}", Name = "DeleteTeacherByID")]
        [HttpDelete]
        public IHttpActionResult DeleteTeacher(int TeacherID)
        {
            Repository.TeacherRepository teacherRepo = new Repository.TeacherRepository();
            teacherRepo.Delete(TeacherID);
            return Ok();
        }


        //Put Method*******

        [Route("Teacher/{TeacherID}", Name = "PutTeacherByID")]
        [HttpPut]
        public void Put(int TeacherID, LabAuto.Models.Teacher objTeacher)
        {
            Repository.TeacherRepository teacherRepo = new Repository.TeacherRepository();
            teacherRepo.Update(TeacherID, objTeacher.TeacherFirstname, objTeacher.TeacherLastname, objTeacher.TeacherEmail, objTeacher.TeacherPhonenum, objTeacher.TeacherTPnumber);
        }

        //Post Method********

        [Route("Teacher")]
        [HttpPost]
        public void Post(LabAuto.Models.Teacher objTeacher)
        {
            Repository.TeacherRepository teacherRepo = new Repository.TeacherRepository();
            teacherRepo.Insert(objTeacher.TeacherID, objTeacher.TeacherFirstname, objTeacher.TeacherLastname, objTeacher.TeacherEmail, objTeacher.TeacherPhonenum, objTeacher.TeacherTPnumber);
        }


        //Serach Method
        [Route("Teacher/search/{tp}", Name = "TeacherSearchOptions")]
        [HttpGet]
        public IHttpActionResult GetTeacher(String tp)
        {
            Repository.TeacherRepository teacherRepo = new Repository.TeacherRepository();

            Models.Teacher objtpnumber = teacherRepo.getTeachersTP(tp);

            if (objtpnumber == null)
            {
                return NotFound();
            }

            Repository.TeacherRepository searchRepo = new Repository.TeacherRepository();
            return Ok(objtpnumber);
        }


        //Login Method
        [Route("Teacher/login/{tp}", Name = "TeacherLoginOptions")]
        [HttpGet]
        public IHttpActionResult getTeacherslogin(String tp)
        {
            Repository.TeacherRepository teacherRepo = new Repository.TeacherRepository();
            Models.Teacher objtpnumber = teacherRepo.getTeacherslogintp(tp);

            if (objtpnumber == null)
            {
                return NotFound();
            }

            Repository.TeacherRepository searchRepo = new Repository.TeacherRepository();
            return Ok(objtpnumber);

        }

    }
}










