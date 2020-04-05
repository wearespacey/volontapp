using Glue.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using System.Collections.Generic;

namespace Glue.View.Coordinators
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CNotifyPage : ContentPage
	{
        private CNotifyViewModel Context;
        private bool HasLoaded = false;

        private string _id { get; set; }

		public CNotifyPage ()
		{
			InitializeComponent();
            Context = (BindingContext as CNotifyViewModel);           
        }

        public CNotifyPage(string id) : this()
        {
            this._id = id;
        }

        protected override async void OnAppearing()
        {
            if (!HasLoaded)
            {
                HasLoaded = true;
                await Context.LoadVolunteerList();
            }
        }

        private void OnNotify_Click(object sender, EventArgs e)
        {
            var items = (IEnumerable<Model.Displayers.VolunteerLight>)VolunteerListView.ItemsSource;
            var dudesToNotify = items.Where(i => i.IsNotified).Select(i => i.Id).ToArray();

            // todo call appcenter api notification
            DisplayAlert("Notification", "Une notification a été envoyée aux volontaires selectionnés", "Ok");
        }

        private void OnBtnSelectAll_Click(object sender, EventArgs e)
        {
            var items = (IEnumerable<Model.Displayers.VolunteerLight>)VolunteerListView.ItemsSource;
            foreach (var i in items)
                i.IsNotified = true;
        }
    }
}