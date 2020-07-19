using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class AppointmentEditViewModel : BaseViewModel
    {
        private UserViewModel user;
        private AppointmentDetailModel appointment;
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
        public AppointmentDetailModel Appointment
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
        public AppointmentEditViewModel(UserViewModel Usr, AppointmentDetailModel Appt, IPageService Ps, IServerComms networkModule)
        {
            User = Usr;
            Appointment = Appt;
            Appointment.Time = Appointment.Date.TimeOfDay;
            Appointment.UId = User.Id;
            Appointment.Password = User.Password;
            ps = Ps;
            networkmodule = networkModule;

            SubmitCmd = new Command(async () => await Submit());
        }
        private async Task Submit()
        {
            string x = await networkmodule.EditAppointment(Appointment);
            if(x.Equals("Success"))
            {
                await ps.PopAsync();
            }
        }
    }
}