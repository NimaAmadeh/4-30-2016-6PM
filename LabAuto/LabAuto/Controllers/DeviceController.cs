using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LabAuto.Controllers
{
    [RoutePrefix("api")]
    public class DeviceController : ApiController
    {
        [Route("Device", Name = "GetDevices")]
        [HttpGet]
        public IHttpActionResult GetDevices()
        {
            Repository.DeviceRepository deviceRepo = new Repository.DeviceRepository();
            List<Models.Device> objList = deviceRepo.getDevices();

            if (objList == null)
            {
                return NotFound();
            }
            return Ok(objList);
        }


        [Route("Device/{DeviceID}", Name = "GetDeviceByID")]
        [HttpGet]
        public IHttpActionResult GetDevice(int DeviceID)
        {
            Repository.DeviceRepository deviceRepo = new Repository.DeviceRepository();
            Models.Device objList = deviceRepo.getDevice(DeviceID);

            if (objList == null)
            {
                return NotFound();
            }
            return Ok(objList);

        }

        [Route("Device/{DeviceID}", Name = "DeleteDeviceByID")]
        [HttpDelete]
        public IHttpActionResult DeleteDevice(int DeviceID)
        {
            Repository.DeviceRepository deviceRepo = new Repository.DeviceRepository();
            deviceRepo.Delete(DeviceID);
            return Ok();
        }


        //Put Method
        [Route("Device/{DeviceID}", Name = "PutDeviceByID")]
        [HttpPut]
        public void Put(int DeviceID, LabAuto.Models.Device objDevice)
        {
            Repository.DeviceRepository deviceRepo = new Repository.DeviceRepository();
            deviceRepo.Update(objDevice.DeviceID, objDevice.labID, objDevice.DeviceName);
        }


        //Post Method
        [Route("Device")]
        [HttpPost]
        public void Post(LabAuto.Models.Device objDevice)
        {
            Repository.DeviceRepository deviceRepo = new Repository.DeviceRepository();
            deviceRepo.Insert(objDevice.DeviceID, objDevice.labID, objDevice.DeviceName);

        }

    }
}



