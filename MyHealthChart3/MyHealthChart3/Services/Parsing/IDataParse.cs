﻿using MyHealthChart3.Models;
using MyHealthChart3.Models.DBObjects;
using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.ViewModels.ModelCounterparts;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
        List<UserViewModel> DownloadUsers(string ReceivedData);
        List<Doctor> DownloadDoctors(string ReceivedData);
        List<Appointment> DownloadAppointments(string ReceivedData);
        List<AppointmentReminderModel> DownloadFutureAppointments(string ReceivedData);
        Syncfusion.SfCalendar.XForms.CalendarEventCollection DownloadCalendar(string ReceivedData);
        ObservableCollection<Models.Condition> DownloadConditions(string ReceivedData);
        ObservableCollection<Allergy> DownloadAllergies(string ReceivedData);
        ObservableCollection<Vaccine> DownloadVaccines(string ReceivedData);
        ObservableCollection<Prescription> DownloadPrescriptions(string ReceivedData);
        ObservableCollection<FolderListModel> DownloadFolders(string ReceivedData);
        ObservableCollection<NoteListModel> DownloadNotes(string ReceivedData);
        UserViewModel DownloadUser(string ReceivedData);
        Appointment DownloadAppointment(string ReceivedData, Appointment Appointment);
        NoteFormModel DownloadNote(string ReceivedData, NoteListModel Note);
        Address DownloadAddress(string ReceivedData);
    }
}
