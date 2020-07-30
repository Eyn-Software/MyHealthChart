using MyHealthChart3.Models;
using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class AppointmentListViewModel : BaseViewModel
    {
        private IServerComms NetworkModule;
        private UserViewModel user;
        private ObservableCollection<Appointment> appointments;

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
        public ObservableCollection<Appointment> Appointments
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
        public System.Windows.Input.ICommand SetAppointmentsCmd
        {
            get;
            private set;
        }

        public AppointmentListViewModel(UserViewModel Usr, IServerComms networkModule)
        {
            User = Usr;
            NetworkModule = networkModule;

            SetAppointmentsCmd = new Command(async () => await SetAppointments());
        }
        /*
        Name: SetAppointments
        Purpose: Sets all of the appointments for a user 
        Author: Samuel McManus
        Uses: N/A
        Used by: AppointmentList
        Date: July 1, 2020
        */
        private async System.Threading.Tasks.Task SetAppointments()
        {
            int result = 0;
            Appointment apt = new Appointment();
            Appointments = new ObservableCollection<Appointment>(await NetworkModule.GetAppointments(User));

            if (Appointments != null  && Appointments.Count != 0)
            {
                for (int i = 0; i < Appointments.Count - 1; i++)
                {
                    for (int j = 0; j < Appointments.Count - i - 1; j++)
                    {
                        result = DateTime.Compare(Appointments[j].Date, Appointments[j + 1].Date);
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
    }
}
