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
    /// Логика взаимодействия для ListDevicePart.xaml
    /// </summary>
    public partial class ListDevicePart : Page
    {
        QWERTYEntities1 context;
        TypeDevicePart typeDevicePart;
       

        public ListDevicePart()
        {
            InitializeComponent();
            typeDevicePart = new TypeDevicePart();
            context = new QWERTYEntities1();
            DevicePartTable.ItemsSource = context.DevicePart.ToList();
            
            
           
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
           
            NavigationService.Navigate(new DiagnosticPage(context));

        }
    }
}
