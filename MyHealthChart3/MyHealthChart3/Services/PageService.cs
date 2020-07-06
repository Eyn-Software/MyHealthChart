using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyHealthChart3.Services
{
    public class PageService : IPageService
    {
        public async Task DisplayAlert(string errmsg, string msg, string accept)
        {
            await Application.Current.MainPage.DisplayAlert(errmsg, msg, accept);
        }

        public async Task<Page> PopAsync()
        {
            return await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        public async Task PushAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(page);
        }
    }
}
