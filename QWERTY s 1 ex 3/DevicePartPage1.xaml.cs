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
    /// Логика взаимодействия для DevicePartPage1.xaml
    /// </summary>
    public partial class DevicePartPage1 : Page
    {
        QWERTYEntities1 context;
        public DevicePartPage1(QWERTYEntities1 cont, TypeDevicePart typeDevicePart)
        {
            InitializeComponent();
            context = cont;
            DevicePartTable.ItemsSource = cont.DevicePart.ToList().Where(x => x.type == typeDevicePart.id).ToList();        }
    }
}
