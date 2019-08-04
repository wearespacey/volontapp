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
        //static List<Child> children = new List<Child>()
        //{
        //    new Child() { Id = "1", FirstName = "Bernd", LastName = "Bibo"},
        //    new Child() { Id = "2", FirstName = "Friedo", LastName = "Bibo"},
        //    new Child() { Id = "3", FirstName = "Rebel", LastName = "Bibo"},
        //    new Child() { Id = "4", FirstName = "Hans", LastName = "Bibo"}
        //};

        //static List<Case> cases = new List<Case>()
        //{
        //    new Case() { Id = "c1", ChildId = "2"},
        //    new Case() { Id = "c2", ChildId = "2"},
        //    new Case() { Id = "c3", ChildId = "1"},
        //    new Case() { Id = "c4", ChildId = "3"}
        //};

        static List<Volunteer> coordinators = new List<Volunteer>()
        {
            new Volunteer() { Id = "v1", FirstName = "Volo"},
            new Volunteer() { Id = "v2", FirstName = "voloho"},
            new Volunteer() { Id = "v3", FirstName = "trioll"},
            new Volunteer() { Id = "v4", FirstName = "yeet"}
        };

        static HttpClient client = new HttpClient();
        static string apiUrl = "https://volontapp.azurewebsites.net/api/v1";

        internal static async Task<IEnumerable<Child>> GetChildrenAsync()
        {
            HttpResponseMessage response = await client.GetAsync($"{apiUrl}/child");
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var children = JsonConvert.DeserializeObject<IEnumerable<Child>>(res);
                return children;
            }
            return null;
        }

        internal static async Task<Child> GetChildByIdAsync(string id)
        {
            HttpResponseMessage response = await client.GetAsync($"{apiUrl}/child/{id}");
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var child = JsonConvert.DeserializeObject<Child>(res);
                return child;
            }
            return null;
        }

        internal static async Task<IEnumerable<Coordinator>> GetCoordinatorsAsync()
        {
            HttpResponseMessage response = await client.GetAsync($"{apiUrl}/coordinator/");
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var coords = JsonConvert.DeserializeObject<IEnumerable<Coordinator>>(res);
                return coords;
            }
            return null;
        }

        internal static async Task<IEnumerable<Case>> GetCasesAsync()
        {
            HttpResponseMessage response = await client.GetAsync($"{apiUrl}/case");
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var cases = JsonConvert.DeserializeObject<IEnumerable<Case>>(res);
                foreach (var c in cases)
                {
                    c.Child = await GetChildByIdAsync(c.ChildId);
                    c.Coordinator = await GetCoordinatorByIdAsync(c.CoordinatorId);
                }
                return cases;
            }
            return null;
        }

        private static async Task<Coordinator> GetCoordinatorByIdAsync(string coordinatorId)
        {
            HttpResponseMessage response = await client.GetAsync($"{apiUrl}/coordinator/{coordinatorId}");
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var coordi = JsonConvert.DeserializeObject<Coordinator>(res);
                return coordi;
            }
            return null;
        }

        internal static async Task<Case> GetCaseByIdAsync(string id)
        {
            HttpResponseMessage response = await client.GetAsync($"{apiUrl}/case/{id}");
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var mcase = JsonConvert.DeserializeObject<Case>(res);
                return mcase;
            }
            return null;
        }

        internal static async Task CreateCaseAsync(Case mcase)
        {
            var sered = JsonConvert.SerializeObject(mcase);
            var content = new StringContent(sered);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await client.PostAsync($"{apiUrl}/case", content);
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
            }
        }

        internal static async Task CreateChildAsync(Child child)
        {
            var sered = JsonConvert.SerializeObject(child);
            var content = new StringContent(sered);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await client.PostAsync($"{apiUrl}/child", content);
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var newchild = JsonConvert.DeserializeObject<Case>(res);
            }
        }
    }
}
