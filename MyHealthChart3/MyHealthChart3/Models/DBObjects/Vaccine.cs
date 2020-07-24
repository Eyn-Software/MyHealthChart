using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Models.DBObjects
{
    public class Vaccine
    {
        public Vaccine()
        {
            Date = DateTime.Now;
        }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string StringDate { get; set; }
        public int AId { get; set; }
        public int UId { get; set; }
        public int DId { get; set; }
        public string Password { get; set; }
    }
}
