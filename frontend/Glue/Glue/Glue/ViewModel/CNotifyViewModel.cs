using Glue.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Glue.ViewModel
{
    class CNotifyViewModel
    {
        public ObservableCollection<Model.Volunteer> VolunteerList { get; private set; }

        public CNotifyViewModel()
        {
            VolunteerList = new ObservableCollection<Model.Volunteer>();
        }

        internal async Task GetItem()
        {
            try
            {
                var items = await ApiService.GetAllVolunteersAsync();
                VolunteerList = new ObservableCollection<Model.Volunteer>(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
