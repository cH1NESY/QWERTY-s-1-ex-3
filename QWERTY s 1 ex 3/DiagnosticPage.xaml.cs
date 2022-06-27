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
        public DiagnosticPage()
        {
            InitializeComponent();
            context = new QWERTYEntities1();

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
            NavigationService.Navigate(new DevicePartPage());
        }
    }
}
