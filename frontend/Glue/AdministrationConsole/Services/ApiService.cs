using AdministrationConsole.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VolontApp.Models;

namespace AdministrationConsole.Services
{
    public class ApiService
    {
        static List<Child> children = new List<Child>()
        {
            new Child() { Id = "1", FirstName = "Bernd", LastName = "Bibo"},
            new Child() { Id = "2", FirstName = "Friedo", LastName = "Bibo"},
            new Child() { Id = "3", FirstName = "Rebel", LastName = "Bibo"},
            new Child() { Id = "4", FirstName = "Hans", LastName = "Bibo"}
        };

        static List<Case> cases = new List<Case>()
        {
            new Case() { Id = "c1", ChildId = "2"},
            new Case() { Id = "c2", ChildId = "2"},
            new Case() { Id = "c3", ChildId = "1"},
            new Case() { Id = "c4", ChildId = "3"}
        };

        static List<Volunteer> coordinators = new List<Volunteer>()
        {
            new Volunteer() { Id = "v1", FirstName = "Volo"},
            new Volunteer() { Id = "v2", FirstName = "voloho"},
            new Volunteer() { Id = "v3", FirstName = "trioll"},
            new Volunteer() { Id = "v4", FirstName = "yeet"}
        };

        static HttpClient client = new HttpClient();

        internal static IEnumerable<Child> GetChildren()
        {
            return children;
        }

        internal static IEnumerable<Volunteer> GetCoordinators()
        {
            return coordinators;
        }

        internal static Child GetChildById(string id)
        {
            return children.FirstOrDefault(x => x.Id.Equals(id));
        }

        internal static IEnumerable<Case> GetCases()
        {
            return cases;
        }

        internal static void CreateChild(Child child)
        {
            children.Add(child);
        }

        internal static void CreateCase(Case mcase)
        {
            cases.Add(mcase);
        }
    }
}
