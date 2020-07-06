using MyHealthChart3.ViewModels.ModelCounterparts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Models.ViewDataObjects
{
    public class DoctorEditModel
    {
        public DoctorEditModel()
        {
            Name = "";
            Practice = "";
            Type = "";
            Address = "";
            Phone = "";
            Email = "";
        }
        public DoctorEditModel(DoctorViewModel D)
        {
            Id = D.Id;
            Name = D.Name;
            Practice = D.Practice;
            Type = D.Type;
            Address = D.Address;
            Phone = D.Phone;
            Email = D.Email;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Practice { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}
