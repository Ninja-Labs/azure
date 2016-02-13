using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorldCupDevCamp.Services;

namespace WorldCupDevCamp.ViewModels
{
    public class TeamViewModel : ViewModelBase
    {
        ApiService apiService;

        public TeamViewModel()
        {
            apiService = new ApiService();
            Group = "SIN GRUPO";
        }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("flag")]
        public string Flag { get; set; }

        [JsonIgnore]
        public string Group { get; set; }
        [JsonIgnore]
        public ICommand SaveCommand
        { 
            get
            {
                return new RelayCommand(Save);
            }
        }

        private async void Save()
        {
            await apiService.SaveTeamAsync(this);
            App.Main.LoadData();
            App.RootFrame.Navigate(typeof(TeamsPage));
        }
    }
}
