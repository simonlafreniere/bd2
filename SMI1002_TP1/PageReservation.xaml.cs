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

namespace SMI1002_TP1
{
    /// <summary>
    /// Logique d'interaction pour PageReservation.xaml
    /// </summary>
    public partial class PageReservation : Page
    {
        public PageReservation()
        {
            InitializeComponent();


        }

        private void BtnReserver_Click(object sender, RoutedEventArgs e)
        {
            int idclient= int.Parse( ((ComboBoxItem) CBclient.SelectedItem).Tag.ToString());
        }
    }
}
