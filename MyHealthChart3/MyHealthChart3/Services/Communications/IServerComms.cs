using MyHealthChart3.Models;
using MyHealthChart3.Models.DBObjects;
using MyHealthChart3.Models.ViewDataObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MyHealthChart3.Services
{
    public interface IServerComms
    {
        Task<List<User>> Login(LoginFormModel data);
        Task<List<User>> Register(RegistrationFormModel data);
        Task<List<Doctor>> GetDoctors(User user);
        Task<List<Appointment>> GetAppointments(User User);
        Task<List<AppointmentReminderModel>> GetFutureAppointments(User User);
        Task<Syncfusion.SfCalendar.XForms.CalendarEventCollection> GetAllAppointments(User User);
        Task<ObservableCollection<Models.Condition>> GetConditions(User User);
        Task<ObservableCollection<Allergy>> GetAllergies(User User);
        Task<ObservableCollection<Vaccine>> GetVaccines(User User);
        Task<ObservableCollection<Prescription>> GetPrescriptions(User User);
        Task<ObservableCollection<Folder>> GetFolders(Folder Folder);
        Task<ObservableCollection<Note>> GetNotes(Folder Folder);
        Task<Appointment> GetAppointment(Appointment Appointment);
        Task<Folder> GetRootFolder(Folder Folder);
        Task<Note> GetNote(Note Note);
        Task<User> AddUser(User User);
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
