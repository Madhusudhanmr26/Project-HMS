using DataLib;
using HospitalDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HospitalDal.DataComponent;

namespace HospitalBall
{
    public interface IHospitalComponent
    {
        void AddInPatient(InPatient patient);
        void UpdateInPatient(InPatient patient);
        List<InPatient> GetAllInPatient();
        void AddOutPatient(OutPatient patient);
        void UpdateOutPatient(OutPatient patient);
        void DeleteOutPatient(int OutPatientID);
        void AddStaff(Staff staff);
        void UpdateStaff(Staff staff);
        void DeleteStaff(int ID);
        List<Staff> GetAllStaff();
        Staff LoginStaff(string name);
        void RegisterStaff(Staff staff);
        void AddBill(Bill bill);
        void UpdateBill(Bill bill);
    }
    public class HospitalComponent : IHospitalComponent
    {
        static IDataComponent pat = DataFactory.CreateComponent();
        public void AddBill(Bill bill)
        {
            pat.AddBill(bill);
        }
        public void AddInPatient(InPatient patient)
        {
            pat.AddInPatient(patient);
        }

        public void AddOutPatient(OutPatient patient)
        {
            pat.AddOutPatient(patient);
        }

        public void AddStaff(Staff staff)
        {
            pat.AddStaff(staff);
        }

        public void DeleteOutPatient(int OutPatientID)
        {
            pat.DeleteOutPatient(OutPatientID);
        }

        public void DeleteStaff(int ID)
        {
            pat.DeleteStaff(ID);

        }

        public List<InPatient> GetAllInPatient()
        {
            return pat.GetAllInPatient();
        }

        public List<Staff> GetAllStaff()
        {
            return pat.GetAllStaff();
        }

        public Staff LoginStaff(string name)
        {
            throw new NotImplementedException();
        }

        public void RegisterStaff(Staff staff)
        {
            pat.RegisterStaff(staff);
        }

        public void UpdateBill(Bill bill)
        {
            pat.UpdateBill(bill);
        }

        public void UpdateInPatient(InPatient patient)
        {
            pat.UpdateInPatient(patient);
        }

        public void UpdateOutPatient(OutPatient patient)
        {
            pat.UpdateOutPatient(patient);
        }

        public void UpdateStaff(Staff staff)
        {
            pat.UpdateStaff(staff);
        }
    }
}
