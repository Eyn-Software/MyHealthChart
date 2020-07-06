using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Models.ViewDataObjects
{
    public class VaccineFormEntryModel
    {
        private string name;
        private DateTime date;
        private int aid;
        private int uid;
        private int did;
        private string password;

        public VaccineFormEntryModel()
        {
            Date = DateTime.Now;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
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
                date = value;
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
                aid = value;
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
                uid = value;
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
                did = value;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
    }
}
