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
    /// Логика взаимодействия для DiagnosticPage.xaml
    /// </summary>
    public partial class DiagnosticPage : Page
    {
        QWERTYEntities1 context;

        public DiagnosticPage(QWERTYEntities1 cont)
        {
            InitializeComponent();
            context = cont;

            statusBox.ItemsSource = context.Status.ToList();
            masterBox.ItemsSource = context.Worker.ToList().Where(x => x.Position1.title.Equals("Мастер"));
            typeBox.ItemsSource = context.Type.ToList();

        }

        private void refClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Оборудование будет возвращено клиенту.", "Подтверждение", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                MessageBox.Show("Оборудование отправлено на возврат!", "Успешно!");
            }
        }

        private void repClick(object sender, RoutedEventArgs e)
        {
            context.Device.Find(device1.id).type = (typeBox.SelectedItem as Type).id;
            context.Device.Find(device1.id).model = modBox.Text;
            context.Device.Find(device1.id).complaint = compBox.Text;
            context.Device.Find(device1.id).master = (masterBox.SelectedItem as Worker).tabNum;
            


            context.SaveChanges();
            NavigationService.Navigate(new ordersPage());
            MessageBoxResult res = MessageBox.Show("Оборудование будет отправлено на ремонт.", "Подтверждение", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                MessageBox.Show("Оборудование отправлено на ремонт!", "Успешно!");
            }
        }
        Device device1;
        public DiagnosticPage(QWERTYEntities1 cont, Device device)
        {
            InitializeComponent();
            context = cont;
            statusBox.ItemsSource = context.Status.ToList();
            masterBox.ItemsSource = context.Worker.ToList().Where(x => x.Position1.title.Equals("Мастер"));
            typeBox.ItemsSource = context.Type.ToList();
            device1 = device;

            idBox.Text = device.id.ToString();
            typeBox.SelectedItem = device.Type1;
            modBox.Text = device.model;
            compBox.Text = device.complaint;
            masterBox.SelectedItem = device.WorkerMasters;
            statusBox.SelectedItem = device.RepairStatus;



        }

        private void reClick(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new ListDevicePart());
        }
    }

}
