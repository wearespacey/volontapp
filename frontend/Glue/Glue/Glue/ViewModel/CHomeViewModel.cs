using Glue.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Glue.ViewModel
{
    public class CHomeViewModel
    {
        public ObservableCollection<Model.Displayers.DisplayLight> DisplayList { get; private set; }

        public CHomeViewModel()
        {
            DisplayList = new ObservableCollection<Model.Displayers.DisplayLight>();
        }

        internal async Task LoadDisplayList()
        {
            try
            {
                var items = await ApiService.GetAllDisplaysAsync();
                foreach(var i in items)
                    DisplayList.Add(new Model.Displayers.DisplayLight(i));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
