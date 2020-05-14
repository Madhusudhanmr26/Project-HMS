using DataLib;
using HospitalDal;
using SampleWinApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static HospitalDal.DataComponent;

namespace SampleWinApp.Controllers
{
    public class OutPatientController : ApiController
    {
        static IDataComponent com = DataFactory.CreateComponent();
        [HttpGet]
        public List<OutPatientHos> GetOutPatients()
        {
            var data = com.GetAllOutPatient();
            var patList = data.Select((pro) => new OutPatientHos
            {
                OutPatientID = pro.OutPatientID,
                Name = pro.Name,
                Sex = pro.Sex,
                Age = pro.Age,
                Diseses = pro.Diseses,
                Address = pro.Address,
                Conserted_Doctor = pro.Conserted_Doctor,
                Bill_Amount = pro.Bill_Amount,
                Summary = pro.Summary

            }).ToList();
            return patList;
        }
        private OutPatientHos Convert(OutPatient rec)
        {
            return new OutPatientHos
            {
                OutPatientID = rec.OutPatientID,
                Name = rec.Name,
                Sex = rec.Sex,
                Age = rec.Age,
                Diseses = rec.Diseses,
                Address = rec.Address,
                Conserted_Doctor = rec.Conserted_Doctor,
                Bill_Amount = rec.Bill_Amount,
                Summary = rec.Summary
            };
        }
        private OutPatient Convert(OutPatientHos pat)
        {
            var rec = new OutPatient
            {
                OutPatientID = pat.OutPatientID,
                Name = pat.Name,
                Sex = pat.Sex,
                Age = pat.Age,
                Diseses = pat.Diseses,
                Address = pat.Address,
                Conserted_Doctor = pat.Conserted_Doctor,
                Bill_Amount = pat.Bill_Amount,
                Summary = pat.Summary
            };
            return rec;
        }
        [HttpPost]
        public bool AddOutPatient(OutPatientHos pro)
        {
            var rec = Convert(pro);
            com.AddOutPatient(rec);
            return true;
        }
        //public bool DeleteOutPatient(int OutPatientID)
        //{
        //    var del = int.Parse(OutPatientID);
        //    return true;
        //}
        [HttpPut]
        public bool UpdateOutPatient(OutPatientHos pro)
        {
            var rec = Convert(pro);
            com.UpdateOutPatient(rec);
            return true;
        }
       
    }
}



