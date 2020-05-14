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
    public class BillController : ApiController
    {
        static IDataComponent bill = DataFactory.CreateComponent();
        
        [HttpGet]
        public List<BillHos> GetBillHos()
        {
            var data = bill.GetAllBill();
            var billList = data.Select((pro) => new BillHos
            {
                InPatientID = pro.InPatientID,
                PatientName = pro.PatientName,
                Sex = pro.Sex,
                Age = pro.Age,
                Date = pro.Date,
                Discription = pro.Discription,
                Amount = pro.Amount,
                Remarks = pro.Remarks

            }).ToList();
            return billList;
        }
        private BillHos Convert(Bill rec)
        {
            return new BillHos
            {
                InPatientID = rec.InPatientID,
                PatientName = rec.PatientName,
                Sex = rec.Sex,
                Age = rec.Age,
                Date = rec.Date,
                Discription = rec.Discription,
                Amount=rec.Amount,
                Remarks=rec.Remarks
            };
        }
        private Bill Convert(BillHos rec)
        {
            var pat = new Bill
            {
                InPatientID = rec.InPatientID,
                PatientName = rec.PatientName,
                Sex = rec.Sex,
                Age = rec.Age,
                Date = rec.Date,
                Discription = rec.Discription,
                Amount = rec.Amount,
                Remarks = rec.Remarks
            };
            return pat;
        }
        [HttpPost]
        public bool AddBill(BillHos pro)
        {
            var rec = Convert(pro);
            bill.AddBill(rec);
            return true;
        }
        [HttpPut]
        public bool UpdateBill(BillHos pro)
        {
            var rec = Convert(pro);
            bill.UpdateBill(rec);
            return true;
        }
    }

}
  