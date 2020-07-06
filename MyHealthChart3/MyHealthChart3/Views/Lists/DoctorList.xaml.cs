using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using MyHealthChart3.ViewModels.ViewCounterparts;
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
    public partial class DoctorList : ContentPage
    {
        /*
        Name: DoctorList
        Purpose: The initialization of the doctor
                    list view
        Author: Samuel McManus
        Uses: DoctorListViewModel
        Used by: OptionList
        Date: May 29 2020
        */
        public DoctorList(UserViewModel u, IServerComms networkModule)
        {
            InitializeComponent();
            var ps = new PageService();
            ViewModel = new DoctorListViewModel(ps, networkModule, u);
        }
        /*
        Name: OnAppearing
        Purpose: Sets the doctors before the
                    doctors list page displays
        Author: Samuel McManus
        Uses: SetDoctorsCmd
        Used by: N/A
        Date: May 29 2020
        */
        protected override void OnAppearing()
        {
            ViewModel.SetDoctorsCmd.Execute(null);
            base.OnAppearing();
        }
        /*
        Name: OnEdit
        Purpose: Calls the edit command
        Author: Samuel McManus
        Uses: PushAsync
        Used by: N/A
        Date: May 30 2020
        */
        private void OnEdit(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            ViewModel.id = (int)mi.CommandParameter;
            ViewModel.EditDoctorCmd.Execute(null);
        }
        public DoctorListViewModel ViewModel
        {
            get
            {
                return BindingContext as DoctorListViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}