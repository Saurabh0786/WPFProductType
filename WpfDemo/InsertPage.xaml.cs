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
using System.Windows.Shapes;

namespace WpfDemo
{
    /// <summary>
    /// Interaction logic for Insert.xaml
    /// </summary>
    public partial class Insert : Window
    {
        CrudEntities _db = new CrudEntities();
        public Insert()
        {
            InitializeComponent();
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
           ProductCrud newProductCrud = new ProductCrud()
            {
                Product_Name = nametextBox.Text,
                Remarks = remarkstextBox.Text
 };

            _db.ProductCruds.Add(newProductCrud);
            _db.SaveChanges();
            MainWindow.datagrid.ItemsSource = _db.ProductCruds.ToList();
            this.Hide();
        }
    }
}
