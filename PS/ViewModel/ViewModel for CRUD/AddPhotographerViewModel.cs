using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using PS.Model.Entities;
using PS.Model.Services;
using PS.Utilities;
using System.IO;

namespace PS.ViewModel.ViewModel_for_CRUD
{
    public class AddPhotographerViewModel:ViewModelBase
    {
        private PhotographerService photographerService;
        private string _name;
        private int _price_for_hour;
        private int _experience;
        private ImageSource _phImage;
        private byte[] _imageBytes;
        private string _errorMessage;

        public string Name
        {
            get { return _name; }
            set { _name = value;OnPropertyChanged(nameof(Name)); }
        }

        public int Price_for_hour
        {
           get { return _price_for_hour;}
           set { _price_for_hour = value; OnPropertyChanged(nameof(Price_for_hour)); }

        }

        public int Experience
        {
            get { return _experience; }
            set { _experience = value; OnPropertyChanged(nameof(Experience)); }

        }
        public ImageSource PhImage
        {
            get { return _phImage; }
            set { _phImage = value; OnPropertyChanged(nameof(PhImage)); }
        }
        public byte[] ImageBytes
        {
            get { return _imageBytes; }
            set { _imageBytes = value; OnPropertyChanged(nameof(ImageBytes)); }
        }
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
        }
        public ICommand CreatePhotographerCommand { get; set; }
        public ICommand AddImageCommand { get; set; }
        private void AddImage(object obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(openFileDialog.FileName));
                PhImage = bitmap;
                ImageBytes = File.ReadAllBytes(openFileDialog.FileName);
            }
        }
        public AddPhotographerViewModel()
        {
            photographerService = new PhotographerService();
            AddImageCommand = new RelayCommand(AddImage);
            CreatePhotographerCommand = new RelayCommand(CreatePhotographer);
        }

        private void CreatePhotographer(object obj)
        {
            if (Experience ==null||
                Price_for_hour==null||
                Name == null ||
                ImageBytes == null) ErrorMessage = "Заполнены не все поля";
            else
            {
                 Photographer newphotographer = new Photographer();
                 newphotographer.Name = Name;
                 newphotographer.Experience = Experience;
                 newphotographer.Price_for_hour = Price_for_hour;
                newphotographer.Image=ImageBytes;

                photographerService.AddPhotographer(newphotographer);

                  if (obj is Window window) window.Close();
            }
                
        }
    }
}
