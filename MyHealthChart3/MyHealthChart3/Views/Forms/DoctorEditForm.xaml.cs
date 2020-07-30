using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ViewCounterparts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditDoctorForm : ContentPage
    {
        public EditDoctorForm(Models.Doctor Doctor, IServerComms NetworkModule)
        {
            InitializeComponent();
            ViewModel = new DoctorEditViewModel(Doctor, NetworkModule);
        }
        /*
         Name: SubmitClicked
         Purpose: Calls the submit command and decides whether or not to pop the page
         Author: Samuel McManus
         Uses: Submit
         Used by: N/A
         Date: July 29, 2020
         */
        public async void SubmitClicked(object sender, System.EventArgs e)
        {
            if ((await ViewModel.Submit()).Equals("Success"))
                await Navigation.PopAsync();
        }
        public DoctorEditViewModel ViewModel
        {
            get
            {
                return BindingContext as DoctorEditViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}