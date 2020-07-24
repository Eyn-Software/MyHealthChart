using MyHealthChart3.Models.DBObjects;
using MyHealthChart3.ViewModels.ViewCounterparts.Details;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views.Details
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VaccineDetail : ContentPage
    {
        public VaccineDetail(Vaccine Vaccine)
        {
            InitializeComponent();
            ViewModel = new VaccineDetailViewModel(Vaccine);
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