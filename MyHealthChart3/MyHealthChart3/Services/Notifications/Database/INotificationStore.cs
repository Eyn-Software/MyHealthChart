using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyHealthChart3.Services
{
    interface INotificationStore
    {
        Task Add(Models.Notification Notification);
        Task<List<Models.Notification>> GetAll();
        Task<List<Models.Notification>> GetPrescriptionNotifs(int PId);
        Task<List<Models.Notification>> GetAppointmentNotif(int AId);
        Task DeleteAll();
        Task DeleteOldPrescription(int PId);
        Task DeleteOldAppointment(int AId);
    }
}
