using MyHealthChart3.Models;
using MyHealthChart3.Models.DBObjects;
using MyHealthChart3.Models.ViewDataObjects;
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
        List<User> DownloadUsers(string ReceivedData);
        List<Doctor> DownloadDoctors(string ReceivedData);
        List<Appointment> DownloadAppointments(string ReceivedData);
        List<AppointmentReminderModel> DownloadFutureAppointments(string ReceivedData);
        Syncfusion.SfCalendar.XForms.CalendarEventCollection DownloadCalendar(string ReceivedData);
        ObservableCollection<Models.Condition> DownloadConditions(string ReceivedData);
        ObservableCollection<Allergy> DownloadAllergies(string ReceivedData);
        ObservableCollection<Vaccine> DownloadVaccines(string ReceivedData);
        ObservableCollection<Prescription> DownloadPrescriptions(string ReceivedData);
        ObservableCollection<Folder> DownloadFolders(string ReceivedData);
        ObservableCollection<Note> DownloadNotes(string ReceivedData);
        User DownloadUser(string ReceivedData);
        Appointment DownloadAppointment(string ReceivedData, Appointment Appointment);
        Note DownloadNote(string ReceivedData, Note Note);
        Address DownloadAddress(string ReceivedData);
    }
}
