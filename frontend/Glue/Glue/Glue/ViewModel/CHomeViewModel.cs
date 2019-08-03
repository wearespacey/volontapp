using Glue.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Glue.ViewModel
{
    public class CHomeViewModel
    {
        public ObservableCollection<Model.Display> DisplayList { get; private set; }

        public CHomeViewModel()
        {
            DisplayList = new ObservableCollection<Model.Display>();
        }

        internal async Task GetDisplayList()
        {
            try
            {
                var items = await ApiService.GetAllDisplaysAsync();
                DisplayList = new ObservableCollection<Model.Display>(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
