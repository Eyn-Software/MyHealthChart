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
        Task<List<Appointment>> GetAppointments(UserViewModel User);
        Task<List<AppointmentReminderModel>> GetFutureAppointments(UserViewModel User);
        Task<Syncfusion.SfCalendar.XForms.CalendarEventCollection> GetAllAppointments(UserViewModel User);
        Task<ObservableCollection<Models.Condition>> GetConditions(UserViewModel User);
        Task<ObservableCollection<Allergy>> GetAllergies(UserViewModel User);
        Task<ObservableCollection<Vaccine>> GetVaccines(UserViewModel User);
        Task<ObservableCollection<Prescription>> GetPrescriptions(UserViewModel User);
        Task<ObservableCollection<Folder>> GetFolders(Folder Folder);
        Task<ObservableCollection<Note>> GetNotes(Folder Folder);
        Task<Appointment> GetAppointment(Appointment Appointment);
        Task<Folder> GetRootFolder(Folder Folder);
        Task<Note> GetNote(Note Note);
        Task<UserViewModel> AddUser(UserViewModel User);
        Task<string> AddDoctor(Doctor dataObject);
        Task<int> AddAppointment(Appointment Appointment);
        Task<string> AddPrescription(Prescription Prescription);
        Task<string> AddVaccine(Vaccine Vaccine);
        Task<string> AddCondition(Models.Condition Condition);
        Task<string> AddAllergy(Allergy Allergy);
        Task AddFolder(Folder Folder);
        Task AddNote(Note Note);
        Task<string> EditDoctor(Doctor Doctor);
        Task<string> EditAppointment(Appointment Appointment);
        Task<string> EditPrescription(Prescription Prescription);
        Task EditNote(Note Note);
        Task<string> DeleteCondition(Models.Condition Condition);
        Task DeleteAllergy(Allergy Allergy);
        Task DeleteNote(Note Note);
    }
}
