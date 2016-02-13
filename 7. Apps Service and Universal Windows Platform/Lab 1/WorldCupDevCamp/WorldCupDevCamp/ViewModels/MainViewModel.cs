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

            LoadData();
        }

        public ObservableCollection<TeamViewModel> Teams { get; set; }

        private void LoadData()
        {
            throw new NotImplementedException();
        }
    }
}
