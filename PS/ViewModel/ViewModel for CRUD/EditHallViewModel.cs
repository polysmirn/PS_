using PS.Model.Entities;
using PS.Model.Services;
using PS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace PS.ViewModel.ViewModel_for_CRUD
{
    public class EditHallViewModel:ViewModelBase
    {
        private HallService hallService;
        private string _name;
        private string _description;
        private int _price_for_hour;

    

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
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

        public ICommand EditHallCommand { get; set; }
        public ICommand DeleteHallCommand { get; set; }

        Hall hall;
        public EditHallViewModel(Hall _hall)
        {
            hallService = new HallService();
            EditHallCommand = new RelayCommand(UpdateHall);
            DeleteHallCommand = new RelayCommand(DeleteHall);
           
            hall = _hall;
             
            Name = hall.Name;
            Description = hall.Description; 
            Price_for_hour=hall.Price_for_hour;
        }

        private void UpdateHall(object obj)
        {
            
            hall.Name = Name;
            hall.Description = Description;
            hall.Price_for_hour = Price_for_hour;

            if (obj is Window window) window.Close();
        }
         private void DeleteHall(object obj) 
         {
            hallService.DeleteHall(hall.Id);

            if (obj is Window window) window.Close();
        }

    }
}

