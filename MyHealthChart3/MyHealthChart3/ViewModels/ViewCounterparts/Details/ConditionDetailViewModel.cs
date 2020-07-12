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
        public ConditionDetailViewModel(ConditionFormModel Cond, IServerComms networkModule)
        {
            Condition = Cond;
            NetworkModule = networkModule;
        }
        /*
        Name: DeleteCondition
        Purpose: Deletes the condition from the users_conditions table
        Author: Samuel McManus
        Uses: DeleteCondition
        Used by: ConditionDetail
        Date: July 7, 2020
        */
        public async Task DeleteCondition()
        {
            await NetworkModule.DeleteCondition(Condition);
        }
    }
}
