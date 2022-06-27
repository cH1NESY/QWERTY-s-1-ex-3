using System;
using System.Collections.Generic;
using System.IO;
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

namespace QWERTY_s_1_ex_3
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        MainWindow window1;
        public Window2(Worker worker, MainWindow window)
        {
            InitializeComponent();
            
            myFrame.Navigate(new ClientsPage());
            if (worker.position == 1)
            {
                MastersBut.Visibility = Visibility.Collapsed;
                ClientsBut.Visibility = Visibility.Collapsed;
               
                
            }
            window.Visibility = Visibility.Collapsed;
            window1 = window;
        }

        private void MastersClick(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new MastersPage());
        }

        private void OrdersClick(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new ordersPage());
        }

        private void ClientsClick(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new ClientsPage());
        }

        private void DownloadPictures()
        {
            QWERTYEntities1 context = new QWERTYEntities1();
            List <TypeDevicePart> typeDeviceParts = context.TypeDevicePart.ToList();
            
            foreach (var item in typeDeviceParts)
            {
                item.image = File.ReadAllBytes(@"C:\QWERTYPicture\" + item.id + ".jpg");
            }
            context.SaveChanges();
        }

        private void DevicePartClick(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new DevicePartPage());
        }

        private void RepairClick(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new RepairPage());
        }

        private void ClosedWindow(object sender, EventArgs e)
        {
            window1.Close();
        }

        private void DiagClick(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new DiagnosticPage());
        }
    }
}
