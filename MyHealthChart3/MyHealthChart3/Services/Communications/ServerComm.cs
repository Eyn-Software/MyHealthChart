using ModernHttpClient;
using MyHealthChart3.Models;
using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.Services.Parsing;
using MyHealthChart3.ViewModels.ModelCounterparts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyHealthChart3.Services
{
    public class ServerComm : IServerComms
    {
        private static readonly HttpClient Client;
        private static readonly string Uri;
        private static string Password;
        static ServerComm()
        {
            Client = new HttpClient(new NativeMessageHandler());
            Uri = "http://192.168.1.203/Router.php";
        }
        /*
        Name: Login
        Purpose: Logs a user in with the server
        Author: Samuel McManus
        Uses: DownloadUsers
        Used by: LoginFormViewModel
        Date: June 27, 2020
        */
        public async Task<List<UserViewModel>> Login(LoginFormModel data)
        {
            IDataParse dp = new DataParse();
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Email", data.Email),
                new KeyValuePair<string, string>("Password", data.Password),
                new KeyValuePair<string, string>("Function", "Login")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
            String SerializedString = await Response.Content.ReadAsStringAsync();
            List<UserViewModel> Users = await dp.DownloadUsers(SerializedString);
            foreach(UserViewModel u in Users)
            {
                u.Password = data.Password;
            }
            Password = Users[0].Password;
            return Users;
        }
        /*
        Name: Register
        Purpose: Registers a new user
        Author: Samuel McManus
        Uses: DownloadUsers
        Used by: RegistrationFormViewModel
        Date: June 28, 2020
        */
        public async Task<List<UserViewModel>> Register(RegistrationFormModel data)
        {
            IDataParse dp = new DataParse();
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Name", data.Name),
                new KeyValuePair<string, string>("Birthday", data.Birthday.ToString("yyyy-MM-dd h:mm tt")),
                new KeyValuePair<string, string>("Email", data.Email),
                new KeyValuePair<string, string>("Password", data.Password),
                new KeyValuePair<string, string>("Function", "Register")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
            String SerializedString = await Response.Content.ReadAsStringAsync();
            List<UserViewModel> Users = await dp.DownloadUsers(SerializedString);
            foreach(UserViewModel u in Users)
            {
                u.Password = data.Password;
            }
            return Users;
        }
        /*
        Name: GetDoctors
        Purpose: Gets a list of all of a user's doctors
        Author: Samuel McManus
        Uses: DownloadDoctors
        Used by: DoctorListViewModel
        Date: June 30, 2020
        */
        public async Task<List<DoctorViewModel>> GetDoctors(UserViewModel user)
        {
            IDataParse dp = new DataParse();
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Id", user.Id.ToString()),
                new KeyValuePair<string, string>("Password", user.Password),
                new KeyValuePair<string, string>("Function", "DoctorList")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
            string SerializedString = await Response.Content.ReadAsStringAsync();
            List<DoctorViewModel> Doctors = await dp.DownloadDoctors(SerializedString);
            return Doctors;
        }
        /*
        Name: GetDoctor
        Purpose: Gets the relevant doctor from the server
        Author: Samuel McManus
        Uses: DownloadDoctor
        Used by: DoctorEditFormViewModel
        Date: June 31, 2020
        */
        public async Task<DoctorViewModel> GetDoctor(UserViewModel User, int Id)
        {
            IDataParse dp = new DataParse();
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Id", Id.ToString()),
                new KeyValuePair<string, string>("UId", User.Id.ToString()),
                new KeyValuePair<string, string>("Password", User.Password),
                new KeyValuePair<string, string>("Function", "GetDoctor")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
            string ResponseString = await Response.Content.ReadAsStringAsync();
            return await dp.DownloadDoctor(ResponseString);
        }
        /*
        Name: GetAppointments
        Purpose: Gets a list of all appointments for the chosen user
        Author: Samuel McManus
        Uses: DownloadAppointments
        Used by: AppointmentList
        Date: July 1, 2020
        */
        public async Task<List<AppointmentListModel>> GetAppointments(UserViewModel User)
        {
            IDataParse dp = new DataParse();
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("UId", User.Id.ToString()),
                new KeyValuePair<string, string>("Password", User.Password),
                new KeyValuePair<string, string>("Function", "ListAppointments")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
            string Details = await Response.Content.ReadAsStringAsync();
            return await dp.DownloadAppointments(Details);
        }
        public async Task<Syncfusion.SfCalendar.XForms.CalendarEventCollection> GetAllAppointments(UserViewModel User)
        {
            IDataParse dp = new DataParse();
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("UId", User.Id.ToString()),
                new KeyValuePair<string, string>("Password", User.Password),
                new KeyValuePair<string, string>("Function", "ListAllAppointments")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
            string Details = await Response.Content.ReadAsStringAsync();
            return await dp.DownloadCalendar(Details);
        }
        /*
        Name: GetConditions
        Purpose: Gets a list of all conditions for the chosen user
        Author: Samuel McManus
        Uses: DownloadConditions
        Used by: ConditionList
        Date: July 7, 2020
        */
        public async Task<ObservableCollection<ConditionViewModel>> GetConditions(UserViewModel User)
        {
            IDataParse dp = new DataParse();
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("UId", User.Id.ToString()),
                new KeyValuePair<string, string>("Password", User.Password),
                new KeyValuePair<string, string>("Function", "ListConditions")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
            string Details = await Response.Content.ReadAsStringAsync();
            return await dp.DownloadConditions(Details);
        }
        /*
        Name: GetAllergies
        Purpose: Gets a list of all the user's allergies
        Author: Samuel McManus
        Uses: N/A
        Used by: AllergyListViewModel
        Date: July 8, 2020
        */
        public async Task<ObservableCollection<AllergyViewModel>> GetAllergies(UserViewModel User)
        {
            IDataParse dp = new DataParse();
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("UId", User.Id.ToString()),
                new KeyValuePair<string, string>("Password", User.Password),
                new KeyValuePair<string, string>("Function", "ListAllergies")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
            string Details = await Response.Content.ReadAsStringAsync();
            return await dp.DownloadAllergies(Details);
        }
        /*
        Name: GetAppointment
        Purpose: Gets all the details of one of a user's appointments
        Author: Samuel McManus
        Uses: DownloadAppointment
        Used by: AppointmentDetail
        Date: July 6, 2020
        */
        public async Task<AppointmentDetailModel> GetAppointment(AppointmentDetailModel Appointment)
        {
            IDataParse dp = new DataParse();
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("AId", Appointment.AId.ToString()),
                new KeyValuePair<string, string>("UId", Appointment.UId.ToString()),
                new KeyValuePair<string, string>("Password", Appointment.Password),
                new KeyValuePair<string, string>("Function", "GetAppointment")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
            string Details = await Response.Content.ReadAsStringAsync();
            AppointmentDetailModel Appt = await dp.DownloadAppointment(Details);
            return Appt;
        }
        
        /*
       Name: SubmitDoctor
       Purpose: Adds a doctor to the server
       Author: Samuel McManus
       Uses: N/A
       Used by: DoctorFormViewModel
       Date: June 30, 2020
       */
        public async Task<string> SubmitDoctor(DoctorFormModel dataObject, UserViewModel user)
        {
            string address = dataObject.State + " " + dataObject.City + ", " + dataObject.State + " " + dataObject.ZipCode.ToString();
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Id", user.Id.ToString()),
                new KeyValuePair<string, string>("Password", user.Password),
                new KeyValuePair<string, string>("Function", "DoctorForm"),
                new KeyValuePair<string, string>("Name", dataObject.Name),
                new KeyValuePair<string, string>("Practice", dataObject.Practice),
                new KeyValuePair<string, string>("Type", dataObject.Type),
                new KeyValuePair<string, string>("Address", address),
                new KeyValuePair<string, string>("Phone", dataObject.Phone.ToString()),
                new KeyValuePair<string, string>("Email", dataObject.Email)
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
            return await Response.Content.ReadAsStringAsync();
        }
        /*
        Name: AddAppointment
        Purpose: Submits an appointment to the server
        Author: Samuel McManus
        Uses: N/A
        Used by: AppointmentFormViewModel
        Date: July 3, 2020
        */
        public async Task<int> AddAppointment(AppointmentFormEntryModel Appointment)
        {
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("UId", Appointment.UId.ToString()),
                new KeyValuePair<string, string>("Password", Password),
                new KeyValuePair<string, string>("Function", "AddAppointment"),
                new KeyValuePair<string, string>("DId", Appointment.ChosenDoctor.Id.ToString()),
                new KeyValuePair<string, string>("Date", Appointment.Date.ToString("yyyy-MM-dd hh:mm:ss")),
                new KeyValuePair<string, string>("Reason", Appointment.Reason),
                new KeyValuePair<string, string>("Diagnosis", Appointment.Diagnosis),
                new KeyValuePair<string, string>("Aftercare", Appointment.Aftercare),
                new KeyValuePair<string, string>("ReminderTime", Appointment.ReminderTime.ToString("yyyy-MM-dd hh:mm:ss"))
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
            string Details = await Response.Content.ReadAsStringAsync();
            try
            {
                return int.Parse(Details);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        /*
        Name: AddPrescription
        Purpose: Submits the relevant prescription to the server
        Author: Samuel McManus
        Uses: N/A
        Used by: AppointmentFormViewModel
        Date: July 3, 2020
        */
        public async Task<string> AddPrescription(PrescriptionFormEntryModel Prescription)
        {
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Name", Prescription.Name),
                new KeyValuePair<string, string>("StartDate", Prescription.StartDate.ToString("yyyy-MM-dd")),
                new KeyValuePair<string, string>("EndDate", Prescription.EndDate.ToString("yyyy-MM-dd")),
                new KeyValuePair<string, string>("ReminderTime", Prescription.ReminderTime.ToString("yyyy-MM-dd")), 
                new KeyValuePair<string, string>("AId", Prescription.AId.ToString()),
                new KeyValuePair<string, string>("DId", Prescription.DId.ToString()),
                new KeyValuePair<string, string>("UId", Prescription.UId.ToString()),
                new KeyValuePair<string, string>("Password", Prescription.Password),
                new KeyValuePair<string, string>("Function", "AddPrescription")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
            string Details = await Response.Content.ReadAsStringAsync();
            return Details;
        }
        /*
        Name: AddVaccine
        Purpose: Sends the vaccine data to the server
        Author: Samuel McManus
        Uses: N/A
        Used by: AppointmentForm
        Date: July 3, 2020
        */
        public async Task<string> AddVaccine(VaccineFormEntryModel Vaccine)
        {
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Name", Vaccine.Name),
                new KeyValuePair<string, string>("Date", Vaccine.Date.ToString("yyyy-MM-dd")),
                new KeyValuePair<string, string>("AId", Vaccine.AId.ToString()),
                new KeyValuePair<string, string>("UId", Vaccine.UId.ToString()),
                new KeyValuePair<string, string>("DId", Vaccine.DId.ToString()),
                new KeyValuePair<string, string>("Password", Vaccine.Password.ToString()),
                new KeyValuePair<string, string>("Function", "AddVaccine")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
            string Details = await Response.Content.ReadAsStringAsync();
            return Details;
        }
        /*
        Name: Add Condition
        Purpose: Submits a condition on the server
        Author: Samuel McManus
        Uses: N/A
        Used by: ConditionFormViewModel
        Date: July 7, 2020
        */
        public async Task<string> AddCondition(ConditionFormModel Condition)
        {
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("UId", Condition.UId.ToString()),
                new KeyValuePair<string, string>("Password", Condition.Password),
                new KeyValuePair<string, string>("Type", Condition.Type),
                new KeyValuePair<string, string>("Function", "AddCondition")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
            string Details = await Response.Content.ReadAsStringAsync();
            return Details;
        }
        /*
        Name: AddAllergy
        Purpose: Adds an allergy to the user_allergy table
        Author: Samuel McManus
        Uses: N/A
        Used by: AllergyFormViewModel
        Date: July 8, 2020
        */
        public async Task<string> AddAllergy(AllergyFormModel Allergy)
        {
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("UId", Allergy.UId.ToString()),
                new KeyValuePair<string, string>("Password", Allergy.Password),
                new KeyValuePair<string, string>("Type", Allergy.Type),
                new KeyValuePair<string, string>("Function", "AddAllergy")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
            string Details = await Response.Content.ReadAsStringAsync();
            return Details;
        }
        /*
        Name: EditDoctor
        Purpose: Submits an update for one of the doctors on the server
        Author: Samuel McManus
        Uses: N/A
        Used by: EditDoctorFormViewModel
        Date: July 3, 2020
        */
        public async Task<string> EditDoctor(DoctorEditModel Doctor, UserViewModel User)
        {
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("UId", User.Id.ToString()),
                new KeyValuePair<string, string>("Password", User.Password),
                new KeyValuePair<string, string>("Id", Doctor.Id.ToString()),
                new KeyValuePair<string, string>("Name", Doctor.Name),
                new KeyValuePair<string, string>("Practice", Doctor.Practice),
                new KeyValuePair<string, string>("Type", Doctor.Type),
                new KeyValuePair<string, string>("Address", Doctor.Address),
                new KeyValuePair<string, string>("Phone", Doctor.Phone),
                new KeyValuePair<string, string>("Email", Doctor.Email),
                new KeyValuePair<string, string>("Function", "UpdateDoctor")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
            return await Response.Content.ReadAsStringAsync();
        }
        /*
        Name: EditAppointment
        Purpose: Submits an update for one of the appointments on the server
        Author: Samuel McManus
        Uses: N/A
        Used by: EditAppointmentFormViewModel
        Date: July 6, 2020
        */
        public async Task<string> EditAppointment(AppointmentDetailModel Appointment)
        {
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("UId", Appointment.UId.ToString()),
                new KeyValuePair<string, string>("Password", Appointment.Password),
                new KeyValuePair<string, string>("AId", Appointment.AId.ToString()),
                new KeyValuePair<string, string>("Date", Appointment.Date.ToString("yyyy-MM-dd hh:mm:ss")),
                new KeyValuePair<string, string>("Reason", Appointment.Reason),
                new KeyValuePair<string, string>("Diagnosis", Appointment.Diagnosis),
                new KeyValuePair<string, string>("Aftercare", Appointment.Aftercare),
                new KeyValuePair<string, string>("Function", "UpdateAppointment")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
            return await Response.Content.ReadAsStringAsync();
        }
        /*
        Name: DeleteCondition
        Purpose: Deletes a condition from the user_conditions table
        Author: Samuel McManus
        Uses: N/A
        Used by: ConditionListViewModel
        Date: July 7, 2020
        */
        public async Task<string> DeleteCondition(ConditionFormModel Condition)
        {
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("UId", Condition.UId.ToString()),
                new KeyValuePair<string, string>("Password", Condition.Password),
                new KeyValuePair<string, string>("Type", Condition.Type),
                new KeyValuePair<string, string>("Function", "DeleteCondition")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
            return await Response.Content.ReadAsStringAsync();
        }
        /*
        Name: DeleteAllergy
        Purpose: Deletes an allergy from the user_allergies table
        Author: Samuel McManus
        Uses: N/A
        Used by: AllergyistViewModel
        Date: July 8, 2020
        */
        public async Task DeleteAllergy(AllergyFormModel Allergy)
        {
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("UId", Allergy.UId.ToString()),
                new KeyValuePair<string, string>("Password", Allergy.Password),
                new KeyValuePair<string, string>("Type", Allergy.Type),
                new KeyValuePair<string, string>("Function", "DeleteAllergy")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
        }
    }
}
