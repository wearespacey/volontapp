using System;
using System.Collections.Generic;

namespace VolontApp.Models
{
    public class CoordinatorModel : Worker
    {
        public CoordinatorModel() : base()
        {}

        public List<Volunteer> Volunteers { get; set; }

    }
}
