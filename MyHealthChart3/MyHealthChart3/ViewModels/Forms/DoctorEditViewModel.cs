using MyHealthChart3.Models;
using MyHealthChart3.Models.DBObjects;
using MyHealthChart3.Services;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class DoctorEditViewModel : BaseViewModel
    {
        private Doctor doctor;
        private Address address;
        private IServerComms NetworkModule;
        private IDataParse dp;
        public Doctor Doctor
        {
            get
            {
                return doctor;
            }
            set
            {
                SetValue(ref doctor, value);
            }
        }
        public Address Address
        {
            get
            {
                return address;
            }
            set
            {
                SetValue(ref address, value);
            }
        }
        public DoctorEditViewModel(Doctor D, IServerComms networkModule)
        {
            Doctor = D;
            NetworkModule = networkModule;
            dp = new Services.Parsing.DataParse();
            Address = dp.DownloadAddress(Doctor.Address);
        }
        /*
        Name: Submit
        Purpose: Attempts to submit the doctor to the database
        Author: Samuel McManus
        Uses: EditDoctor
        Used by: N/A
        Date: July 29, 2020
        */
        public async System.Threading.Tasks.Task<string> Submit()
        {
            return await NetworkModule.EditDoctor(Doctor);
        }
    }
}
