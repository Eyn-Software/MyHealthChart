using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using MyHealthChart3.Views;
using MyHealthChart3.Views.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class DoctorListViewModel : BaseViewModel
    {
        private IPageService ps;
        private IServerComms NetworkModule;
        private UserViewModel user;
        private DoctorViewModel doctor;
        private ObservableCollection<DoctorViewModel> doctors;

        public ICommand SetDoctorsCmd
        {
            get;
            private set;
        }
        public ICommand NewDoctorCmd
        {
            get;
            private set;
        }
        public ICommand EditDoctorCmd
        {
            get;
            private set;
        }
        public UserViewModel User
        {
            get
            {
                return user;
            }
            set
            {
                SetValue(ref user, value);
            }
        }
        public int id;
        public ObservableCollection<DoctorViewModel> Doctors
        {
            get
            {
                return doctors;
            }
            private set
            {
                SetValue(ref doctors, value);
            }
        }
        /*
        Name: DoctorListViewModel
        Purpose: The initialization of the doctor
                    list view model. 
        Author: Samuel McManus
        Uses: SetDoctors; NewDoctor
        Used by: DoctorList
        Date: May 30 2020
        */
        public DoctorListViewModel(IPageService p, IServerComms networkModule, UserViewModel u)
        {
            ps = p;
            NetworkModule = networkModule;
            User = u;

            SetDoctorsCmd = new Command(async () => await SetDoctors());
            NewDoctorCmd = new Command(async () => await NewDoctor());
            EditDoctorCmd = new Command(async () => await EditDoctor());
        }
        /*
        Name: SetDoctors
        Purpose: Sets the doctors and alphabetizes them 
        Author: Samuel McManus
        Uses: N/A
        Used by: DoctorListViewModel
        Date: June 28 2020
        */
        private async Task SetDoctors()
        {
            Doctors = new ObservableCollection<DoctorViewModel>(await NetworkModule.GetDoctors(User));
            int result;
            DoctorViewModel doc;
            if(Doctors.Count != 0)
            {
                for (int i = 0; i < Doctors.Count - 1; i++)
                {
                    for (int j = 0; j < Doctors.Count - i - 1; j++)
                    {
                        result = String.Compare(Doctors[j].Name, Doctors[j + 1].Name);
                        if (result > 0)
                        {
                            doc = Doctors[j];
                            Doctors[j] = Doctors[j + 1];
                            Doctors[j + 1] = doc;
                        }
                    }
                }
            }
            else
            {
                await ps.PushAsync(new DoctorForm(User, NetworkModule));
            }
        }
        /*
        Name: NewDoctor
        Purpose: Takes the user to the doctor form
        Author: Samuel McManus
        Uses: N/A
        Used by: DoctorListViewModel
        Date: May 30 2020
        */
        private async Task NewDoctor()
        {
            await ps.PushAsync(new DoctorForm(User, NetworkModule));
        }
        /*
        Name: EditDoctor
        Purpose: Takes the user to the edit doctor form
        Author: Samuel McManus
        Uses: DoctorEditForm
        Used by: OnEdit
        Date: May 30 2020
        */
        private async Task EditDoctor()
        {
            doctor = await NetworkModule.GetDoctor(User, id);
            await ps.PushAsync(new EditDoctorForm(doctor, User, NetworkModule));
        }
    }
}
