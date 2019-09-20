using Xamarin.Essentials;
using Xamarin.Forms;

namespace ZipAndShareExample
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            // Required if using Xamarin.Essentials < 1.3.0
            ExperimentalFeatures.Enable(ExperimentalFeatures.ShareFileRequest);

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
