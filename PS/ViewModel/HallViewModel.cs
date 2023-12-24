using PS.Model.Entities;
using PS.Model.Services;
using PS.Utilities;
using PS.View.CRUD;
using PS.ViewModel.ViewModel_for_CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PS.ViewModel
{
    public class HallViewModel : ViewModelBase
    {
        private HallService hallService;
        private List<Hall> _halls;

        public List<Hall> Halls
        {
            get { return _halls; }
            set { _halls = value; OnPropertyChanged(nameof(Halls)); }
        }
        public ICommand AddHallCommand { get; set; }

        public ICommand EditHallCommand { get; set; }

        public HallViewModel()
        {
            AddHallCommand = new RelayCommand(CreateHall);
            EditHallCommand = new RelayCommand(EditHall);
            hallService = new HallService();
            Halls = hallService.GetHalls();

        }

        private void CreateHall(object obj)
        {
            AddHall addHall = new AddHall();
            AddHallViewModel viewModel = new AddHallViewModel();
            addHall.DataContext = viewModel;
            addHall.Closed += (s, e) => Halls = hallService.GetHalls();
            addHall.Show();
        }

        private void EditHall(object obj)
        {
            if (obj is Hall hall)
            {
                EditHall editHall = new EditHall();
                EditHallViewModel viewModel = new EditHallViewModel(hall);
                editHall.DataContext = viewModel;
                editHall.Closed += (s, e) =>
                {
                    hallService.UpdateHall(hall);

                    Halls = hallService.GetHalls();
                };
                editHall.Show();

            }


        }
    }
}
