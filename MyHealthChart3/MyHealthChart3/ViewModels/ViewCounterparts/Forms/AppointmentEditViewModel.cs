using MyHealthChart3.Models;
using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class AppointmentEditViewModel : BaseViewModel
    {
        private UserViewModel user;
        private Appointment appointment;
        private IServerComms networkmodule;

        public UserViewModel User
        {
            get
            {
                return user;
            }
            set
            {
                SetValue(ref user, value);
            }
        }
        public Appointment Appointment
        {
            get
            {
                return appointment;
            }
            set
            {
                SetValue(ref appointment, value);
            }
        }
        public AppointmentEditViewModel(Appointment Appt, IServerComms networkModule)
        {
            Appointment = Appt;
            Appointment.Time = Appointment.Date.TimeOfDay;
            networkmodule = networkModule;
        }
        public async System.Threading.Tasks.Task<string> Submit()
        {
            Appointment.Date = Appointment.Date.Date + Appointment.Time;
            return await networkmodule.EditAppointment(Appointment);
        }
    }
}