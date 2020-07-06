using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyHealthChart3.Models.ViewDataObjects
{
    public class DoctorFormModel
    {
        public DoctorFormModel()
        {
            Name = "";
            Practice = "";
            Type = "";
            Street = "";
            City = "";
            State = "";
            Email = "";

        }
        public string Name { get; set; }
        public string Practice { get; set; }
        public string Type { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
    }
}
