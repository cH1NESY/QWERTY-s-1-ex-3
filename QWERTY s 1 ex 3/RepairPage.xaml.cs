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
    /// Логика взаимодействия для RepairPage.xaml
    /// </summary>
    public partial class RepairPage : Page
    {
        QWERTYEntities1 context;
        public RepairPage()
        {
            InitializeComponent();
            context = new QWERTYEntities1();
            repairTable.ItemsSource = context.Repair.ToList();

            var statusList = context.Status.ToList();
            statusList.Insert(0, new Status() { Title = "все", id = 0 });
            statusBox.ItemsSource = statusList;
        }

        public void RefreshData()
        {
            var list = context.Repair.ToList();
            if (statusBox.SelectedIndex > 0)
            {
                Status stat = statusBox.SelectedItem as Status;
                list = list.Where(x => x.Status1 == stat).ToList();

            }


            repairTable.ItemsSource = list;
        }
        private void ChangedType(object sender, SelectionChangedEventArgs e)
        {
            RefreshData();
        }
    }
}

