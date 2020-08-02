using MyHealthChart3.Models;
using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ViewCounterparts;
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
        public DoctorForm(User user, IServerComms networkModule)
        {
            InitializeComponent();
            ViewModel = new DoctorFormViewModel(user, networkModule);
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