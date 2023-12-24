using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PS.Model.Data;
using PS.Model.Entities;
using PS.ViewModel.ViewModel_for_CRUD;

namespace PS.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class Orders : UserControl
    {
        PScontext context;
        public Orders()
        {
            InitializeComponent();
         
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //OrderDataGrid.Items.Refresh();
           
        }
    }
}
