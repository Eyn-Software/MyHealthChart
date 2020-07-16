using MyHealthChart3.Models;
using MyHealthChart3.Models.ViewDataObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Plugin.LocalNotifications;
using MyHealthChart3.ViewModels.ModelCounterparts;

namespace MyHealthChart3.Services.Notifications
{
    public class NotificationService : INotificationService
    {
        static NotificationService()
        {

        }
        public async System.Threading.Tasks.Task PrescriptionHandler(PrescriptionListModel Prescription)
        {
            int EndResult, StartResult;
            DateTime ReminderDay = DateTime.Now.Date + DateTime.Parse(Prescription.ReminderTime).TimeOfDay;
            Notification Notification;
            List<Notification> Notifications = new List<Notification>();
            INotificationStore NotificationStore = new DBNotification(Xamarin.Forms.DependencyService.Get<ISQLite>());

            //Deletes old notifications with the same prescription from crosslocal notifications
            Notifications = await NotificationStore.GetPrescriptionNotifs(Prescription.Id);
            foreach(Notification n in Notifications)
            {
                CrossLocalNotifications.Current.Cancel(n.Id);
            }
            //Deletes old notifications with the same prescription from database
            await NotificationStore.DeleteOldPrescription(Prescription.Id);

            //For each day between the start date and the end date, 
            //add a prescription reminder to the database
            EndResult = DateTime.Compare(ReminderDay, DateTime.Parse(Prescription.EndDate));
            while(EndResult <= 0)
            {
                StartResult = DateTime.Compare(ReminderDay, DateTime.Parse(Prescription.StartDate));
                int MidResult = DateTime.Compare(ReminderDay, DateTime.Now);
                if(StartResult > 0 & MidResult > 0)
                {
                    Notification = new Notification();
                    Notification.ReminderTime = ReminderDay;
                    Notification.PId = Prescription.Id;
                    await NotificationStore.Add(Notification);
                }
                ReminderDay = ReminderDay.AddDays(1);
                EndResult = DateTime.Compare(ReminderDay, DateTime.Parse(Prescription.EndDate));
            }
            //Add each prescription reminder for this prescription to the local notifications
            Notifications = await NotificationStore.GetPrescriptionNotifs(Prescription.Id);
            foreach(Notification n in Notifications)
            {
                CrossLocalNotifications.Current.Show("Prescription Reminder", "This is a reminder to take " + Prescription.Name, n.Id, n.ReminderTime);
            }
        }
        //Need to send over reminder time in the appointment list
        /*
        public static async void AppointmentHandler(AppointmentListModel Appointment)
        {
                int Result;
                DateTime ReminderDay = DateTime.Parse(Appointment.Date);
                List<Notification> Notifications = new List<Notification>();
                INotificationStore NotificationStore = new DBNotification(Xamarin.Forms.DependencyService.Get<ISQLite>());

                //Deletes any old appointment reminders for this appointment
                await NotificationStore.DeleteOldAppointment(Appointment.Id);
                //Adds the appointment reminder
                Notifications = await NotificationStore.GetAppointmentNotif(Appointment.Id);
                foreach (Notification n in Notifications)
                {
                    CrossLocalNotifications.Current.Show("Prescription Reminder", "You have an appointment with " + Appointment.Doctor + " at " + ReminderDay.ToShortDateString() , n.Id, n.ReminderTime);
                }
        }
        */
    }
}
