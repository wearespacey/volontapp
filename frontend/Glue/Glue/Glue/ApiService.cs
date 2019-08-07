using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Glue.Services
{
    public static class ApiService
    {
        static HttpClient client = new HttpClient();

        public static async Task<IEnumerable<Model.Display>> GetAllDisplaysAsync()
        {
            return new List<Model.Display>()
            {
                new Model.Display(){Id="test1" },
                new Model.Display(){Id="test2" },
                new Model.Display(){Id="test3" },
                new Model.Display(){Id="test4" }
            };
            HttpResponseMessage response = await client.GetAsync("api/display");
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var displays = JsonConvert.DeserializeObject<IEnumerable<Model.Display>>(res);
                return displays;
            }
            return new List<Model.Display>();
        }

        public static async Task<Model.Display> GetDisplayByIdAsync(string id)
        {
            HttpResponseMessage response = await client.GetAsync($"api/display/{id}");
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var display = JsonConvert.DeserializeObject<Model.Display>(res);
                return display;
            }
            return new Model.Display();
        }

        public static async Task<IEnumerable<Model.Volunteer>> GetAllVolunteersAsync()
        {
            return new List<Model.Volunteer>()
            {
                new Model.Volunteer(){Id="test1", FirstName="Tobias", Surname="Jetzen" },
                new Model.Volunteer(){Id="test2", FirstName="Tinael", Surname="Devresse" },
                new Model.Volunteer(){Id="test3", FirstName="Stephanie", Surname="Bemelmans" },
                new Model.Volunteer(){Id="test4", FirstName="David", Surname="Servais"}
            };
            HttpResponseMessage response = await client.GetAsync("api/display");
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var displays = JsonConvert.DeserializeObject<IEnumerable<Model.Volunteer>>(res);
                return displays;
            }
            return new List<Model.Volunteer>();
        }
    }
}
