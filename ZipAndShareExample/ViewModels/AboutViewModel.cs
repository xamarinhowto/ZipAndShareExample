using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace ZipAndShareExample.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarinhowto.com/")));
        }

        public ICommand OpenWebCommand { get; }
    }
}