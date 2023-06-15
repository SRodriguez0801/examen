using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Electrodomestico
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //activacion de  nagacion   
            MainPage = new NavigationPage(new MainPage());
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
