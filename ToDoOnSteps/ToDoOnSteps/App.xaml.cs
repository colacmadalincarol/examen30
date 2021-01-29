using System;
using ToDoOnSteps.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoOnSteps
{
    public partial class App : Application
    {
        public static string DataBaseLocation = string.Empty;

        public App(string dbName)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
            DataBaseLocation = dbName;

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}