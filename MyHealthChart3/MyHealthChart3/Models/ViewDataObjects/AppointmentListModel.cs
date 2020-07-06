using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Models.ViewDataObjects
{
    public class AppointmentListModel
    { 
        public AppointmentListModel()
        {
            Id = 0;
            Doctor = "";
            Date = "";
            DateAsDateTime = new DateTime();
        }
        public int Id { get; set; }
        public string Doctor { get; set; }
        public string Date { get; set; }
        public DateTime DateAsDateTime { get; set; }
    }
}
