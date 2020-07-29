using MyHealthChart3.Models;
using MyHealthChart3.Models.DBObjects;
using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.ViewModels.ModelCounterparts;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MyHealthChart3.Services
{
    public interface IServerComms
    {
        Task<List<UserViewModel>> Login(LoginFormModel data);
        Task<List<UserViewModel>> Register(RegistrationFormModel data);
        Task<List<Doctor>> GetDoctors(UserViewModel user);
        Task<List<AppointmentListModel>> GetAppointments(UserViewModel User);
        Task<List<AppointmentReminderModel>> GetFutureAppointments(UserViewModel User);
        Task<Syncfusion.SfCalendar.XForms.CalendarEventCollection> GetAllAppointments(UserViewModel User);
        Task<ObservableCollection<Models.Condition>> GetConditions(UserViewModel User);
        Task<ObservableCollection<Allergy>> GetAllergies(UserViewModel User);
        Task<ObservableCollection<Vaccine>> GetVaccines(UserViewModel User);
        Task<ObservableCollection<Prescription>> GetPrescriptions(UserViewModel User);
        Task<ObservableCollection<FolderListModel>> GetFolders(FolderListModel Folder);
        Task<ObservableCollection<NoteListModel>> GetNotes(FolderListModel Folder);
        Task<Doctor> GetDoctor(UserViewModel User, int Id);
        Task<AppointmentDetailModel> GetAppointment(AppointmentDetailModel Appointment);
        Task<FolderListModel> GetRootFolder(FolderListModel Folder);
        Task<NoteFormModel> GetNote(NoteListModel Note);
        Task<UserViewModel> AddUser(UserViewModel User);
        Task<string> SubmitDoctor(Doctor dataObject, UserViewModel user);
        Task<int> AddAppointment(AppointmentFormEntryModel Appointment);
        Task<string> AddPrescription(Prescription Prescription);
        Task<string> AddVaccine(Vaccine Vaccine);
        Task<string> AddCondition(Models.Condition Condition);
        Task<string> AddAllergy(Allergy Allergy);
        Task AddFolder(FolderFormModel Folder);
        Task AddNote(NoteFormModel Note);
        Task<string> EditDoctor(Doctor Doctor, UserViewModel User);
        Task<string> EditAppointment(AppointmentDetailModel Appointment);
        Task<string> EditPrescription(Prescription Prescription);
        Task EditNote(NoteFormModel Note);
        Task<string> DeleteCondition(Models.Condition Condition);
        Task DeleteAllergy(Allergy Allergy);
        Task DeleteNote(NoteFormModel Note);
    }
}
