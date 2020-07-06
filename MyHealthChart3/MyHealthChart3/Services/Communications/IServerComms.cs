using MyHealthChart3.Models;
using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.ViewModels.ModelCounterparts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyHealthChart3.Services
{
    public interface IServerComms
    {
        /*
        Name: Login
        Purpose: Attempts the login function with the server. 
                 Receives list of users on the account if 
                 successful.
        Author: Samuel McManus
        Uses: DataParse.GetUsers
        Used by: LoginFormViewModel
        Date: June 26 2020
        */
        Task<List<UserViewModel>> Login(LoginFormModel data);
        Task<List<UserViewModel>> Register(RegistrationFormModel data);
        Task<DoctorViewModel> GetDoctor(UserViewModel User, int Id);
        Task<List<DoctorViewModel>> GetDoctors(UserViewModel user);
        Task<string> SubmitDoctor(DoctorFormModel dataObject, UserViewModel user);
        Task<string> EditDoctor(DoctorEditModel Doctor, UserViewModel User);
        Task<List<AppointmentListModel>> GetAppointments(UserViewModel User);
        Task<int> AddAppointment(AppointmentFormEntryModel Appointment);
        Task<string> AddPrescription(PrescriptionFormEntryModel Prescription);
        Task<string> AddVaccine(VaccineFormEntryModel Vaccine);
        Task<AppointmentDetailModel> GetAppointment(AppointmentDetailModel Appointment);
    }
}
