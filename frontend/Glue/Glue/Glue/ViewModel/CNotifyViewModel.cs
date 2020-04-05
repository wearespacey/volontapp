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
        public ObservableCollection<Model.Displayers.VolunteerLight> VolunteerList { get; private set; }

        public CNotifyViewModel()
        {
            VolunteerList = new ObservableCollection<Model.Displayers.VolunteerLight>();
        }

        internal async Task LoadVolunteerList()
        {
            try
            {
                var items = await ApiService.GetAllVolunteersAsync();
                foreach (var i in items)
                    VolunteerList.Add(new Model.Displayers.VolunteerLight(i));

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
