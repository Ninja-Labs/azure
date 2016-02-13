using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WorldCupDevCamp.ViewModels;

namespace WorldCupDevCamp.Services
{
    class ApiService
    {
        internal async Task<List<TeamViewModel>> GetTeamsAsync()
        {
            var serviceUrl = "http://worldcupdevcamp.azurewebsites.net/tables/teams";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");
                var response = await client.GetAsync(new Uri(serviceUrl));
                string result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<TeamViewModel>>(result);
            }
        }

        internal async Task SaveTeamAsync(TeamViewModel team)
        {
            var serviceUrl = "http://worldcupdevcamp.azurewebsites.net/tables/teams";

            team.Id = Guid.NewGuid().ToString();

            using (var client = new HttpClient())
            {
                var bodyRequest = JsonConvert.SerializeObject(team);
                client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");
                var response = await client.PostAsync(serviceUrl, new StringContent(bodyRequest, System.Text.Encoding.UTF8, "application/json"));
                string result = await response.Content.ReadAsStringAsync();
            }
        }
    }
}
