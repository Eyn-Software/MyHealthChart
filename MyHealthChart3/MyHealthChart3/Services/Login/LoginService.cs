using MyHealthChart3.Models;
using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyHealthChart3.Services
{
    public class LoginService : ILoginService
    {
        public LoginService()
        {

        }
        public async Task SetCredentials(LoginFormModel Login)
        {
            Application.Current.Properties.Clear();
            Application.Current.Properties.Add("Email", Login.Email);
            Application.Current.Properties.Add("Password", Login.Password);
            await Application.Current.SavePropertiesAsync();
        }
        public Task SetReminders(LoginFormModel Login)
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> SetUsers(LoginFormModel Login, IServerComms NetworkModule, INotificationService NotificationService)
        {
            List<User> Users = await NetworkModule.Login(Login);
            if (Users.Count != 0)
            {
                await SetCredentials(Login);
                List<Prescription> Prescriptions = new List<Prescription>();
                List<AppointmentReminderModel> Appointments = new List<AppointmentReminderModel>();
                List<Prescription> TempRx;
                List<AppointmentReminderModel> TempAppt;
                foreach (User User in Users)
                {
                    MessagingCenter.Send(this, Events.UserAdded, User);
                    //Get a list of all prescriptions for the user and add it to the list "Prescription"
                    TempRx = new List<Prescription>(await NetworkModule.GetPrescriptions(User));
                    if (TempRx.Count != 0)
                    {
                        foreach (Prescription p in TempRx)
                            Prescriptions.Add(p);
                    }
                    //Get a list of all future appointments for the user and add it to the list "Appointment"
                    TempAppt = new List<AppointmentReminderModel>(await NetworkModule.GetFutureAppointments(User));
                    if (TempAppt.Count != 0)
                    {
                        foreach (AppointmentReminderModel a in TempAppt)
                            Appointments.Add(a);
                    }
                }
                //Sets up daily notifications for each prescription
                if (Prescriptions.Count != 0)
                {
                    foreach (Prescription p in Prescriptions)
                    {
                        await NotificationService.PrescriptionHandler(p);
                    }
                }
                //Sets up daily notifications for each appointment
                if (Appointments.Count != 0)
                {
                    foreach (AppointmentReminderModel a in Appointments)
                        await NotificationService.AppointmentHandler(a);
                }
                return "Success";
            }
            else
                return "Failure";
        }

        public Task SetUsers(LoginFormModel Login)
        {
            throw new System.NotImplementedException();
        }
    }
}
