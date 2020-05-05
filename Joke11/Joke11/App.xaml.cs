using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Joke11
{
    public partial class App : Application
    {
        private static JokeDatabase _database;
        public static JokeDatabase Database => _database ?? (_database = new JokeDatabase());
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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
