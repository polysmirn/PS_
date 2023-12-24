using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PS.Utilities;
using PS.View.CRUD;

namespace PS.ViewModel
{
    public class AdminViewModel:ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(nameof(CurrentView)); }
        }

        public ICommand OrdersCommand { get; set; }
        public ICommand HallsCommand { get; set; }
        public ICommand PhotographersCommand { get; set; }
        public ICommand ReportsCommand { get; set; }

        private void Orders(object obj) => CurrentView = new OrderViewModel();
        private void Halls(object obj) => CurrentView = new HallViewModel();
        private void Photographers(object obj) => CurrentView = new PhotographerViewModel();
        private void Reports(object obj) => CurrentView = new ReportsViewModel();

        public AdminViewModel()
        {
            OrdersCommand = new RelayCommand(Orders);
            HallsCommand = new RelayCommand(Halls);
            PhotographersCommand = new RelayCommand(Photographers);
            ReportsCommand = new RelayCommand(Reports);

           
            CurrentView = new OrderViewModel();
        }
    }
}

