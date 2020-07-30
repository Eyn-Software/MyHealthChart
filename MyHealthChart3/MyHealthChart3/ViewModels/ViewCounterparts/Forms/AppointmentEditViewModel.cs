using MyHealthChart3.Models;
using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class AppointmentEditViewModel : BaseViewModel
    {
        private UserViewModel user;
        private Appointment appointment;
        private IPageService ps;
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
        public ICommand SubmitCmd
        {
            get;
            private set;
        }
        public AppointmentEditViewModel(Appointment Appt, IPageService Ps, IServerComms networkModule)
        {
            Appointment = Appt;
            Appointment.Time = Appointment.Date.TimeOfDay;
            Appointment.UId = User.Id;
            Appointment.Password = User.Password;
            ps = Ps;
            networkmodule = networkModule;

            SubmitCmd = new Command(async () => await Submit());
        }
        private async System.Threading.Tasks.Task Submit()
        {
            string x = await networkmodule.EditAppointment(Appointment);
            if(x.Equals("Success"))
            {
                await ps.PopAsync();
            }
        }
    }
}