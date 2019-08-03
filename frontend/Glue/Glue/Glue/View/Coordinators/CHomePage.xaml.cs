namespace Glue.View.Coordinators
{
    using Newtonsoft.Json;
    using System.Net.Http;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using System.Collections.Generic;
    using Glue.Services;
    using System.Threading.Tasks;
    using Glue.ViewModel;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CHomePage : ContentPage
    {

        private CHomeViewModel Context;
        public CHomePage()
        {
            InitializeComponent();
            Context = (BindingContext as CHomeViewModel);
        }

        private bool First = true;

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if(First)
            {
                First = false;
                await Context.GetDisplayList();
            }

        }

        private void BtnClick_Notify(object sender, System.EventArgs e)
        {

        }
    }
}