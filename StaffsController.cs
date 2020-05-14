using DataLib;
using HospitalDal;
using SampleWinApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static HospitalDal.DataComponent;

namespace SampleWinApp.Controllers
{
    public class StaffsController : ApiController
    {
        static IDataComponent staff = DataFactory.CreateComponent();
        [HttpGet]
        public List<StaffHos> GetStaffHos()
        {
            var data = staff.GetAllStaff();
            var staffList = data.Select((s) => new StaffHos
            {
                ID = s.ID,
                Name = s.Name,
                Sex = s.Sex,
                Age = s.Age,
               // Designation = s.Designation,
                Department = s.Department,
                Address = s.Address,
                Mobile = s.Mobile,
                Email_ID = s.Email_ID,

            }).ToList();
            return staffList;
        }
        private StaffHos Convert(Staff rec)
        {
            return new StaffHos
            {
                ID = rec.ID,
                Name = rec.Name,
                Sex = rec.Sex,
                Age = rec.Age,
               // Designation = rec.Designation,
                Department = rec.Department,
                Address = rec.Address,
                Mobile = rec.Mobile,
                Email_ID = rec.Email_ID
            };
        }
        private Staff Convert(StaffHos pro)
        {
            var rec = new Staff
            {
                ID = pro.ID,
                Name = pro.Name,
                Sex = pro.Sex,
                Age = pro.Age,
               // Designation = pro.Designation,
                Department = pro.Department,
                Address = pro.Address,
                Mobile = pro.Mobile,
                Email_ID = pro.Email_ID,
            };
            return rec;
        }
        [HttpPost]
        public bool AddStaff(StaffHos sat)
        {
            var rec = Convert(sat);
            staff.AddStaff(rec);
            return true;
        }
        //public bool DeleteStaff(string ID)
        //{
        //    var satID = int.Parse(ID);
        //    return true;
        //}
        [HttpPut]
        public bool UpdateStaff(StaffHos sat)
        {
            var res = Convert(sat);
            staff.UpdateStaff(res);
            return true;
        }
    }
}
