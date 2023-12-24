using PS.Model.Entities;
using PS.Model.Services;
using PS.Utilities;
using PS.View;
using PS.View.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PS.ViewModel.ViewModel_for_CRUD
{
    public class EditOrderViewModel : ViewModelBase
    {
        private OrderService orderService;

        private DateTime _date = DateTime.Now;



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


        public TimeSpan startTime = new TimeSpan(9, 0, 0);
        public TimeSpan endTime = new TimeSpan(19, 0, 0);
        private ObservableCollection<Hall> halls;
        private ObservableCollection<Photographer> photographers;
        private ObservableCollection<Order> orders;

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
        public ObservableCollection<Hall> Halls
        {
            get { return halls; }
            set { halls = value; OnPropertyChanged(nameof(Halls)); }
        }
        public ObservableCollection<Photographer> Photographers
        {
            get { return photographers; }
            set { photographers = value; OnPropertyChanged(nameof(Photographers)); }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged(nameof(Date)); }
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
        public ICommand UpdateOrderCommand { get; set; }
        public ICommand EditOrderCommand { get; set; }
        public ICommand AddOrderCommand { get; set; }
        HallService hallService = new HallService();
        Order order;
        public EditOrderViewModel(Order _order)
        {
            orderService = new OrderService();
            EditOrderCommand = new RelayCommand(UpdateOrder, CanCreateOrder);

            order = _order;
            Halls = new ObservableCollection<Hall>(orderService.GetHalls());
            orders=new ObservableCollection<Order>(orderService.GetOrders());
            Photographers = new ObservableCollection<Photographer>(orderService.GetPhotos());
            //Allhalls = orderService.GetHalls();
            //_allorders = orderService.GetOrders();
            //_allph = orderService.GetPhotos();
            Times = new ObservableCollection<TimeSpan>();
            for (int hour = 9; hour <= 19; hour++)
            {
                Times.Add(new TimeSpan(hour, 0, 0));
            }
            order = orderService.GetOrderById(order.Id);
            Name = order.Client.Name;
            Email = order.Client.Email;
            Number = order.Client.Number;
            Date = order.Date;
            StartTime = order.StartTime;
            EndTime = order.EndTime;
            Hall = order.HallId;
            if (Photographer!=null)
            Photographer = order.PhotographerId;

            orders.Remove(order);
            orderService.Save();

        }

        private bool CanCreateOrder(object arg)
        {
            if (Date < DateTime.Now)

                return false;

            else if ((EndTime > StartTime && !CompareTimes()))
                return true;
            return false;

        }


        private bool CompareTimes()
        {
            var time = orders.FirstOrDefault(x => x.StartTime == StartTime && x.EndTime == EndTime && x.HallId == Hall && x.Date == Date);
            return time != null;
        }

        private void UpdateOrder(object obj)
        {
            order.Client.Name = Name;
            order.Client.Email = Email;
            order.Client.Number = Number;
            order.Date = Date;
            order.StartTime = StartTime;
            order.EndTime = EndTime;
            order.HallId = Hall;
            if (Photographer != null)
                order.PhotographerId = Photographer;


            var h = hallService.GetHallById(Hall);
            if (h != null)
            {

                var interval = Convert.ToInt32((EndTime - StartTime).TotalHours);
                order.Price = h.Price_for_hour * interval;
            }

            
            orderService.Save();
         
            
            if (obj is Window window) window.Close();

        }
    }
}
