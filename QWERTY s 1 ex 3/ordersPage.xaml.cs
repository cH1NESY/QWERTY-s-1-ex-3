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
    /// Логика взаимодействия для ordersPage.xaml
    /// </summary>
    public partial class ordersPage : Page
    {
        QWERTYEntities1 context;
        public ordersPage()
        {
            InitializeComponent();
            context = new QWERTYEntities1();
            ordersTable.ItemsSource = context.Device.ToList();

            var typeList = context.Type.ToList();
            typeList.Insert(0, new Type() { Title = "все", id = 0 });
            typeBox.ItemsSource = typeList;
          
        }
        public void RefreshData()
        {
            var list = context.Device.ToList();
            if (typeBox.SelectedIndex > 0)
            {
                Type ty = typeBox.SelectedItem as Type;
                list = list.Where(x => x.Type1 == ty).ToList();

            }

            if (!string.IsNullOrWhiteSpace(modelBox.Text))
            {
                list = list.Where(x => x.model.ToLower().Contains(modelBox.Text.ToLower())).ToList();
            }
            ordersTable.ItemsSource = list;
        }

        private void Changedname(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        private void ChangedType(object sender, SelectionChangedEventArgs e)
        {
            RefreshData();
        }
    }
}
