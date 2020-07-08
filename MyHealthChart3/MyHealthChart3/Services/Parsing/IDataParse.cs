using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.ViewModels.ModelCounterparts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MyHealthChart3.Services
{
    public interface IDataParse
    {
        /*
        Name: GetUsers
        Purpose: Takes an encoded string and translates it to 
                 a list of users
        Author: Samuel McManus
        Uses: N/A
        Used by: ServerComm.Login
        Date: June 26 2020
        */
        Task<List<UserViewModel>> DownloadUsers(string ReceivedData);
        Task<List<DoctorViewModel>> DownloadDoctors(string ReceivedData);
        Task<List<AppointmentListModel>> DownloadAppointments(string ReceivedData);
        Task<DoctorViewModel> DownloadDoctor(string ReceivedData);
        Task<AppointmentDetailModel> DownloadAppointment(string ReceivedData);
        Task<ObservableCollection<ConditionViewModel>> DownloadConditions(string ReceivedData);
    }
}
