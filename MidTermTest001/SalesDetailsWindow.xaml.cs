using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using Test1SalesMS.Model;
/// <summary>
/// ** Student Name     : Harbin Ramo
/// ** Student Number   : 301046044
/// ** Lab Assignment   : MidTermTest001 - WPF
/// ** Date (MM/dd/yyy) : 02/21/2020
/// </summary>
namespace MidTermTest001
{
    /// <summary>
    /// Interaction logic for SalesDetailsWindow.xaml
    /// </summary>
    public partial class SalesDetailsWindow : Window
    {
        // ** Declare variable(s)
        private List<Product> _products;
        private List<SalesDetails> _productOrders;

        public SalesDetailsWindow()
        {
            InitializeComponent();

            // ** Prepare initial data
            this.PrepareData();
            
        }

        // ** Prepare initial data
        public void PrepareData()
        {
            this._products = DataLayer.GetProducts();
            this._productOrders = new List<SalesDetails>();
            this.SalesDetailsDataGrid.ItemsSource = this._productOrders;

            this.LoadProducts(this._products);
        }

        // ** Load Product name to combo box
        private void LoadProducts(List<Product> _product)
        {
            this.ProductNameComboBox.Items.Add("-----");
            this.ProductNameComboBox.SelectedIndex = 0;

            foreach(Product p in _product)
            {
                this.ProductNameComboBox.Items.Add(p.Name);
            }
        }

        // ** Populate items to data grid
        private void PopulateDataGrid()
        {
            this._productOrders.Add(
                new SalesDetails()
                {
                    TransactionID = this.TransactionIDTextBox.Text,
                    Quantity = int.Parse(this.QuantityTextBox.Text),
                    TransactionDate = this.TransactionDateDatePicker.SelectedDate.Value,
                });
        }

        // ** Back to Main window
        private void BacktoMainWindowButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            this.Hide();
        }

        private void AddTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            this.PopulateDataGrid();
        }
    }
}
