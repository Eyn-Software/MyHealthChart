using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Models.ViewDataObjects
{
    public class VaccineListModel
    {
        public VaccineListModel()
        {

        }
        public string Name { get; set; }
        public string Date { get; set; }
        public ViewModels.ModelCounterparts.UserViewModel User { get; set; }
    }
}
