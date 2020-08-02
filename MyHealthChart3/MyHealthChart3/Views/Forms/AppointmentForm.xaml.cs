using MyHealthChart3.Models;
using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ViewCounterparts;
using Plugin.Media;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppointmentForm : ContentPage
    {

        public AppointmentForm(User User, IServerComms networkModule)
        {
            InitializeComponent();
            ViewModel = new AppointmentFormViewModel(User, networkModule);
        }
        protected override void OnAppearing()
        {
            ViewModel.SetDoctorsCmd.Execute(null);
            base.OnAppearing();
        }
        /*
        Name: PictureClicked
        Purpose: Takes a picture for the new appointment
        Author: Samuel McManus
        Uses: N/A
        Used by: N/A
        Date: July 3 2020
        */
        private async void PictureClicked(object sender, System.EventArgs e)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                SaveToAlbum = true
            });

            if (file == null)
                return;

            var memoryStream = new System.IO.MemoryStream();

            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.GetStream().CopyTo(memoryStream);
                ViewModel.Appointment.PicBytes = memoryStream.ToArray();
                file.Dispose();
                return stream;
            });
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
            if((await ViewModel.Submit()).Equals("Success"))
                await Navigation.PopAsync();
        }
        public AppointmentFormViewModel ViewModel
        {
            get
            {
                return BindingContext as AppointmentFormViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}