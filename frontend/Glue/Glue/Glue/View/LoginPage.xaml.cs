using Glue.View.Coordinators;
using Glue.View.Volunteers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Glue.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnCoordinatorsClicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CHomePage());
        }

        private async void OnVolunteersClicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new VHomePage());
        }
    }
}