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
    /// Логика взаимодействия для applicationPage.xaml
    /// </summary>
    public partial class applicationPage : Page
    {
        QWERTYEntities1 context;
        public applicationPage(QWERTYEntities1 cont)
        {
            InitializeComponent();
            
            context = cont;
            masterBox.ItemsSource = context.Worker.ToList().Where(x => x.Position1.title.Equals("Мастер"));
            typeBox.ItemsSource = context.Type.ToList();
            var clientsList = context.Client.ToList();
            clientsList.Insert(0, new Client() { name = "Добавить нового", Num = 0 });
            clientBox.ItemsSource = clientsList;
            flag = true;
        }
        bool flag;

        private void AppClick(object sender, RoutedEventArgs e)
        {
           
    
                if (flag == true)
                {
                Device device = new Device()
                {
                    id = Convert.ToInt32(idBox.Text),
                    type = (typeBox.SelectedItem as Type).id,
                    model = modBox.Text,
                    damage = damBox.Text,
                    complaint = compBox.Text,
                    master = (masterBox.SelectedItem as Worker).tabNum,
                    client = (clientBox.SelectedItem as Client).Num,
                   
                };
                    context.Device.Add(device);
                    context.SaveChanges();
                    NavigationService.Navigate(new MastersPage());
                    MessageBox.Show("Заявка отправлена!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {

                    context.Device.Find(device1.id).type = (typeBox.SelectedItem as Type).id;
                    context.Device.Find(device1.id).model = modBox.Text;
                    context.Device.Find(device1.id).damage = damBox.Text;
                    context.Device.Find(device1.id).complaint = compBox.Text;
                    context.Device.Find(device1.id).master = (masterBox.SelectedItem as Worker).tabNum;
                    context.Device.Find(device1.id).client = (clientBox.SelectedItem as Client).Num;

                    context.SaveChanges();
                    NavigationService.Navigate(new ordersPage());
                }
                


            
           
         
        }
        Device device1;
        public applicationPage (QWERTYEntities1 cont, Device device)
        {
            InitializeComponent();
            context = cont;
            typeBox.ItemsSource = context.Type.ToList();
            device1 = device;
            masterBox.ItemsSource = context.Worker.ToList().Where(x => x.Position1.title.Equals("Мастер"));
            var clientsList = context.Client.ToList();
            clientsList.Insert(0, new Client() { name = "Добавить нового", Num = 0 });
            clientBox.ItemsSource = clientsList;

            idBox.Text = device.id.ToString();
            typeBox.SelectedItem = device.type;
            modBox.Text = device.model;
            damBox.Text = device.damage;
            compBox.Text = device.complaint;
            masterBox.SelectedItem = device.master;
            clientBox.SelectedItem = device.client;

           
            flag = false;
        }

        public void RefreshData()
        {
            var list = context.Client.ToList();
            if (clientBox.SelectedIndex == 0)
            {
                
                NavigationService.Navigate(new EditClients(context));

            }

           
          
        }

        private void ChangedStatus(object sender, SelectionChangedEventArgs e)
        {
            RefreshData();
        }
        private void ChangedType(object sender, SelectionChangedEventArgs e)
        {
            RefreshData();
        }

        private void ChangedClient(object sender, SelectionChangedEventArgs e)
        {
            RefreshData();
        }
    }
}

                //string fio = fioBox.Text;

                //Worker worker = context.Worker.ToList().Find(x => x.FIO.Equals(fio));

                //if (worker == null)
                //{
                //    MessageBox.Show("Такого пользователя не существует", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                //    NavigationService.Navigate(new EditClients(context));
                //}