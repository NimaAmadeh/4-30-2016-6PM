using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabAuto.Repository
{
    public class DeviceRepository
    {
        UniversityResursesEntities xEntity = new UniversityResursesEntities();



        public void Insert(int DeviceID, int labID, string DeviceName)
        {
            //New Object
            Device objNewDevice = new Device();

            //Assign function input parameters to new object
            objNewDevice.DeviceID = DeviceID;
            objNewDevice.labID = labID;
            objNewDevice.DeviceName = DeviceName;


            //Add new object to entity
            xEntity.Devices.Add(objNewDevice);

            //Entity save chnages to database
            xEntity.SaveChanges();

        }

        //for update should take id also

        public void Update(int DeviceID, int labID, String DeviceName)
        {
            //Get object from database
            Device objNewDevice = (from x in xEntity.Devices where x.DeviceID == DeviceID select x).FirstOrDefault();

            //Add new object to entity
            xEntity.Devices.Attach(objNewDevice);

            //Assign function input parameters to new object

            objNewDevice.DeviceID = DeviceID;
            objNewDevice.labID = labID;
            objNewDevice.DeviceName = DeviceName;


            //Entity save chnages to database
            xEntity.SaveChanges();
        }

        public void Delete(int deviceID)
        {
            //Get Device from database
            Device objNewDevice = (from x in xEntity.Devices where x.DeviceID == deviceID select x).First();

            //Add New object to entity
            xEntity.Devices.Attach(objNewDevice);
            xEntity.Devices.Remove(objNewDevice);
            xEntity.SaveChanges();

        }

        public Models.Device getDevice(int deviceID)
        {
            Models.Device objDevice = (from x in xEntity.Devices where x.DeviceID == deviceID select new Models.Device { DeviceID = x.DeviceID, labID = x.labID, DeviceName = x.DeviceName }).FirstOrDefault();
            return objDevice;
        }



        public List<Models.Device> getDevices()
        {
            List<Models.Device> objDevices = (from x in xEntity.Devices select new Models.Device { DeviceID = x.DeviceID, labID = x.labID, DeviceName = x.DeviceName }).ToList();
            return objDevices;
        }

        public List<Device> getDevices(int labID)
        { 

            List<Device> objDevices = (from x in xEntity.Devices where x.labID == labID select x).ToList();
            return objDevices;

            }
        }
}
