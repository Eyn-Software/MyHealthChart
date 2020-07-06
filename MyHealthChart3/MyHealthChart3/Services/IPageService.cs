using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyHealthChart3.Services
{
    public interface IPageService
    {
        Task PushAsync(Page page);
        Task<Page> PopAsync();
        Task DisplayAlert(string errmsg, string msg, string accept);
    }
}
