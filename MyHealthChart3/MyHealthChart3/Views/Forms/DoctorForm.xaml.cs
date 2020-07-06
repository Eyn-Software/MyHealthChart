using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using MyHealthChart3.ViewModels.ViewCounterparts;
using Syncfusion.XForms.DataForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DoctorForm : ContentPage
    {
        /*
         Name: DoctorForm
         Purpose: Initializes DoctorForm and connectes it to
                  DoctorFormViewModel
         Author: Samuel McManus
         Uses: DoctorFormViewModel
         Used by: OptionList
         Date: May 30 2020
         */
        public DoctorForm(UserViewModel user, IServerComms networkModule)
        {
            InitializeComponent();
            IPageService ps = new PageService();
            ViewModel = new DoctorFormViewModel(user, ps, networkModule);
        }
        public DoctorFormViewModel ViewModel
        {
            get
            {
                return BindingContext as DoctorFormViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}