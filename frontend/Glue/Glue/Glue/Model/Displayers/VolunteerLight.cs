using System;
using System.Collections.Generic;
using System.Text;

namespace Glue.Model.Displayers
{
    class VolunteerLight : Displayer
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

        private string _name { get; set; }
        public string Name
        {
            get => _name;
            set
            {
                if (value == _name)
                    return;
                _name = value;
                OnPropertyChanged();
            }
        }

        private bool _isNotified { get; set; }
        public bool IsNotified
        {
            get => _isNotified;
            set
            {
                if (value == _isNotified)
                    return;
                _isNotified = value;
                OnPropertyChanged();
            }
        }

        public VolunteerLight()
        {

        }

        public VolunteerLight(Model.Volunteer volunteer)
        {
            this.Id = volunteer.Id;
            this.Name = volunteer.FirstName+" "+volunteer.Surname;
            this.IsNotified = volunteer.IsNotified;
        }
    }
}
