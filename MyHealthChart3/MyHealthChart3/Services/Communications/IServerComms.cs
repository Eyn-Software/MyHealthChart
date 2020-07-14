using MyHealthChart3.Models;
using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.ViewModels.ModelCounterparts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MyHealthChart3.Services
{
    public interface IServerComms
    {
        Task<List<UserViewModel>> Login(LoginFormModel data);
        Task<List<UserViewModel>> Register(RegistrationFormModel data);
        Task<List<DoctorViewModel>> GetDoctors(UserViewModel user);
        Task<List<AppointmentListModel>> GetAppointments(UserViewModel User);
        Task<Syncfusion.SfCalendar.XForms.CalendarEventCollection> GetAllAppointments(UserViewModel User);
        Task<ObservableCollection<ConditionViewModel>> GetConditions(UserViewModel User);
        Task<ObservableCollection<AllergyViewModel>> GetAllergies(UserViewModel User);
        Task<ObservableCollection<VaccineListModel>> GetVaccines(UserViewModel User);
        Task<ObservableCollection<PrescriptionListModel>> GetPrescriptions(UserViewModel User);
        Task<DoctorViewModel> GetDoctor(UserViewModel User, int Id);
        Task<AppointmentDetailModel> GetAppointment(AppointmentDetailModel Appointment);
        Task<PrescriptionListModel> GetPrescription(PrescriptionListModel Prescription);
        Task<string> SubmitDoctor(DoctorFormModel dataObject, UserViewModel user);
        Task<int> AddAppointment(AppointmentFormEntryModel Appointment);
        Task<string> AddPrescription(PrescriptionFormEntryModel Prescription);
        Task<string> AddVaccine(VaccineFormEntryModel Vaccine);
        Task<string> AddCondition(ConditionFormModel Condition);
        Task<string> AddAllergy(AllergyFormModel Allergy);
        Task<string> EditDoctor(DoctorEditModel Doctor, UserViewModel User);
        Task<string> EditAppointment(AppointmentDetailModel Appointment);
        Task<string> EditPrescription(PrescriptionListModel Prescription);
        Task<string> DeleteCondition(ConditionFormModel Condition);
        Task DeleteAllergy(AllergyFormModel Allergy);
    }
}
