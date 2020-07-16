using MyHealthChart3.ViewModels.ModelCounterparts;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Models
{
    public class Notification
    {
        [PrimaryKey, AutoIncrement, NotNull]
        public int Id
        {
            get;
            set;
        }
        public DateTime ReminderTime
        {
            get;
            set;
        }
        public int PId
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
