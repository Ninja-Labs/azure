using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace WorldCupDevCamp.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        public ShellViewModel()
        {
            MenuItems.Add(new MenuItemViewModel() { Icon = Symbol.People, Title = "Equipos", PageType = typeof(TeamsPage) });
            MenuItems.Add(new MenuItemViewModel() { Icon = Symbol.Add, Title = "Crear Equipo", PageType = typeof(CreateTeamPage) });
            MenuItems.Add(new MenuItemViewModel() { Icon = Symbol.ReportHacked, Title = "Grupos", PageType = typeof(GroupsPage) });
        }

        public ObservableCollection<MenuItemViewModel> MenuItems { get; set; } = new ObservableCollection<MenuItemViewModel>();        

        private bool isSplitViewPaneOpen;

        public bool IsSplitViewPaneOpen
        {
            get { return this.isSplitViewPaneOpen; }
            set { Set(ref this.isSplitViewPaneOpen, value); }
        }

        private MenuItemViewModel selectedMenuItem;

        public MenuItemViewModel SelectedMenuItem
        {
            get { return this.selectedMenuItem; }
            set
            {
                if (Set(ref this.selectedMenuItem, value))
                {
                    RaisePropertyChanged("SelectedPageType");
                    this.IsSplitViewPaneOpen = false;
                }
            }
        }

        public Type SelectedPageType
        {
            get
            {
                return this.selectedMenuItem?.PageType;
            }
            set
            {
                this.SelectedMenuItem = this.MenuItems.FirstOrDefault(m => m.PageType == value);
            }
        }

        public ICommand ToggleSplitViewPaneCommand
        {
            get
            {
                return new RelayCommand(() => this.IsSplitViewPaneOpen = !this.IsSplitViewPaneOpen);
            }
        }
    }
}
