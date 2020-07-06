using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using MyHealthChart3.Views.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class AppointmentListViewModel : BaseViewModel
    {
        private IPageService PS;
        private IServerComms NetworkModule;
        private UserViewModel user;
        private ObservableCollection<AppointmentListModel> appointments;

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
        public ObservableCollection<AppointmentListModel> Appointments
        {
            get
            {
                return appointments;
            }
            set
            {
                SetValue(ref appointments, value);
            }
        }
        public ICommand SetAppointmentsCmd
        {
            get;
            private set;
        }
        public ICommand NewAppointmentCmd
        {
            get;
            private set;
        }

        public AppointmentListViewModel(UserViewModel Usr, IPageService ps, IServerComms networkModule)
        {
            User = Usr;
            PS = ps;
            NetworkModule = networkModule;

            SetAppointmentsCmd = new Command(async () => await SetAppointments());
            NewAppointmentCmd = new Command(async () => await NewAppointment());
        }
        /*
        Name: SetAppointments
        Purpose: Sets all of the appointments for a user 
        Author: Samuel McManus
        Uses: N/A
        Used by: AppointmentList
        Date: July 1, 2020
        */
        private async Task SetAppointments()
        {
            int result = 0;
            AppointmentListModel apt = new AppointmentListModel();
            Appointments = new ObservableCollection<AppointmentListModel>(await NetworkModule.GetAppointments(User));

            if (Appointments != null  && Appointments.Count != 0)
            {
                for (int i = 0; i < Appointments.Count - 1; i++)
                {
                    for (int j = 0; j < Appointments.Count - i - 1; j++)
                    {
                        result = DateTime.Compare(Appointments[j].DateAsDateTime, Appointments[j + 1].DateAsDateTime);
                        if (result > 0)
                        {
                            apt = Appointments[j];
                            Appointments[j] = Appointments[j + 1];
                            Appointments[j + 1] = apt;
                        }
                    }
                }
            }
        }
        /*
        Name: NewAppointment
        Purpose: Creates a new appointment for a user
        Author: Samuel McManus
        Uses: N/A
        Used by: AppointmentList
        Date: June 28, 2020
        */
        private async Task NewAppointment()
        {
            await PS.PushAsync(new AppointmentForm(User, NetworkModule));
        }
        private async Task EditAppointment()
        {

        }
    }
}
