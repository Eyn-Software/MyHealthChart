﻿using MyHealthChart3.Models;
using MyHealthChart3.Models.DBObjects;
using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.ViewModels.ModelCounterparts;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        Task<List<Doctor>> DownloadDoctors(string ReceivedData);
        Task<List<AppointmentListModel>> DownloadAppointments(string ReceivedData);
        Task<List<AppointmentReminderModel>> DownloadFutureAppointments(string ReceivedData);
        Task<Syncfusion.SfCalendar.XForms.CalendarEventCollection> DownloadCalendar(string ReceivedData);
        Task<ObservableCollection<Models.Condition>> DownloadConditions(string ReceivedData);
        Task<ObservableCollection<Allergy>> DownloadAllergies(string ReceivedData);
        Task<ObservableCollection<Vaccine>> DownloadVaccines(string ReceivedData);
        Task<ObservableCollection<Prescription>> DownloadPrescriptions(string ReceivedData);
        Task<ObservableCollection<FolderListModel>> DownloadFolders(string ReceivedData);
        Task<ObservableCollection<NoteListModel>> DownloadNotes(string ReceivedData);
        Task<UserViewModel> DownloadUser(string ReceivedData);
        Task<Doctor> DownloadDoctor(string ReceivedData);
        Task<AppointmentDetailModel> DownloadAppointment(string ReceivedData);
        Task<NoteFormModel> DownloadNote(string ReceivedData, NoteListModel Note);
    }
}
