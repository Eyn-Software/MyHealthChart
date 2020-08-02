namespace MyHealthChart3.Services
{
     public interface ILoginService
     {
        System.Threading.Tasks.Task SetReminders(Models.LoginFormModel Login);
        System.Threading.Tasks.Task<string> SetUsers(Models.LoginFormModel Login, IServerComms NetworkService, INotificationService NotificationService);
        System.Threading.Tasks.Task SetCredentials(Models.LoginFormModel Login);
    }
}
