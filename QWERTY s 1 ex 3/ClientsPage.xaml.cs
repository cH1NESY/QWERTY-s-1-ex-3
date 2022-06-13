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

namespace QWERTY_s_1_ex_3
{
    /// <summary>
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        QWERTYEntities1 context;
        public ClientsPage()
        {
            InitializeComponent(); 
            context = new QWERTYEntities1();
            clientsTable.ItemsSource = context.Client.ToList();

        }
        public void RefreshData()
        {
            var list = context.Client.ToList();

            if (string.IsNullOrWhiteSpace(nameBox.Text))
            {
                list = list.Where(x => x.name.ToLower().Contains(nameBox.Text.ToLower())).ToList();
            }
            clientsTable.ItemsSource = list;
        }

        private void ChangedName(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }
    }
}
