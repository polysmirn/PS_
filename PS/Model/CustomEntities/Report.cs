using PS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Model.CustomEntities
{
    public class Report:INotifyPropertyChanged
    {


        private ObservableCollection<OrdersByDate> _orders;
        public ObservableCollection<OrdersByDate> Orders { get => _orders; set { _orders = value; OnPropertyChanged(nameof(Orders)); } }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
    public class OrdersByDate
    {
        public string Date { get; set; }
        public string Time { get; set; }
      
        public string Hall { get; set; }    
        public int Price { get; set; }
    }
}
