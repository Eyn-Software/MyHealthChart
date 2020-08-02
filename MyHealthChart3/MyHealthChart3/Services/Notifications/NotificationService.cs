using MyHealthChart3.Models;
using MyHealthChart3.Models.ViewDataObjects;
using System;
using System.Collections.Generic;
using Plugin.LocalNotifications;

namespace MyHealthChart3.Services
{
    public class NotificationService : INotificationService
    {
        static NotificationService()
        {

        }
        /*
        Name: PrescriptionHandler
        Purpose: Sets up notifications to take prescriptions
        Author: Samuel McManus
        Uses: NotificationStore
        Used by: LoginFormViewModel
        Date: July 16, 2020
        */
        public async System.Threading.Tasks.Task PrescriptionHandler(Prescription Prescription)
        {
            int EndResult, StartResult;
            DateTime ReminderDay = DateTime.Now.Date + Prescription.ReminderTime.TimeOfDay;
            Notification Notification;
            List<Notification> Notifications = new List<Notification>();
            INotificationStore NotificationStore = new DBNotification(Xamarin.Forms.DependencyService.Get<ISQLite>());

            //Deletes old notifications with the same prescription from crosslocal notifications
            Notifications = await NotificationStore.GetPrescriptionNotifs(Prescription.Id);
            foreach (Notification n in Notifications)
            {
                CrossLocalNotifications.Current.Cancel(n.Id);
            }
            //Deletes old notifications with the same prescription from database
            await NotificationStore.DeleteOldPrescription(Prescription.Id);

            //For each day between the start date and the end date, 
            //add a prescription reminder to the database
            EndResult = DateTime.Compare(ReminderDay, Prescription.EndDate);
            while (EndResult <= 0)
            {
                StartResult = DateTime.Compare(ReminderDay, Prescription.StartDate);
                int MidResult = DateTime.Compare(ReminderDay, DateTime.Now);
                if (StartResult > 0 & MidResult > 0)
                {
                    Notification = new Notification();
                    Notification.ReminderTime = ReminderDay;
                    Notification.PId = Prescription.Id;
                    await NotificationStore.Add(Notification);
                }
                ReminderDay = ReminderDay.AddDays(1);
                EndResult = DateTime.Compare(ReminderDay, Prescription.EndDate);
            }
            //Add each prescription reminder for this prescription to the local notifications
            Notifications = await NotificationStore.GetPrescriptionNotifs(Prescription.Id);
            foreach (Notification n in Notifications)
            {
                CrossLocalNotifications.Current.Show("Prescription Reminder", "This is a reminder to take " + Prescription.Name, n.Id, n.ReminderTime);
            }
        }
        /*
        Name: AppointmentHandler
        Purpose: Sets up appointment reminders
        Author: Samuel McManus
        Uses: NotificationStore
        Used by: LoginFormViewModel
        Date: July 16, 2020
        */
        public async System.Threading.Tasks.Task AppointmentHandler(AppointmentReminderModel Appointment)
        {
            Notification Notification;
            List<Notification> Notifications = new List<Notification>();
            INotificationStore NotificationStore = new DBNotification(Xamarin.Forms.DependencyService.Get<ISQLite>());

            //Gets a list of reminders for this appointment and deletes them
            //from local notifications
            Notifications = await NotificationStore.GetAppointmentNotif(Appointment.Id);
            if (Notifications.Count != 0)
            {
                foreach (Notification n in Notifications)
                    CrossLocalNotifications.Current.Cancel(n.Id);
            }

            //Deletes the old notification from the database
            await NotificationStore.DeleteOldAppointment(Appointment.Id);

            //Adds the appointment reminder to the database
            Notification = new Notification();
            Notification.AId = Appointment.Id;
            Notification.ReminderTime = Appointment.ReminderTime;
            await NotificationStore.Add(Notification);

            //Adds the appointment reminder to the local notifications
            Notifications = await NotificationStore.GetAppointmentNotif(Appointment.Id);
            if (Notifications.Count != 0)
            {
                foreach (Notification n in Notifications)
                {
                    CrossLocalNotifications.Current.Show("Prescription Reminder", "You have an appointment with " + Appointment.DoctorName + " at " + Appointment.ReminderTime.ToShortTimeString(), n.Id, n.ReminderTime);
                }
            }
        }
    }
}