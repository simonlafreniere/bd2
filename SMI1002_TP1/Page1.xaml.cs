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
    public partial class Page1 : Page
    {
        private InterfaceBD interfaceBD;
        public Page1()
        {
            InitializeComponent();
        }

        private void ClickButtonAnnuler(object sender, RoutedEventArgs e)
        {
            interfaceBD = new InterfaceBD();
            string sql = "insert into LIT (IDLIT,PRIX,IDDORTOIR) values(NULL,:PRIX,:IDDORTOIR)";
            interfaceBD.insertData(sql);
        }
    }
}
