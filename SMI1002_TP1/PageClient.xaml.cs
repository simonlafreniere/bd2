using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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


namespace SMI1002_TP1
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class PageClient : Page
    {
        private InterfaceBD interfaceBD;
        public PageClient()
        {
            InitializeComponent();
        }

        private void ClickButtonAnnuler(object sender, RoutedEventArgs e)
        {
            interfaceBD = new InterfaceBD();
           /* int client = 21;
            int chambre = 22;
            DateTime debut= new DateTime(2018,12,25);
            DateTime fin = new DateTime(2019,01,18);
            interfaceBD.reserver(client,chambre,debut, fin);
            //interfaceBD.insertData(sql);*/
            interfaceBD.getClients();
        }
    }
}
