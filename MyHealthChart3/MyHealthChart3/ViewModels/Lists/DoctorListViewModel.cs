using MyHealthChart3.Models;
using MyHealthChart3.Services;
using System.Collections.ObjectModel;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class DoctorListViewModel : BaseViewModel
    {
        public IServerComms NetworkModule;
        private User user;
        private ObservableCollection<Doctor> doctors, filtereddoctors;

        public User User
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
        public ObservableCollection<Doctor> Doctors
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
        public ObservableCollection<Doctor> FilteredDoctors
        {
            get
            {
                return filtereddoctors;
            }
            set
            {
                SetValue(ref filtereddoctors, value);
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
        public DoctorListViewModel(IServerComms networkModule, User u)
        {
            NetworkModule = networkModule;
            User = u;
        }
        /*
        Name: SetDoctors
        Purpose: Sets the doctors and alphabetizes them 
        Author: Samuel McManus
        Uses: N/A
        Used by: DoctorListViewModel
        Date: June 28 2020
        */
        public async System.Threading.Tasks.Task<bool> SetDoctors()
        {
            Doctors = new ObservableCollection<Doctor>(await NetworkModule.GetDoctors(User));
            int result;
            Doctor doc;
            if(Doctors.Count != 0)
            {
                for (int i = 0; i < Doctors.Count - 1; i++)
                {
                    for (int j = 0; j < Doctors.Count - i - 1; j++)
                    {
                        result = System.String.Compare(Doctors[j].Name, Doctors[j + 1].Name);
                        if (result > 0)
                        {
                            doc = Doctors[j];
                            Doctors[j] = Doctors[j + 1];
                            Doctors[j + 1] = doc;
                        }
                    }
                }
                FilterDoctors("");
                return true;
            }
            else
            {
                return false;
            }
        }
        /*
        Name: FilterDoctors
        Purpose: Filters prescriptions based on content
        Author: Samuel McManus
        Uses: N/A
        Used by: PrescriptionList
        Date: July 27, 2020
        */
        public void FilterDoctors(string Filter)
        {
            FilteredDoctors = new ObservableCollection<Doctor>();
            foreach (Doctor d in Doctors)
            {
                if (d.Name.IndexOf(Filter, System.StringComparison.OrdinalIgnoreCase) >= 0 ||
                    d.Practice.IndexOf(Filter, System.StringComparison.OrdinalIgnoreCase) >= 0 ||
                    d.Type.IndexOf(Filter, System.StringComparison.OrdinalIgnoreCase) >= 0)
                    FilteredDoctors.Add(d);
            }
        }
    }
}
