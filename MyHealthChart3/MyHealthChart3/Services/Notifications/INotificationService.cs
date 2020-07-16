using MyHealthChart3.Models.ViewDataObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Services.Notifications
{
    public interface INotificationService
    {
        System.Threading.Tasks.Task PrescriptionHandler(PrescriptionListModel Prescription);
    }
}
