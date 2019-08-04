using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministrationConsole.Models
{
    public class Case
    {
        public string Id { get; set; }
        public string ChildId { get; set; }
        public string VolunteerId { get; set; }

        public Child Child { get; set; }
        public DateTime MissingDate { get; set; }
    }
}
