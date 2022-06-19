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
    /// Логика взаимодействия для EditClients.xaml
    /// </summary>
    public partial class EditClients : Page
    {
        QWERTYEntities1 context;
        public EditClients(QWERTYEntities1 cont)
        {
            InitializeComponent();
            context = cont;
        }

        private void EditSave(object sender, RoutedEventArgs e)
        {
            context.Client.Find(client1.Num).name = nameBox.Text;
            context.Client.Find(client1.Num).serialPass = Convert.ToInt32(serBox.Text);
            context.Client.Find(client1.Num).numberPas = Convert.ToInt32(numpBox.Text);
            context.Client.Find(client1.Num).phone = Convert.ToDecimal(numtBox.Text);
          
            context.SaveChanges();
            NavigationService.Navigate(new MastersPage());
        }
        Client client1;
        public EditClients(QWERTYEntities1 cont, Client client)
        {
            InitializeComponent();
            context = cont;

            client1 = client;

            numBox.Text = client.Num.ToString();
            nameBox.Text = client.name;
            serBox.Text = client.serialPass.ToString();
            numpBox.Text = client.numberPas.ToString();
            numtBox.Text = client.phone.ToString();



        }
    }
}
