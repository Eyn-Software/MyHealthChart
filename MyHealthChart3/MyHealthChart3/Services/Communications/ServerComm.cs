using ModernHttpClient;
using MyHealthChart3.Models;
using MyHealthChart3.Models.DBObjects;
using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.Services.Parsing;
using MyHealthChart3.ViewModels.ModelCounterparts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

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
            List<UserViewModel> Users = new List<UserViewModel>();
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Email", data.Email),
                new KeyValuePair<string, string>("Password", data.Password),
                new KeyValuePair<string, string>("Function", "Login")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
            String SerializedString = await Response.Content.ReadAsStringAsync();
            if(!SerializedString.Equals(""))
            {
                Users = dp.DownloadUsers(SerializedString);
                foreach (UserViewModel u in Users)
                {
                    u.Password = data.Password;
                }
                Password = Users[0].Password;
                return Users;
            }
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
            List<UserViewModel> Users = dp.DownloadUsers(SerializedString);
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
        public async Task<List<Doctor>> GetDoctors(UserViewModel user)
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
            List<Doctor> Doctors = dp.DownloadDoctors(SerializedString);
            return Doctors;
        }
        /*
        Name: GetAppointments
        Purpose: Gets a list of all appointments for the chosen user
        Author: Samuel McManus
        Uses: DownloadAppointments
        Used by: AppointmentList
        Date: July 1, 2020
        */
        public async Task<List<Appointment>> GetAppointments(UserViewModel User)
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
            return dp.DownloadAppointments(Details);
        }
        /*
        Name: GetAllAppointments
        Purpose: Gets a list of all appointments on the account for the calendar
        Author: Samuel McManus
        Uses: DownloadVaccines
        Used by: VaccineList
        Date: July 11, 2020
        */
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
            return dp.DownloadCalendar(Details);
        }
        /*
        Name: GetFutureAppointments
        Purpose: Gets a list of future appointments on the account
        Author: Samuel McManus
        Uses: DownloadFutureAppointments
        Used by: LoginFormViewModel
        Date: July 16, 2020
        */
        public async Task<List<AppointmentReminderModel>> GetFutureAppointments(UserViewModel User)
        {
            IDataParse dp = new DataParse();
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("UId", User.Id.ToString()),
                new KeyValuePair<string, string>("Password", User.Password),
                new KeyValuePair<string, string>("Function", "ListFutureAppointments")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
            string Details = await Response.Content.ReadAsStringAsync();
            return dp.DownloadFutureAppointments(Details);
        }
        /*
        Name: GetConditions
        Purpose: Gets a list of all conditions for the chosen user
        Author: Samuel McManus
        Uses: DownloadConditions
        Used by: ConditionList
        Date: July 7, 2020
        */
        public async Task<ObservableCollection<Models.Condition>> GetConditions(UserViewModel User)
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
            return dp.DownloadConditions(Details);
        }
        /*
        Name: GetAllergies
        Purpose: Gets a list of all the user's allergies
        Author: Samuel McManus
        Uses: N/A
        Used by: AllergyListViewModel
        Date: July 8, 2020
        */
        public async Task<ObservableCollection<Allergy>> GetAllergies(UserViewModel User)
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
            return dp.DownloadAllergies(Details);
        }
        /*
        Name: GetVaccines
        Purpose: Gets a list of all the user's vaccines
        Author: Samuel McManus
        Uses: N/A
        Used by: VaccineListViewModel
        Date: July 13, 2020
        */
        public async Task<ObservableCollection<Vaccine>> GetVaccines(UserViewModel User)
        {
            IDataParse dp = new DataParse();
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("UId", User.Id.ToString()),
                new KeyValuePair<string, string>("Password", User.Password),
                new KeyValuePair<string, string>("Function", "ListVaccines")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
            string Details = await Response.Content.ReadAsStringAsync();
            return dp.DownloadVaccines(Details);
        }
        /*
        Name: GetPrescriptions
        Purpose: Gets a list of all the user's prescriptions
        Author: Samuel McManus
        Uses: N/A
        Used by: PrescriptionListViewModel
        Date: July 14, 2020
        */
        public async Task<ObservableCollection<Prescription>> GetPrescriptions(UserViewModel User)
        {
            IDataParse dp = new DataParse();
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("UId", User.Id.ToString()),
                new KeyValuePair<string, string>("Password", User.Password),
                new KeyValuePair<string, string>("Function", "ListPrescriptions")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
            string Details = await Response.Content.ReadAsStringAsync();
            return dp.DownloadPrescriptions(Details);
        }
        /*
        Name: GetFolders
        Purpose: Gets a list of all of a folder's children folders
        Author: Samuel McManus
        Uses: N/A
        Used by: NoteListViewModel
        Date: July 19, 2020
        */
        public async Task<ObservableCollection<FolderListModel>> GetFolders(FolderListModel Folder)
        {
            IDataParse dp = new DataParse();
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("UId", Folder.UId.ToString()),
                new KeyValuePair<string, string>("Password", Folder.Password),
                new KeyValuePair<string, string>("Id", Folder.Id.ToString()),
                new KeyValuePair<string, string>("Function", "ListChildFolders")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
            string Details = await Response.Content.ReadAsStringAsync();
            return dp.DownloadFolders(Details);
        }
        /*
        Name: GetNotes
        Purpose: Gets a list of all of a folder's notes
        Author: Samuel McManus
        Uses: N/A
        Used by: NoteListViewModel
        Date: July 19, 2020
        */
        public async Task<ObservableCollection<NoteListModel>> GetNotes(FolderListModel Folder)
        {
            IDataParse dp = new DataParse();
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("UId", Folder.UId.ToString()),
                new KeyValuePair<string, string>("Password", Folder.Password),
                new KeyValuePair<string, string>("Id", Folder.Id.ToString()),
                new KeyValuePair<string, string>("Function", "ListChildNotes")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
            string Details = await Response.Content.ReadAsStringAsync();
            return dp.DownloadNotes(Details);
        }
        /*
        Name: GetAppointment
        Purpose: Gets all the details of one of a user's appointments
        Author: Samuel McManus
        Uses: DownloadAppointment
        Used by: AppointmentDetail
        Date: July 6, 2020
        */
        public async Task<Appointment> GetAppointment(Appointment Appointment)
        {
            IDataParse dp = new DataParse();
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("AId", Appointment.Id.ToString()),
                new KeyValuePair<string, string>("UId", Appointment.UId.ToString()),
                new KeyValuePair<string, string>("Password", Appointment.Password),
                new KeyValuePair<string, string>("Function", "GetAppointment")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
            string Details = await Response.Content.ReadAsStringAsync();
            Appointment Appt = new Appointment();
            if(!Details.Equals(""))
                Appt = dp.DownloadAppointment(Details, Appointment);
            return Appt;
        }
        /*
        Name: GetRootFolder
        Purpose: Gets the user's root folder
        Author: Samuel McManus
        Uses: N/A
        Used by: OptionList
        Date: July 19, 2020
        */
        public async Task<FolderListModel> GetRootFolder(FolderListModel Folder)
        {
            IDataParse dp = new DataParse();
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("UId", Folder.UId.ToString()),
                new KeyValuePair<string, string>("Password", Folder.Password),
                new KeyValuePair<string, string>("Function", "GetRootFolder")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
            string Details = await Response.Content.ReadAsStringAsync();
            if (!Details.Equals("No root"))
            {
                Folder.Id = int.Parse(Details);
                return Folder;
            }
            Folder.Id = 0;
            return null;
        }
        /*
        Name: GetNote
        Purpose: Gets a note from the database
        Author: Samuel McManus
        Uses: N/A
        Used by: NoteDetailViewModel
        Date: July 20, 2020
        */
        public async Task<NoteFormModel> GetNote(NoteListModel Note)
        {
            IDataParse dp = new DataParse();
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Id", Note.Id.ToString()),
                new KeyValuePair<string, string>("UId", Note.UId.ToString()),
                new KeyValuePair<string, string>("Password", Note.Password),
                new KeyValuePair<string, string>("Function", "GetNote")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
            string Details = await Response.Content.ReadAsStringAsync();
            return dp.DownloadNote(Details, Note);
        }
        /*
        Name: AddUser
        Purpose: Adds a new user
        Author: Samuel McManus
        Uses: DownloadUser
        Used by: UserFormViewModel
        Date: July 23, 2020
        */
        public async Task<UserViewModel> AddUser(UserViewModel User)
        {
            IDataParse dp = new DataParse();
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Name", User.Name),
                new KeyValuePair<string, string>("Birthday", User.Birthday.ToString("yyyy-MM-dd")),
                new KeyValuePair<string, string>("UId", User.Id.ToString()),
                new KeyValuePair<string, string>("Password", User.Password),
                new KeyValuePair<string, string>("Function", "AddUser")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
            String SerializedString = await Response.Content.ReadAsStringAsync();
            return dp.DownloadUser(SerializedString);
        }

        /*
       Name: SubmitDoctor
       Purpose: Adds a doctor to the server
       Author: Samuel McManus
       Uses: N/A
       Used by: DoctorFormViewModel
       Date: June 30, 2020
       */
        public async Task<string> AddDoctor(Doctor Doctor)
        {
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Id", Doctor.UId.ToString()),
                new KeyValuePair<string, string>("Password", Doctor.Password),
                new KeyValuePair<string, string>("Function", "DoctorForm"),
                new KeyValuePair<string, string>("Name", Doctor.Name),
                new KeyValuePair<string, string>("Practice", Doctor.Practice),
                new KeyValuePair<string, string>("Type", Doctor.Type),
                new KeyValuePair<string, string>("Address", Doctor.Address),
                new KeyValuePair<string, string>("Phone", Doctor.Phone.ToString()),
                new KeyValuePair<string, string>("Email", Doctor.Email)
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
        public async Task<int> AddAppointment(Appointment Appointment)
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
        public async Task<string> AddPrescription(Prescription Prescription)
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
        public async Task<string> AddVaccine(Vaccine Vaccine)
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
        public async Task<string> AddCondition(Models.Condition Condition)
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
        public async Task<string> AddAllergy(Allergy Allergy)
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
        Name: AddFolder
        Purpose: Adds a folder
        Author: Samuel McManus
        Uses: N/A
        Used by: FolderFormViewModel
        Date: July 19, 2020
        */
        public async Task AddFolder(FolderFormModel Folder)
        {
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("UId", Folder.UId.ToString()),
                new KeyValuePair<string, string>("Password", Folder.Password),
                new KeyValuePair<string, string>("Name", Folder.Name),
                new KeyValuePair<string, string>("CreationDate", Folder.CreationDate),
                new KeyValuePair<string, string>("ParentFolderId", Folder.ParentFolderId.ToString()),
                new KeyValuePair<string, string>("Function", "AddFolder")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
        }
        /*
        Name: AddNote
        Purpose: Adds a note
        Author: Samuel McManus
        Uses: N/A
        Used by: NoteFormViewModel
        Date: July 20, 2020
        */
        public async Task AddNote(NoteFormModel Note)
        {
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("UId", Note.UId.ToString()),
                new KeyValuePair<string, string>("Password", Note.Password),
                new KeyValuePair<string, string>("Name", Note.Name),
                new KeyValuePair<string, string>("Description", Note.Description),
                new KeyValuePair<string, string>("CreationDate", Note.CreationDate),
                new KeyValuePair<string, string>("ParentFolderId", Note.ParentFolderId.ToString()),
                new KeyValuePair<string, string>("Function", "AddNote")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
        }
        /*
        Name: EditDoctor
        Purpose: Submits an update for one of the doctors on the server
        Author: Samuel McManus
        Uses: N/A
        Used by: EditDoctorFormViewModel
        Date: July 3, 2020
        */
        public async Task<string> EditDoctor(Doctor Doctor)
        {
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("UId", Doctor.UId.ToString()),
                new KeyValuePair<string, string>("Password", Doctor.Password),
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
        public async Task<string> EditAppointment(Appointment Appointment)
        {
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("UId", Appointment.UId.ToString()),
                new KeyValuePair<string, string>("Password", Appointment.Password),
                new KeyValuePair<string, string>("AId", Appointment.Id.ToString()),
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
        public async Task<string> EditPrescription(Prescription Prescription)
        {
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("UId", Prescription.UId.ToString()),
                new KeyValuePair<string, string>("Password", Prescription.Password),
                new KeyValuePair<string, string>("PId", Prescription.Id.ToString()),
                new KeyValuePair<string, string>("Name", Prescription.Name.ToString()),
                new KeyValuePair<string, string>("StartDate", Prescription.StartDate.ToString("yyyy-MM-dd hh:mm:ss")),
                new KeyValuePair<string, string>("EndDate", Prescription.EndDate.ToString("yyyy-MM-dd hh:mm:ss")),
                new KeyValuePair<string, string>("ReminderTime", Prescription.ReminderTime.ToString("yyyy-MM-dd hh:mm:ss")),
                new KeyValuePair<string, string>("Function", "UpdatePrescription")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
            return await Response.Content.ReadAsStringAsync();
        }
        /*
        Name: EditNote
        Purpose: Edits a note in the database
        Author: Samuel McManus
        Uses: N/A
        Used by: NoteEditViewModel
        Date: July 20, 2020
        */
        public async Task EditNote(NoteFormModel Note)
        {
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("UId", Note.UId.ToString()),
                new KeyValuePair<string, string>("Password", Note.Password),
                new KeyValuePair<string, string>("Id", Note.Id.ToString()),
                new KeyValuePair<string, string>("Name", Note.Name),
                new KeyValuePair<string, string>("Description", Note.Description),
                new KeyValuePair<string, string>("Function", "UpdateNote")
            };
            HttpContent Content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, Content);
        }
        /*
        Name: DeleteCondition
        Purpose: Deletes a condition from the user_conditions table
        Author: Samuel McManus
        Uses: N/A
        Used by: ConditionListViewModel
        Date: July 7, 2020
        */
        public async Task<string> DeleteCondition(Models.Condition Condition)
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
        public async Task DeleteAllergy(Allergy Allergy)
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
        /*
        Name: DeleteNote
        Purpose: Deletes a note
        Author: Samuel McManus
        Uses: N/A
        Used by: NoteDetailViewModel
        Date: July 20, 2020
        */
        public async Task DeleteNote(NoteFormModel Note)
        {
            IEnumerable<KeyValuePair<string, string>> PostFields = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("UId", Note.UId.ToString()),
                new KeyValuePair<string, string>("Password", Note.Password),
                new KeyValuePair<string, string>("Id", Note.Id.ToString()),
                new KeyValuePair<string, string>("Function", "DeleteNote")
            };
            HttpContent content = new FormUrlEncodedContent(PostFields);
            HttpResponseMessage Response = await Client.PostAsync(Uri, content);
        }
    }
}
