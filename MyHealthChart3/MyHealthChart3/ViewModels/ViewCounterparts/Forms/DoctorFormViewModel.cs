using MyHealthChart3.Models;
using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class DoctorFormViewModel : BaseViewModel
    {
        private IServerComms NetworkModule;
        private bool namehaserror, practichaserror, typehaserror, emailhaserror, phonehaserror;
        private string nameerror, practiceerror, typeerror, emailerror, phoneerror;
        private UserViewModel User;
        private Doctor doctor;
        private Models.DBObjects.Address address;
        public bool NameHasError
        {
            get
            {
                return namehaserror;
            }
            set
            {
                SetValue(ref namehaserror, value);
            }
        }
        public bool PracticeHasError 
        { 
            get
            {
                return practichaserror;
            }
            set
            {
                SetValue(ref practichaserror, value);
            }
        }
        public bool TypeHasError
        {
            get
            {
                return typehaserror;
            }
            set
            {
                SetValue(ref typehaserror, value);
            }
        }
        private bool EmailHasError
        {
            get
            {
                return emailhaserror;
            }
            set
            {
                SetValue(ref emailhaserror, value);
            }
        }
        public bool PhoneHasError
        {
            get
            {
                return phonehaserror;
            }
            set
            {
                SetValue(ref phonehaserror, value);
            }
        }
        public string NameError
        {
            get
            {
                return nameerror;
            }
            set
            {
                SetValue(ref nameerror, value);
                if (NameError.Equals(""))
                    NameHasError = false;
                else
                    NameHasError = true;
            }
        }
        public string PracticeError
        {
            get
            {
                return practiceerror;
            }
            set
            {
                SetValue(ref practiceerror, value);
                if (PracticeError.Equals(""))
                    PracticeHasError = false;
                else
                    PracticeHasError = true;
            }
        }
        public string TypeError
        {
            get
            {
                return typeerror;
            }
            set
            {
                SetValue(ref typeerror, value);
                if (TypeError.Equals(""))
                    TypeHasError = false;
                else
                    TypeHasError = true;
            }
        }
        public string EmailError
        {
            get
            {
                return emailerror;
            }
            set
            {
                SetValue(ref emailerror, value);
                if (EmailError.Equals(""))
                    EmailHasError = false;
                else
                    EmailHasError = true;
            }
        }
        public string PhoneError
        {
            get
            {
                return phoneerror;
            }
            set
            {
                SetValue(ref phoneerror, value);
                if (PhoneError.Equals(""))
                    PhoneHasError = false;
                else
                    PhoneHasError = true;
            }
        }
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
        public Models.DBObjects.Address Address
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
        public DoctorFormViewModel(UserViewModel u, IServerComms networkModule)
        {
            User = u;
            NetworkModule = networkModule;
            Address = new Models.DBObjects.Address();
            Doctor = new Doctor();
        }
        /*
         Name: Submit
         Purpose: Submits the doctor to the database
         Author: Samuel McManus
         Uses: SubmitDoctor
         Used by: DoctorForm
         Date: July 29, 2020
         */
        public async System.Threading.Tasks.Task<string> Submit()
        {
            NameError = "";
            PracticeError = "";
            TypeError = "";
            EmailError = "";
            PhoneError = "";

            //Checks for any errors
            if (Doctor.Name == null)
                NameError = "Required*";
            else if (Doctor.Name.Length > 50)
                NameError = "Name must be less than 50 characters";
            if (Doctor.Practice == null)
                PracticeError = "Required*";
            else if (Doctor.Practice.Length > 50)
                PracticeError = "Practice must be less than 50 characters";
            if (Doctor.Type != null && Doctor.Type.Length > 50)
                TypeError = "Specialty must be less than 50 characters";
            if (Doctor.Email != null && Doctor.Type.Length > 50)
                EmailError = "Email must be less than 50 characters";
            if (Doctor.Phone != null && Doctor.Phone.Length > 15)
                PhoneError = "Phone number must be less than 50 characters";

            if (!NameHasError && !PracticeHasError && !TypeHasError && !EmailHasError && !PhoneHasError)
            {
                Doctor.Address = Address.Street + ", " + Address.City + ", " + Address.State + ", " + Address.ZipCode;
                string result = await NetworkModule.SubmitDoctor(Doctor, User);
                return result;
            }
            else
                return "";
        }
    }
}
