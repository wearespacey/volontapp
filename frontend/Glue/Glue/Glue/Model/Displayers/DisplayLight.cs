using System;
using System.Collections.Generic;
using System.Text;

namespace Glue.Model.Displayers
{
    public class DisplayLight : Displayer
    {
        private string _id { get; set; }
        public string Id
        {
            get => _id;
            set
            {
                if (value == _id)
                    return;
                _id = value;
                OnPropertyChanged();
            }
        }

        public DisplayLight()
        {

        }

        public DisplayLight(Model.Display display)
        {
            this.Id = display.Id;
        }
    }
}
