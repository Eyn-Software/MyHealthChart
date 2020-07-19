using MyHealthChart3.ViewModels.ViewCounterparts.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views.Details
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VaccineDetail : ContentPage
    {
        public VaccineDetail(Models.ViewDataObjects.VaccineListModel Vaccine, Services.IServerComms NetworkModule)
        {
            InitializeComponent();
            ViewModel = new VaccineDetailViewModel(Vaccine, NetworkModule);
        }
        public VaccineDetailViewModel ViewModel
        {
            get
            {
                return BindingContext as VaccineDetailViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}