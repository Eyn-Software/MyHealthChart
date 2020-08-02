using MyHealthChart3.Models;
using MyHealthChart3.Services;
using System;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class AppointmentDetailViewModel : BaseViewModel
    {
        private bool ispast;
        public IServerComms NetworkModule;
        private User user;
        private Appointment appointment;

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
        public User User
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
        public AppointmentDetailViewModel(IServerComms networkModule)
        {
            NetworkModule = networkModule;
        }
        public async void SetAppt(Appointment appt)
        {
            Appointment = await NetworkModule.GetAppointment(appt);
            if (Appointment.Prescriptions.Equals("abcdefa"))
                Appointment.Prescriptions = "";
            if (Appointment.Vaccines.Equals("abcdefa"))
                Appointment.Vaccines = "";
            int result;
            result = DateTime.Compare(Appointment.Date, DateTime.Now);
            if (result <= 0)
                IsPast = true;
        }
    }
}
