using DataLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWinApp.Models
{
    public class InPatientHos
    {
        public int InPatientID { get; set; }
        public string PatientName { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string Diseses { get; set; }
        public string Address { get; set; }
        public decimal MobileNo { get; set; }
        public System.DateTime DateofAdmit { get; set; }
        public Nullable<System.DateTime> DateofDischarge { get; set; }
        public string DischargeSummary { get; set; }
        public Nullable<decimal> TotalBill { get; set; }
        public string EmailID { get; set; }
       // public virtual ICollection<Bill> Bills { get; set; }
    }
    public class OutPatientHos
    {
        public short OutPatientID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        public string Diseses { get; set; }
        public string Conserted_Doctor { get; set; }
        public decimal Bill_Amount { get; set; }
        public string Summary { get; set; }
    }
    public class BillHos
    {
        public Nullable<int> InPatientID { get; set; }
        public string PatientName { get; set; }
        public string Sex { get; set; }
        public Nullable<int> Age { get; set; }
        public int Sl_NO_ { get; set; }
        public System.DateTime Date { get; set; }
        public string Discription { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }

      //  public virtual InPatient InPatient { get; set; }
    }
    public class StaffHos
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
       // public string Designation { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public decimal Mobile { get; set; }
        public string Email_ID { get; set; }
    }
}

