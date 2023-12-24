
using PS.Model.Entities;
using PS.Model.Services;
using PS.Utilities;
using PS.View.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PS.ViewModel.ViewModel_for_CRUD
{
    public class AddOrderViewModel : ViewModelBase
    {
        private OrderService orderService;

        private DateTime _date=DateTime.Now;
        
        
       
        private string _email;
        private string _name;
        private string _number;
        private int _hall;
        private int _status;
        private TimeSpan _startTime;
        private int _price;
        private TimeSpan _endtime;
        private int hall;
        private int? _photographer;
    
    
        public ObservableCollection<TimeSpan> Times { get; set; }
  

        public TimeSpan startTime=new TimeSpan(9,0,0);
        public TimeSpan endTime = new TimeSpan(19, 0, 0);
        private ObservableCollection<Photographer> _allph;

        //private List<Photographer> _allph;

        private ObservableCollection<Hall> _allhalls;
      
        private ObservableCollection<Order> _allorders;
        
    
        public int? Photographer
        {
            get { return _photographer; }
            set { _photographer = value; OnPropertyChanged(nameof(Photographer)); }
        }
  
        public int Hall
        {
            get { return _hall; }
            set { _hall = value; OnPropertyChanged(nameof(Hall)); }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }
        public string Number
        {
            get { return _number; }
            set { _number = value; OnPropertyChanged(nameof(Number)); }
        }
        public ObservableCollection<Photographer> Allph
        { 
            get { return _allph; }
            set { _allph = value; OnPropertyChanged(nameof(Allph)); }
        }
        public ObservableCollection<Hall> Allhalls
        {
            get { return _allhalls; }
            set { _allhalls = value; OnPropertyChanged(nameof(Allhalls)); }
        }
        public DateTime Date
        {
            get { return _date; }
            set { _date= value; OnPropertyChanged(nameof(Date)); }
        }
        public TimeSpan StartTime
        {
            get { return _startTime; }
            set { _startTime = value; OnPropertyChanged(nameof(StartTime)); }
        }
        public TimeSpan EndTime
        {
            get { return _endtime; }
            set { _endtime = value; OnPropertyChanged(nameof(EndTime)); }
        }
        public int Price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged(nameof(Price)); }
        }
        public ICommand SelectHallCommand { get; set; }
        public ICommand SelectSizesCommand { get; set; }
        public ICommand AddOrderCommand { get; set; }
        HallService hallService=new HallService();
        public AddOrderViewModel()
        {
            orderService = new OrderService();
            AddOrderCommand = new RelayCommand(CreateOrder, CanCreateOrder);
            Allhalls = orderService.GetHalls();
            _allorders = orderService.GetOrders();
            _allph = orderService.GetPhotos();
            Times =new ObservableCollection<TimeSpan>();
            for (int hour = 9; hour <= 19; hour++)
            {
                Times.Add(new TimeSpan(hour, 0, 0));
            }
          
        }

        private bool CanCreateOrder(object arg)
        {
            if (Date < DateTime.Now)

                return false;

            else if ((EndTime>StartTime && !CompareTimes()))
                return true;
            return false;

        }


        private bool CompareTimes()
        {
            var time = _allorders.FirstOrDefault(x => x.StartTime == StartTime && x.EndTime==EndTime && x.HallId == Hall && x.Date == Date);
            return time != null;
        }
        
        private void CreateOrder(object obj)
        {
            Order neworder =new Order();
            neworder.Client = new Client();
            
            neworder.Client.Name = Name;
            neworder.Client.Email = Email;
            neworder.Client.Number= Number;
            neworder.Date = Date;
            neworder.StartTime = StartTime;
            neworder.EndTime = EndTime;
            neworder.HallId = Hall;
            neworder.PhotographerId = Photographer;
            var h =hallService.GetHallById(Hall);
            if (h != null)
            {
               
                var interval = Convert.ToInt32((EndTime - StartTime).TotalHours);
                neworder.Price = h.Price_for_hour*interval;
            }

           
           
            
            
            
            //neworder.StatusId = Status;

            orderService.AddOrder(neworder);
            

            if (obj is Window window) window.Close();
        }
    }
}

