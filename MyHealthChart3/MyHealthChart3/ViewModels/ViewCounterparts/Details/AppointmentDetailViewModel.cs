﻿using MyHealthChart3.Models;
using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using System;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class AppointmentDetailViewModel : BaseViewModel
    {
        private bool ispast;
        public IServerComms NetworkModule;
        private UserViewModel user;
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
        public AppointmentDetailViewModel(Appointment appt, IServerComms networkModule)
        {
            NetworkModule = networkModule;
            SetAppt(appt);
        }
        private async void SetAppt(Appointment appt)
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
