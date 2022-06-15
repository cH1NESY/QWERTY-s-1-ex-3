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
    /// Логика взаимодействия для MastersPage.xaml
    /// </summary>
    public partial class MastersPage : Page
    {
        QWERTYEntities context;
        public MastersPage()
        {
            InitializeComponent();
            context = new QWERTYEntities();
            mastersTable.ItemsSource = context.Worker.ToList();

            var statusList = context.WorkerStatus.ToList();
            statusList.Insert(0, new WorkerStatus() { Title = "все", id = 0});
            statusBox.ItemsSource = statusList;
        }

        public void RefreshData()
        {
            var list = context.Worker.ToList();
            if (statusBox.SelectedIndex > 0)
            {
                WorkerStatus st = statusBox.SelectedItem as WorkerStatus;
                list = list.Where(x => x.WorkerStatus == st).ToList();

            }

            if (!string.IsNullOrWhiteSpace(fioBox.Text))
            {
                list = list.Where(x => x.FIO.ToLower().Contains(fioBox.Text.ToLower())).ToList();
            }
            mastersTable.ItemsSource = list;
        }

        private void ChangedStatus(object sender, SelectionChangedEventArgs e)
        {
            RefreshData();
        }
        private void ChangedFio(object sender, TextChangedEventArgs e)
        {
            RefreshData();
        }


        private void AddWorker(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddMasters(context));
        }

        private void EditMasters(object sender, RoutedEventArgs e)
        {
            Worker worker = mastersTable.SelectedItem as Worker;
            NavigationService.Navigate(new AddMasters(context, worker));
        }

        private void DeleteMasters(object sender, RoutedEventArgs e)
        {
           MessageBoxResult res = MessageBox.Show("Вы уверены, что хотите удалить мастера?", "Подтверждение", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    Worker worker = mastersTable.SelectedItem as Worker;
                    context.Worker.Remove(worker);
                    context.SaveChanges();
                    NavigationService.Navigate(new MastersPage());
                }
                catch 
                {
                    MessageBox.Show("Ошибка!");
                }
            }
        }

        
        
    }
}
