using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class ConditionDetailViewModel : BaseViewModel
    {
        private IServerComms NetworkModule;
        private IPageService PS;
        private ConditionFormModel condition;

        public ConditionFormModel Condition
        {
            get
            {
                return condition;
            }
            set
            {
                SetValue(ref condition, value);
            }
        }
        public ICommand DeleteConditionCmd
        {
            get;
            private set;
        }
        public ConditionDetailViewModel(ConditionFormModel Cond, IServerComms networkModule, IPageService Ps)
        {
            Condition = Cond;
            NetworkModule = networkModule;
            PS = Ps;

            DeleteConditionCmd = new Command(async () => await DeleteCondition());
        }
        public async Task DeleteCondition()
        {
            await NetworkModule.DeleteCondition(Condition);
        }
    }
}
