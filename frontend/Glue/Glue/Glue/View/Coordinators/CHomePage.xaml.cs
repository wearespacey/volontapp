using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Glue.ViewModel;

namespace Glue.View.Coordinators
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CHomePage : ContentPage
    {
        private CHomeViewModel Context;
        private bool HasLoaded = false;

        public CHomePage()
        {
            InitializeComponent();
            Context = (BindingContext as CHomeViewModel);
        }

        protected override async void OnAppearing()
        {
            if (!HasLoaded)
            {
                HasLoaded = true;
                await Context.LoadDisplayList();
            }
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem is Model.Displayers.DisplayLight)
            {
                var id = ((Model.Displayers.DisplayLight)e.SelectedItem).Id;
                await Application.Current.MainPage.Navigation.PushAsync(new CNotifyPage(id));
                DisplayViewList.SelectedItem = null;
            }
        }
    }
}