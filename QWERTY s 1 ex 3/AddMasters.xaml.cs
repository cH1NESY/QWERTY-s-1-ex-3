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
    /// Логика взаимодействия для AddMasters.xaml
    /// </summary>
    public partial class AddMasters : Page
    {
        QWERTYEntities1 context;
        public AddMasters(QWERTYEntities1 cont)
        {
            InitializeComponent();
            context = cont;
            statusBox.ItemsSource = context.WorkerStatus.ToList();
            flag = true;
        }

        bool flag;
        private void AddSave(object sender, RoutedEventArgs e)
        {
            if (flag == true)
            {
                Worker worker = new Worker()
                {
                    tabNum = Convert.ToInt32(tubnBox.Text),
                    FIO = fioBox.Text,
                    oklad = Convert.ToDecimal(okladBox.Text),
                    percentToRepair = Convert.ToDecimal(percentBox.Text),
                    status =Convert.ToInt32( statusBox.Text),
                    password = passBox.Text
                };
                context.Worker.Add(worker);
                context.SaveChanges();
                NavigationService.Navigate(new MastersPage());
            }
            else 
            {
                context.Worker.Find(worker1.tabNum).FIO = fioBox.Text;
                context.Worker.Find(worker1.tabNum).oklad = Convert.ToDecimal(okladBox.Text);
                context.Worker.Find(worker1.tabNum).percentToRepair =Convert.ToDecimal( percentBox.Text);
                context.Worker.Find(worker1.tabNum).status = Convert.ToInt32( statusBox.Text);
                context.Worker.Find(worker1.tabNum).password = passBox.Text;
                context.SaveChanges();
                NavigationService.Navigate(new MastersPage());
            }
        }
        Worker worker1;
        public AddMasters(QWERTYEntities1 cont, Worker worker)
        {
            InitializeComponent();
            context = cont;
            statusBox.ItemsSource = context.Status.ToList();
            worker1 = worker;

            tubnBox.Text = worker.tabNum.ToString();
            fioBox.Text = worker.FIO;
            okladBox.Text = worker.oklad.ToString();
            percentBox.Text = worker.percentToRepair.ToString();
            statusBox.SelectedItem = worker.status;
            passBox.Text = worker.password;
            flag = false;
        }
    }
}
