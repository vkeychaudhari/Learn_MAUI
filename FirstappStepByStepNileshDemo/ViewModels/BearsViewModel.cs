using FirstappStepByStepNileshDemo.Data;
using FirstappStepByStepNileshDemo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FirstappStepByStepNileshDemo.ViewModels
{
    public class BearsViewModel
    {
        public ObservableCollection<Animal> SearchResults { get; private set; }

        public ICommand SearchCommand => new Command<string>(SearchItems);

        void SearchItems(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                SearchResults = null;
            }
            else
            {
                var filteredItems = BearData.Bears
                    .Where(bear => bear.Name.ToLower()
                    .Contains(query.ToLower()))
                    .ToList();
                SearchResults = new ObservableCollection<Animal>(filteredItems);
            }
        }
    }
}
