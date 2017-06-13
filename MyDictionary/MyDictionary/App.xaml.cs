using MyDictionary.Views;
using Xamarin.Forms;

namespace MyDictionary
{
    public partial class App : Application
    {
        public static string DbName { get; set; } = "MyDictionary.db3";
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MasterPage());
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
