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
using System.Windows.Navigation;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // ** Declare variable(s)
        private ObservableCollection<SalesPerson> _salesPerson;
        private List<SalesDetails> _salesDetails;

        public MainWindow()
        {
            InitializeComponent();

            // ** Prepare initial data
            this.PrepareData();
        }

        // ** Prepare initial data
        public void PrepareData()
        {
            this._salesPerson = new ObservableCollection<SalesPerson>();
            this._salesPerson = DataLayer.GetSales();
            this.SalesPersonDataGrid.ItemsSource = this._salesPerson;

            this._salesDetails = DataLayer.GetSalesRecords();
        }

        // ** Open a window depending on selected row from datagrid
        private void SalesPersonDataGrid_SelectedCellsChanged(
            object sender, SelectedCellsChangedEventArgs e)
        {
            DataGridRow _dataGridRow = (DataGridRow)this.SalesPersonDataGrid.ItemContainerGenerator
              .ContainerFromIndex(this.SalesPersonDataGrid.Items.IndexOf(this.SalesPersonDataGrid.CurrentItem));

            FrameworkElement _frameworkElement0 = this.SalesPersonDataGrid.Columns[0].GetCellContent(_dataGridRow);
            FrameworkElement _frameworkElement1 = this.SalesPersonDataGrid.Columns[1].GetCellContent(_dataGridRow);
            FrameworkElement _frameworkElement2 = this.SalesPersonDataGrid.Columns[2].GetCellContent(_dataGridRow);

            TextBox _textBox0 = ((DataGridTemplateColumn)this.SalesPersonDataGrid.Columns[0]).CellTemplate
                .FindName("IDTextBox", _frameworkElement0) as TextBox;
            TextBox _textBox1 = ((DataGridTemplateColumn)this.SalesPersonDataGrid.Columns[1]).CellTemplate
                .FindName("FirstNameTextBox", _frameworkElement1) as TextBox;
            TextBox _textBox2 = ((DataGridTemplateColumn)this.SalesPersonDataGrid.Columns[2]).CellTemplate
                .FindName("LastNameTextBox", _frameworkElement2) as TextBox;

            SalesDetailsWindow salesDetailsWindow = new SalesDetailsWindow();
            salesDetailsWindow.IDTextBox.Text = _textBox0.Text;
            salesDetailsWindow.FirstNameTextBox.Text = _textBox1.Text;
            salesDetailsWindow.LastNameTextBox.Text = _textBox2.Text;

            salesDetailsWindow.SalesDetailsDataGrid.ItemsSource = 
                this._salesDetails.Where(s => s.EmployeeID == _textBox0.Text);
            
            salesDetailsWindow.ShowDialog();
            this.Hide();
        }
    }
}
