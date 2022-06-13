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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        QWERTYEntities1 context;
        public MainWindow()
        {
            InitializeComponent();
            context = new QWERTYEntities1();
        }

        int attempt = 3;
        private void EnterClick(object sender, RoutedEventArgs e)
        {
            attempt--;

            if (attempt == 0)
            {

                e.Source = passwordButton.Visibility = Visibility.Visible;
                e.Source = enter.Visibility = Visibility.Hidden;
            }
            try
            {
                int tubNum = Convert.ToInt32(login.Text);
                string pass = password.Text;

                Worker worker = context.Worker.ToList().Find(x => x.tabNum == tubNum);

                if (worker == null)
                {
                    MessageBox.Show("Неправильно введен логин, осталось попыток:" + attempt, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (worker.password.Equals(pass))
                    {
                        
                        MessageBox.Show("Успешная авторизация!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
                        Window2 window2 = new Window2();
                        window2.ShowDialog();
                        
                        
                    }
                    else
                    {
                        
                        MessageBox.Show("Неправильно введен пароль, осталось попыток:" + attempt, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }

            }
            catch (FormatException)
            {

                if (attempt == 0)
                {
                    MessageBox.Show("Неправильно введены данные, у вас не осталось попыток!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (attempt > 0)
                {

                    MessageBox.Show("Неправильно введены данные, осталось попыток:" + attempt, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }





        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.ShowDialog();
        }
    }
}
