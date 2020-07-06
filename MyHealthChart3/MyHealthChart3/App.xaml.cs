using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyHealthChart3.Services;
using MyHealthChart3.Views;

namespace MyHealthChart3
{
    public partial class App : Application
    {

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjc2NDM4QDMxMzgyZTMxMmUzMERNZmFiTkd4RVpZYWFuU3h0dU1MZXFMd09JOEg5VmNRTGdDY1FzOFF3UTg9");
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
