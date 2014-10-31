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
using Assignment43.DB;
using Assignment43.Entities;
using Assignment43.NW;
using Assignment43.UI;

namespace Assignment43
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public OrderViewModel OrderViewModel { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            OrderViewModel = new OrderViewModel(new NorthWind(new RepositoryDb()));
            DataContext = OrderViewModel;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var order = (Order) e.AddedItems[0];
            OrderViewModel.Order = order;
            OrderViewModel.OrderDetails = order.Order_Details.ToList();
            OrderViewModel.CustomerName = order.Customer.ContactName;
            OrderViewModel.EmployeeName = order.Employee.FirstName + " " + order.Employee.LastName;
            OrderViewModel.TotalPrice = order.Order_Details.Sum(i => i.UnitPrice * i.Quantity * (1 - (decimal)i.Discount));
        }
    }
}
