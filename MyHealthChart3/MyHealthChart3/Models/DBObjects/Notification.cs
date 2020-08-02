using SQLite;
using System;
namespace MyHealthChart3.Models
{
    public class Notification
    {
        [PrimaryKey, AutoIncrement, NotNull]
        public int Id { get; set; }
        public DateTime ReminderTime { get; set; }
        public int PId { get; set; }
        public int AId { get; set; }
    }
}
