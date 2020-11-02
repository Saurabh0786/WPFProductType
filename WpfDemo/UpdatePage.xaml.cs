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
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        
        CrudEntities _db = new CrudEntities();
        int id;
        public Update(int ProductCrudid)
        {
            InitializeComponent();
            id = ProductCrudid;
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            ProductCrud updateProductCrud = (from m in _db.ProductCruds
                                            where m.ID == id
                                            select m).Single();
            updateProductCrud.Product_Name = nametextBox.Text;
            updateProductCrud.Remarks = reviewtextBox.Text;
            _db.SaveChanges();
            MainWindow.datagrid.ItemsSource = _db.ProductCruds.ToList();
            this.Hide();
        
        }

        
    }
}
