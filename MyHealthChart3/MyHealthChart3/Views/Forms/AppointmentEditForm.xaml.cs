using MyHealthChart3.Models.ViewDataObjects;
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
    public partial class AppointmentEditForm : ContentPage
    {
        public AppointmentEditForm(UserViewModel User, AppointmentDetailModel Appointment, IServerComms NetworkModule)
        {
            InitializeComponent();
            IPageService PS = new PageService();
            ViewModel = new AppointmentEditViewModel(User, Appointment, PS, NetworkModule);
        }
        public AppointmentEditViewModel ViewModel
        {
            get
            {
                return BindingContext as AppointmentEditViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}