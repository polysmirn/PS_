using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.OData.Edm;
using PS.Model.Entities;
using PS.Model.Services;
using PS.Utilities;
using PS.View;
using PS.View.CRUD;
using PS.View.Pages;
using PS.ViewModel.ViewModel_for_CRUD;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace PS.ViewModel
{
    public class OrderViewModel:ViewModelBase
    {
        private OrderService orderService;
       

     
        private ObservableCollection<Order> _orders;
        public ObservableCollection<Order> Orders
        {
            get { return _orders; }
            set { _orders = value; OnPropertyChanged(nameof(Orders)); }
        }


        public ICommand AddOrderCommand { get; set; }
        public ICommand DeleteOrderCommand { get; set; }
        public ICommand EditOrderCommand { get; set; }

     
        public OrderViewModel()
        {
            

            AddOrderCommand = new RelayCommand(CreateOrder);
            DeleteOrderCommand= new RelayCommand(DeleteOrder);
            EditOrderCommand= new RelayCommand(EditOrder);
            orderService = new OrderService();

            Orders=orderService.GetOrders();
            
            
      
                 
        }
      
        private void CreateOrder(object obj)
        {
            AddOrder addOrder = new AddOrder();
            AddOrderViewModel viewModel = new AddOrderViewModel();
            addOrder.DataContext = viewModel;
            addOrder.Closed += (s, e) =>
            {
                orderService = new OrderService();
                Orders = orderService.GetOrders();
                OnPropertyChanged(nameof(Orders));
            };
            addOrder.Show();
           
        }
        private void DeleteOrder(object obj)
        {
            if (obj is Order order)
            {
                OnPropertyChanged(nameof(Orders));
                //orderService.Delete(order.Id);
                //orders = orderService.GetOrders();
            }
        }
        EditOrder editOrder;
        private void EditOrder(object obj)
        {
            if (obj is Order order)
            {

                editOrder = new EditOrder();
                EditOrderViewModel viewModel = new EditOrderViewModel(order);
                editOrder.DataContext = viewModel;
                editOrder.Closed += (s, e) =>
                {
                   
                    OnPropertyChanged(nameof(Orders));
                };
                editOrder.Show();

            }
        }
    }
}
