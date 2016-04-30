using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LabAuto.Controllers
{
    [RoutePrefix("api")]
    public class LabController : ApiController
    {
        [Route("Lab", Name = "getlabs")]
        [HttpGet]
        public IHttpActionResult getlabs()
        {

            Repository.LabRepository labRepo = new Repository.LabRepository();
            List<Models.Lab> objList = labRepo.getlabs();

            if (objList == null)
            {
                return NotFound();
            }
            return Ok(objList);

        }

        [Route("Lab/{LabID}", Name = "getlabByID")]
        [HttpGet]
        public IHttpActionResult Getlab(int LabID)
        {

            Repository.LabRepository labRepo = new Repository.LabRepository();
            Models.Lab objList = labRepo.getLab(LabID);

            if (objList == null)
            {
                return NotFound();
            }
            return Ok(objList);

        }

        [Route("Lab/{LabID}", Name = "DeleteLabByID")]
        [HttpDelete]
        public IHttpActionResult DeleteLab(int LabID)
        {
            Repository.LabRepository labRepo = new Repository.LabRepository();
            labRepo.Delete(LabID);
            return Ok();
        }

        //Put Method
        [Route("Lab/{LabID}", Name = "PutLabByID")]
        [HttpPut]
        public void Put(int labID, LabAuto.Models.Lab objLab)
        {
            Repository.LabRepository labRepo = new Repository.LabRepository();
            labRepo.Update(labID, objLab.LabLocation);

        }

        //Post Method
        [Route("Lab")]
        [HttpPost]
        public void Post(LabAuto.Models.Lab objLab)
        {
            Repository.LabRepository labRepo = new Repository.LabRepository();
            labRepo.Insert(objLab.LabID, objLab.LabLocation);

        }

    }
}


