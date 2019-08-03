using System;
using System.Collections.Generic;
using System.Text;

namespace Glue.Model.Displayers
{
    public class ChildStatus : Displayer
    {
        private string _surname;
        private string _firstname;
        private string _status;

        public string Surname
        {
            get => _surname;
            set
            {
                if (value == _surname)
                    return;
                value = _surname;
                OnPropertyChanged();
            }
        }

        public string Firstname
        {
            get => _firstname;
            set
            {
                if (value == _firstname)
                    return;
                value = _firstname;
                OnPropertyChanged();
            }
        }

        public string Status
        {
            get => _status;
            set
            {
                if (value == _status)
                    return;
                value = _status;
                OnPropertyChanged();
            }
        }
    }
}
