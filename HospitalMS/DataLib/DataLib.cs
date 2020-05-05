using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLib;

namespace HospitalDal
{
    public interface IDataComponent
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

    public class DataComponent : IDataComponent
    {
        static HospitalAppEntities1 hos = new HospitalAppEntities1();
        public void AddBill(Bill bill)
        {
            hos.Bills.Add(bill);
            hos.SaveChanges();
        }

        public void AddInPatient(InPatient patient)
        {

            hos.InPatients.Add(patient);
            hos.SaveChanges();
        }

        public void AddOutPatient(OutPatient patient)
        {
            hos.OutPatients.Add(patient);
            hos.SaveChanges();
        }

        public void AddStaff(Staff staff)
        {
            hos.Staffs.Add(staff);
            hos.SaveChanges();
        }

        public void DeleteOutPatient(int OutPatientID)
        {
            try
            {
                var selected = hos.OutPatients.FirstOrDefault((a) => a.OutPatientID == OutPatientID);
                if (selected == null) throw new Exception("OutPatient not found to delete");
                hos.OutPatients.Remove(selected);
                hos.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteStaff(int ID)
        {
            throw new NotImplementedException();
        }
        public List<InPatient> GetAllInPatient()
        {
            return new HospitalAppEntities1().InPatients.ToList();
        }

        public List<Staff> GetAllStaff()
        {
            return new HospitalAppEntities1().Staffs.ToList();
        }

        public Staff LoginStaff(string name)
        {
            var selected = hos.Staffs.FirstOrDefault((u) => u.Name ==name);
            if (selected == null) throw new Exception("Login failed for the user");
            return selected;
        }

        public void RegisterStaff(Staff staff)
        {
            hos.Staffs.Add(staff);
            hos.SaveChanges();
        }

        public void UpdateBill(Bill bill)
        {
            var selected = hos.Bills.FirstOrDefault((e) => e.InPatientID ==bill.InPatientID);
            if (selected == null) throw new Exception("Patient not found to update");
            hos.SaveChanges();
        }

        public void UpdateInPatient(InPatient patient)
        {
            var selected = hos.InPatients.FirstOrDefault((e) => e.InPatientID == patient.InPatientID);
            if (selected == null) throw new Exception("Patient not found to update");
            hos.SaveChanges();
        }

        public void UpdateOutPatient(OutPatient patient)
        {
            var selected = hos.OutPatients.FirstOrDefault((e) => e.OutPatientID == patient.OutPatientID);
            if (selected == null) throw new Exception("Patient not found to update");
            hos.SaveChanges();
        }

        public void UpdateStaff(Staff staff)
        {
            var selected = hos.Staffs.FirstOrDefault((e) => e.ID == staff.ID);
            if (selected == null) throw new Exception("Staff not found to update");
            hos.SaveChanges();
        }
        public static class DataFactory
        {
            public static IDataComponent CreateComponent()
            {
                return new DataComponent();
            }

        }
    }
}
    

