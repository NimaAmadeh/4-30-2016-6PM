using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LabAuto.Controllers
{
    [RoutePrefix("api")]
    public class CourseController : ApiController
    {
        [Route("Course", Name = "GetCourses")]
        [HttpGet]
        public IHttpActionResult GetCourses()
        {
            Repository.CourseRepository courseRepo = new Repository.CourseRepository();

            List<Models.Course> objList = courseRepo.getCourses();

            if (objList == null)
            {
                return NotFound();
            }
            return Ok(objList);

        }

        [Route("Course/{CourseID}", Name = "GetCourseByID")]
        [HttpGet]
        public IHttpActionResult GetCourse(int CourseID)
        {
            Repository.CourseRepository courseRepo = new Repository.CourseRepository();

            Models.Course objList = courseRepo.getCourse(CourseID);

            if (objList == null)
            {
                return NotFound();
            }
            return Ok(objList);

        }

        //Delete Method*****

        [Route("Course/{CourseID}", Name = "DeleteCourseByID")]
        [HttpDelete]

        public IHttpActionResult DeleteCourse(int CourseID)
        {
            Repository.CourseRepository courseRepo = new Repository.CourseRepository();
            courseRepo.Delete(CourseID);
            return Ok();
        }

        //Put Method********
        [Route("Course/{CourseID}", Name = "PutCourseByID")]
        [HttpPut]
        public void Put(int CourseID, LabAuto.Models.Course objCourse)
        {
            Repository.CourseRepository courseRepo = new Repository.CourseRepository();
            courseRepo.Update(CourseID, objCourse.CourseName, objCourse.CourseCode);
        }

        //Post Method
        [Route("Course")]
        [HttpPost]
        public void Post(LabAuto.Models.Course objCourse)
        {
            Repository.CourseRepository courseRepo = new Repository.CourseRepository();
            courseRepo.Insert(objCourse.CourseID, objCourse.CourseName, objCourse.CourseCode);

        }
    }
}