using PS.Model.Entities;
using PS.Model.Services;
using PS.Utilities;
using PS.View.CRUD;
using PS.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace PS.ViewModel.ViewModel_for_CRUD
{
    public class AddHallViewModel:ViewModelBase
    {
        private HallService hallService;
        private string _name;
        private string _description;
        private int _price_for_hour;

        public string Name 
        {
            get { return _name; }
            set { _name = value;OnPropertyChanged(nameof(Name)); }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(nameof(Description)); }
        }
         
        public int Price_for_hour
        {
            get { return _price_for_hour; }
            set { _price_for_hour = value; OnPropertyChanged(nameof(Price_for_hour)); }
        }

        public ICommand CreateHallCommand { get; set; }

        public AddHallViewModel()
        {
            hallService = new HallService();
            CreateHallCommand = new RelayCommand(CreateHall);
            
        }

        private void CreateHall (object obj)
        {
            Hall newhall=new Hall();
            newhall.Name = Name;
            newhall.Description = Description;
            newhall.Price_for_hour= Price_for_hour;

            hallService.AddHall(newhall);

            if (obj is Window window) window.Close();
        }

    }
}
