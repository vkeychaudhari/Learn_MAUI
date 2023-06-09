﻿using FirstappStepByStepNileshDemo.Data;
using FirstappStepByStepNileshDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FirstappStepByStepNileshDemo.ViewModels
{
    [QueryProperty("MonkeyName", "name")]
    public class MonkeyDetailViewModel : INotifyPropertyChanged
    {
        public string MonkeyName
        {
            set
            {
                Animal monkey = MonkeyData.Monkeys.FirstOrDefault(m => m.Name == Uri.UnescapeDataString(value));

                if (monkey != null)
                {
                    Name = monkey.Name;
                    Location = monkey.Location;
                    Details = monkey.Details;
                    ImageUrl = monkey.ImageUrl;
                    OnPropertyChanged("Name");
                    OnPropertyChanged("Location");
                    OnPropertyChanged("Details");
                    OnPropertyChanged("ImageUrl");
                }
            }
        }

        public string Name { get; set; }
        public string Location { get; private set; }
        public string Details { get; private set; }
        public string ImageUrl { get; private set; }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
