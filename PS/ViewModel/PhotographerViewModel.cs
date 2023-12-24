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
     public class PhotographerViewModel:ViewModelBase
    {
        private PhotographerService phService;
        private List<Photographer> _phs;

        public List<Photographer> Photographers
        {
            get { return _phs; }
            set { _phs = value; OnPropertyChanged(nameof(Photographers)); }
        }
        public ICommand AddPhotographerCommand { get; set; }

        public ICommand EditPhotographerCommand { get; set; }

        public PhotographerViewModel()
        {
            AddPhotographerCommand = new RelayCommand(CreatePhotographer);
            EditPhotographerCommand = new RelayCommand(EditPhotographer);
            phService = new PhotographerService();
            Photographers = phService.GetPhotographers();

        }

        private void CreatePhotographer(object obj)
        {
            AddPhotographer addPhotographer = new AddPhotographer();
            AddPhotographerViewModel viewModel = new AddPhotographerViewModel();
            addPhotographer.DataContext = viewModel;
            addPhotographer.Closed += (s, e) => Photographers = phService.GetPhotographers();
            addPhotographer.Show();
        }

        private void EditPhotographer(object obj)
        {
            if (obj is Photographer photographer)
            {
                EditPhotographer editPhotographer = new EditPhotographer();
                EditPhotographerViewModel viewModel = new EditPhotographerViewModel(photographer);
                editPhotographer.DataContext = viewModel;
                editPhotographer.Closed += (s, e) =>
                {
                    phService.UpdatePhotographer(photographer);

                    Photographers = phService.GetPhotographers();
                };
                editPhotographer.Show();

            }


        }
    }
}

