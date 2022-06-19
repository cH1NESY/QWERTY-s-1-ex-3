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
    /// Логика взаимодействия для DevicePartPage.xaml
    /// </summary>
    public partial class DevicePartPage : Page
    {
        QWERTYEntities1 context;
        public DevicePartPage()
        {
            InitializeComponent();
            context = new QWERTYEntities1();
            DevicePartListView.ItemsSource = context.TypeDevicePart.ToList();
        }

        private void ClickToListItem(object sender, MouseButtonEventArgs e)
        {
            TypeDevicePart typeDevicePart = (sender as Grid).DataContext as TypeDevicePart;
            NavigationService.Navigate(new DevicePartPage1(context, typeDevicePart));
        }
    }
}
