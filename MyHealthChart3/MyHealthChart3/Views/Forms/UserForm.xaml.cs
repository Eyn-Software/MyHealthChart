using MyHealthChart3.ViewModels.ViewCounterparts.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserForm : ContentPage
    {
        public UserForm(Models.User User, Services.IServerComms NetworkModule)
        {
            InitializeComponent();
            ViewModel = new UserFormViewModel(User, NetworkModule);
        }
        private async void Submit(object sender, System.EventArgs e)
        {
            await ViewModel.Submit();
            if (ViewModel.HasErrors == false)
                await Navigation.PopAsync();
        }
        public UserFormViewModel ViewModel
        {
            get
            {
                return BindingContext as UserFormViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}