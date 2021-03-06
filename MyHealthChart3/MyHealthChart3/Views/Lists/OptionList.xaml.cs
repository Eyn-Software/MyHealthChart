﻿using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using MyHealthChart3.Views.Lists;
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
    public partial class OptionList : ContentPage
    {
        IPageService ps;
        UserViewModel User;
        IServerComms NetworkModule;
        /*
        Name: OptionList
        Purpose: The initialization of the option list
        Author: Samuel McManus
        Uses: OptionListViewModel, PageService, DBUser
        Used by: OptionList
        Date: May 28 2020
        */
        public OptionList(UserViewModel usr, IServerComms networkModule)
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
            //Navigation.PushAsync(new UserForm(User));
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
            FolderListModel Folder = new FolderListModel();
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