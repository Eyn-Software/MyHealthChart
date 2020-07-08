using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.Services;
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
    public partial class ConditionDetail : ContentPage
    {
        public ConditionDetail(ConditionFormModel Condition, IServerComms NetworkModule)
        {
            InitializeComponent();
            IPageService PS = new PageService();
            ViewModel = new ConditionDetailViewModel(Condition, NetworkModule, PS);
        }
        public async void DeleteCondition(object sender, EventArgs e)
        {
            ViewModel.DeleteConditionCmd.Execute(null);
            await Navigation.PopAsync();
        }
        public ConditionDetailViewModel ViewModel
        {
            get
            {
                return BindingContext as ConditionDetailViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}