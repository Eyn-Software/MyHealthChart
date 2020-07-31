using MyHealthChart3.Models;
using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using System;
using System.Collections.ObjectModel;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class AppointmentListViewModel : BaseViewModel
    {
        private IServerComms NetworkModule;
        private UserViewModel user;
        private ObservableCollection<Appointment> appointments, filteredappointments;

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
        public ObservableCollection<Appointment> FilteredAppointments
        {
            get
            {
                return filteredappointments;
            }
            set
            {
                SetValue(ref filteredappointments, value);
            }
        }
        public AppointmentListViewModel(UserViewModel Usr, IServerComms networkModule)
        {
            User = Usr;
            NetworkModule = networkModule;
        }
        /*
        Name: SetAppointments
        Purpose: Sets all of the appointments for a user 
        Author: Samuel McManus
        Uses: N/A
        Used by: AppointmentList
        Date: July 1, 2020
        */
        public async System.Threading.Tasks.Task<bool> SetAppointments()
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
                FilterAppointments("");
                return true;
            }
            return false;
        }
        /*
        Name: FilterAppointments
        Purpose: Filters prescriptions based on content
        Author: Samuel McManus
        Uses: N/A
        Used by: AppointmentList, SetAppointments
        Date: July 31, 2020
        */
        public void FilterAppointments(string Filter)
        {
            FilteredAppointments = new ObservableCollection<Appointment>();
            foreach (Appointment a in Appointments)
            {
                if (a.Doctor.IndexOf(Filter, System.StringComparison.OrdinalIgnoreCase) >= 0 ||
                    a.DateString.IndexOf(Filter, System.StringComparison.OrdinalIgnoreCase) >= 0 ||
                    a.Reason.IndexOf(Filter, System.StringComparison.OrdinalIgnoreCase) >= 0 ||
                    a.Diagnosis.IndexOf(Filter, System.StringComparison.OrdinalIgnoreCase) >= 0 ||
                    a.Aftercare.IndexOf(Filter, System.StringComparison.OrdinalIgnoreCase) >= 0)
                    FilteredAppointments.Add(a);
            }
        }
    }
}
