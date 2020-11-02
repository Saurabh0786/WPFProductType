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

namespace WpfDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CrudEntities _db = new CrudEntities();
        public static DataGrid datagrid;
        public MainWindow()
        {
            InitializeComponent();
            Load();
        }
        
        private void Load()
        {
            myDataGrid.ItemsSource = _db.ProductCruds.ToList();
            datagrid = myDataGrid;
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            Insert Ipage = new Insert();
            Ipage.ShowDialog();
        }

       

        private void updateBtn_Click_1(object sender, RoutedEventArgs e)
        {
            int id = (myDataGrid.SelectedItem as ProductCrud).ID;
            Update Upage = new Update(id);
            Upage.ShowDialog();
        }

        private void deleteBtn_Click_1(object sender, RoutedEventArgs e)
        {
            int id = (myDataGrid.SelectedItem as ProductCrud).ID;
            var deleteProductCrud = _db.ProductCruds.Where(m => m.ID == id).Single();
            _db.ProductCruds.Remove(deleteProductCrud);
            _db.SaveChanges();
            myDataGrid.ItemsSource = _db.ProductCruds.ToList();
        }

       
    }
}
