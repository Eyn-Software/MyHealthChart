using MyHealthChart3.Models;
using MyHealthChart3.Models.ViewDataObjects;

namespace MyHealthChart3.Services
{
    public interface INotificationService
    {
        System.Threading.Tasks.Task PrescriptionHandler(Prescription Prescription);
        System.Threading.Tasks.Task AppointmentHandler(AppointmentReminderModel Appointment);
    }
}
