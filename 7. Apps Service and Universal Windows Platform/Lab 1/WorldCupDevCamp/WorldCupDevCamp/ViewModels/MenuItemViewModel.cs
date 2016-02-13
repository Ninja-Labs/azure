using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace WorldCupDevCamp.ViewModels
{
    public class MenuItemViewModel : ViewModelBase
    {
        public string Title { get; set; }
        public Symbol Icon { get; set; }

        public char SymbolAsChar
        {
            get
            {
                return (char)this.Icon;
            }
        }

        public Type PageType { get; set; }

        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand(Navigate);
            }
        }

        private void Navigate()
        {
            App.RootFrame.Navigate(this.PageType);
        }
    }
}
