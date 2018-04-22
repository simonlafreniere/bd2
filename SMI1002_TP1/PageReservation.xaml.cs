using System;
using System.Collections.Generic;
using System.Data;
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
        private InterfaceBD mybd;
        private DataSet mesclients, meschambres;
        public PageReservation()
        {
            InitializeComponent();

            mybd = new InterfaceBD();
            fillClients();
            fillChambres();
        }

        public void fillClients()
        {
            mesclients = mybd.getClients();
            foreach (DataTable table in mesclients.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Content = row["nom"] + ", " + row["prenom"];
                    item.Tag = row["idclient"]; // Copie l'ID dans la propriété Tag
                    CBclient.Items.Add(item);
                }
            }
        }

        public void fillChambres()
        {
            meschambres = mybd.getChambres();
            foreach (DataTable table in meschambres.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Content = row["idchambre"] + ", " + row["prix"]+"$";
                    item.Tag = row["idchambre"]; // Copie l'ID dans la propriété Tag
                    CBchambre.Items.Add(item);
                }
            }
        }

        private void ClickButtonAnnuler(object sender, RoutedEventArgs e)
        {

        }

        private void BtnReserver_Click(object sender, RoutedEventArgs e)
        {
            int idclient= int.Parse( ((ComboBoxItem) CBclient.SelectedItem).Tag.ToString());
        }
    }
}
