using MyHealthChart3.ViewModels.ModelCounterparts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Models
{
    public class Vaccine
    {
        public Vaccine()
        {

        }
        public Vaccine(VaccineViewModel vaccine)
        {
            Id = vaccine.Id;
            Name = vaccine.Name;
            Date = vaccine.Date;
            DId = vaccine.DId;
            UId = vaccine.UId;
            AId = vaccine.AId;
        }
        public int Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public DateTime Date
        {
            get;
            set;
        }
        public int DId
        {
            get;
            set;
        }
        public int UId
        {
            get;
            set;
        }
        public int AId
        {
            get;
            set;
        }
    }
}
