using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using WorldCupDevCamp.Utils;
using WorldCupDevCamp.ViewModels;

namespace WorldCupDevCamp.Converters
{
    public class ItemsToKeyedListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var all = value as ObservableCollection<TeamViewModel>;
            var result = new List<KeyedList<string, TeamViewModel>>();

            var group = from i in all
                        orderby i.Name
                        group i by i.Group;

            foreach (var item in group)
            {
                var itemsByKey = all.Where(a => a.Group == item.Key).ToList();
                result.Add(new KeyedList<string, TeamViewModel>(item.Key, itemsByKey));
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
