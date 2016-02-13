using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCupDevCamp.Services;

namespace WorldCupDevCamp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        ApiService apiService;

        public MainViewModel()
        {
            apiService = new ApiService();
            Teams = new ObservableCollection<TeamViewModel>();
            NewTeam = new TeamViewModel();

            //Teams.Add(new TeamViewModel() { Name = "Colombia", Flag= "http://rs575.pbsrc.com/albums/ss196/laurasgonzalez/ColombiaFlag.jpg~c200" });
            LoadData();
        }
        public TeamViewModel NewTeam { get; set; }

        public ObservableCollection<TeamViewModel> Teams { get; set; }

        public async void LoadData()
        {
            this.Teams.Clear();
            var teams = await apiService.GetTeamsAsync();

            foreach (var item in teams)
            {
                this.Teams.Add(item);
            }
        }
    }
}
