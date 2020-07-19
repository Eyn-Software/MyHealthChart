using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using MyHealthChart3.Views.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class AppointmentDetailViewModel : BaseViewModel
    {
        private bool ispast;
        private IPageService ps;
        private IServerComms NetworkModule;
        private UserViewModel user;
        private AppointmentDetailModel appointment;

        public bool IsPast
        {
            get
            {
                return ispast;
            }
            set
            {
                SetValue(ref ispast, value);
            }
        }
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

        public ICommand SetDetailsCmd
        {
            get;
            private set;
        }
        public ICommand EditAppointmentCmd
        {
            get;
            private set;
        }
        public AppointmentDetailViewModel(UserViewModel Usr, int AId, IPageService Ps, IServerComms networkModule)
        {
            User = Usr;
            ps = Ps;
            NetworkModule = networkModule;
            Appointment = new AppointmentDetailModel();
            Appointment.AId = AId;
            Appointment.UId = User.Id;
            Appointment.Password = User.Password;

            SetDetailsCmd = new Command(async () => await SetDetails());
            EditAppointmentCmd = new Command(async () => await EditAppointment());
        }
        private async Task SetDetails()
        {
            Appointment = await NetworkModule.GetAppointment(Appointment);
            int result = DateTime.Compare(Appointment.Date, DateTime.Now);
            if(result < 0)
            {
                IsPast = true;
            }
            else
            {
                IsPast = false;
            }
        }
        private async Task EditAppointment()
        {
            await ps.PushAsync(new AppointmentEditForm(User, Appointment, NetworkModule));
        }
    }
}
