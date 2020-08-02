using MyHealthChart3.Services;
using MyHealthChart3.Views.Lists;
using MyHealthChart3.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OptionList : ContentPage
    {
        IPageService ps;
        User User;
        IServerComms NetworkModule;
        /*
        Name: OptionList
        Purpose: The initialization of the option list
        Author: Samuel McManus
        Uses: OptionListViewModel, PageService, DBUser
        Used by: OptionList
        Date: May 28 2020
        */
        public OptionList(User usr, IServerComms networkModule)
        {
            InitializeComponent();
            ps = new PageService();
            NetworkModule = networkModule;
            User = usr;
        }
        public void AccountInfoClicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new ProfileInfo(User));
        }
        public void NewUserClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Forms.UserForm(User, NetworkModule));
        }
        public void AppointmentsClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AppointmentList(User, NetworkModule));
        }
        public void ConditionsClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConditionList(User, NetworkModule));
        }
        public async void DoctorsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DoctorList(User, NetworkModule));
            //await Navigation.PushAsync(new DoctorList(User, NetworkModule));
        }
        public void AllergiesClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AllergyList(User, NetworkModule));
        }
        public void PrescriptionsClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PrescriptionList(User, NetworkModule));
        }
        public void CalendarClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Calendar(User, NetworkModule));
        }
        public async void NotesClicked(object sender, EventArgs e)
        {
            Folder Folder = new Folder();
            Folder.UId = User.Id;
            Folder.Password = User.Password;
            Folder = await NetworkModule.GetRootFolder(Folder);
            await Navigation.PushAsync(new NoteList(Folder, NetworkModule));
        }
        public void VaccinesClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VaccineList(User, NetworkModule));
        }
    }
}