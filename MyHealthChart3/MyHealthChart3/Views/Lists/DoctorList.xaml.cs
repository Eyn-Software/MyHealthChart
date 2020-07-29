using MyHealthChart3.Models;
using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using MyHealthChart3.ViewModels.ViewCounterparts;
using System;
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
        UserViewModel User;
        IServerComms NetworkModule;
        public DoctorList(UserViewModel u, IServerComms networkModule)
        {
            InitializeComponent();
            var ps = new PageService();
            NetworkModule = networkModule;
            User = u;
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
        Name: DoctorSelected
        Purpose: Navigates the user to the doctor detail page
        Author: Samuel McManus
        Uses: DoctorDetail
        Used by: N/A
        Date: July 16 2020
        */
        private void DoctorSelected(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            Doctor Doctor = e.ItemData as Doctor;
            Doctor.UId = User.Id;
            Doctor.Password = User.Password;
            Navigation.PushAsync(new Details.DoctorDetail(Doctor, NetworkModule));
        }
        /*
        Name: NewDoctor
        Purpose: Takes the user to the doctor form
        Author: Samuel McManus
        Uses: N/A
        Used by: DoctorListViewModel
        Date: May 30 2020
        */
        private async void NewDoctor(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DoctorForm(User, NetworkModule));
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