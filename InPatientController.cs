using DataLib;
using HospitalDal;
using SampleWinApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using static HospitalDal.DataComponent;

namespace SampleWinApp.Controllers
{
    public class InPatientController : ApiController
    {
        static IDataComponent com = DataFactory.CreateComponent();
        [HttpGet]
        public List<InPatientHos> GetInPatientHos()
        {
            var data = com.GetAllInPatients();
            var patList = data.Select((pro) => new InPatientHos
            {
                InPatientID = pro.InPatientID,
                PatientName = pro.PatientName,
                Sex = pro.Sex,
                Age = pro.Age,
                Diseses = pro.Diseses,
                Address = pro.Address,
                MobileNo = pro.MobileNo,
                DateofAdmit = pro.DateofAdmit,
                DateofDischarge = pro.DateofDischarge,
                EmailID = pro.EmailID,
                DischargeSummary = pro.DischargeSummary,
                TotalBill = pro.TotalBill

            }).ToList();
            return patList;
        }
        private InPatientHos Convert(InPatient rec)
        {
            return new InPatientHos
            {
                InPatientID = rec.InPatientID,
                PatientName = rec.PatientName,
                Sex = rec.Sex,
                Age = rec.Age,
                Diseses = rec.Diseses,
                Address = rec.Address,
                MobileNo = rec.MobileNo,
                DateofAdmit = rec.DateofAdmit,
                DateofDischarge = rec.DateofDischarge,
                EmailID = rec.EmailID,
                DischargeSummary = rec.DischargeSummary,
                TotalBill = rec.TotalBill,
               // Bills = rec.Bills
            };
        }
        private InPatient Convert(InPatientHos rec)
        {
            var pro = new InPatient
            {
                InPatientID = rec.InPatientID,
                PatientName = rec.PatientName,
                Sex = rec.Sex,
                Age = rec.Age,
                Diseses = rec.Diseses,
                Address = rec.Address,
                MobileNo = rec.MobileNo,
                DateofAdmit = rec.DateofAdmit,
                DateofDischarge = rec.DateofDischarge,
                EmailID = rec.EmailID,
                DischargeSummary = rec.DischargeSummary,
                TotalBill = rec.TotalBill,
               // Bills = rec.Bills
            };
            return pro;
        }
        [HttpPost]
        public bool AddInPatient(InPatientHos pro)
        {
            var rec = Convert(pro);
            com.AddInPatient(rec);
            return true;
        }

        [HttpPut]
        public bool UpdateInPatient(InPatientHos pro)
        {
            var rec = Convert(pro);
            com.UpdateInPatient(rec);
            return true;
        }
       
    }
}

