using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCupDevCamp.ViewModels
{
    public class TeamViewModel : ViewModelBase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Flag { get; set; }
    }
}
