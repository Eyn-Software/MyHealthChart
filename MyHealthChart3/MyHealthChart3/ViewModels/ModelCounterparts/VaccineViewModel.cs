using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.ViewModels.ModelCounterparts
{
    public class VaccineViewModel : BaseViewModel
    {
        public VaccineViewModel()
        {

        }
        public VaccineViewModel(Models.Vaccine vaccine)
        {
            Id = vaccine.Id;
            Name = vaccine.Name;
            Date = vaccine.Date;
            DId = vaccine.DId;
            UId = vaccine.UId;
            AId = vaccine.AId;
        }
        private int id;
        private string name;
        private DateTime date;
        private int did;
        private int uid;
        private int aid;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                SetValue(ref id, value);
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                SetValue(ref name, value);
            }
        }
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                SetValue(ref date, value);
            }
        }
        public int DId
        {
            get
            {
                return did;
            }
            set
            {
                SetValue(ref did, value);
            }
        }
        public int UId
        {
            get
            {
                return uid;
            }
            set
            {
                SetValue(ref uid, value);
            }
        }
        public int AId
        {
            get
            {
                return aid;
            }
            set
            {
                SetValue(ref aid, value);
            }
        }
    }
}

