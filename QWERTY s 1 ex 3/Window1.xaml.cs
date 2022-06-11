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
using System.Windows.Shapes;

namespace QWERTY_s_1_ex_3
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        QWERTYEntities1 context;
        public Window1()
        {
            InitializeComponent();
            context = new QWERTYEntities1();
        }

        private void EnterClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int tubNum1 = Convert.ToInt32(tubNum.Text);
                string fio1 = fio.Text;

                int pos = Convert.ToInt32(positions.Text);
                DateTime date1 = Convert.ToDateTime(date.Text);
                Worker worker = context.Worker.ToList().Find(x => x.tabNum == tubNum1);
                if (worker.tabNum.Equals(tubNum1) && worker.FIO.Equals(fio1) && worker.position.Equals(pos) && worker.dateEmp.Equals(date1))
                {
                    MessageBox.Show("Ваш пароль:" + Convert.ToString(worker.password), "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Проверьте правильность написания данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }


            catch
            {
                MessageBox.Show("Проверьте правильность написания данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

            }



        }

    }
    
}
