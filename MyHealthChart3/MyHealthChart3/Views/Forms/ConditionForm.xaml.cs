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

namespace MyHealthChart3.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConditionForm : ContentPage
    {
        public ConditionForm(UserViewModel User, IServerComms networkModule)
        {
            InitializeComponent();
            IPageService PS = new PageService();
            ViewModel = new ConditionFormViewModel(User, networkModule, PS);
        }
        public async void Submit(object sender, EventArgs e)
        {
            if(await ViewModel.Submit())
            {
                await Navigation.PopAsync();
            }
        }
        public ConditionFormViewModel ViewModel
        {
            get
            {
                return BindingContext as ConditionFormViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}