using MyHealthChart3.Services;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class ConditionDetailViewModel : BaseViewModel
    {
        private IServerComms NetworkModule;
        private Models.Condition condition;

        public Models.Condition Condition
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
        public ConditionDetailViewModel(Models.Condition Cond, IServerComms networkModule)
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
        public async System.Threading.Tasks.Task DeleteCondition()
        {
            await NetworkModule.DeleteCondition(Condition);
        }
    }
}
