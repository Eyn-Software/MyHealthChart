using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using MyHealthChart3.ViewModels.ViewCounterparts;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppointmentForm : ContentPage
    {

        public AppointmentForm(UserViewModel User, IServerComms networkModule)
        {
            InitializeComponent();
            IPageService ps = new PageService();
            ViewModel = new AppointmentFormViewModel(User, ps, networkModule);
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
        private async void PictureClicked(object sender, EventArgs e)
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

            var memoryStream = new MemoryStream();

            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.GetStream().CopyTo(memoryStream);
                ViewModel.AppointmentObject.PicBytes = memoryStream.ToArray();
                file.Dispose();
                return stream;
            });
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