using DiscClient.ServiceReference1;
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

namespace DiscClient
{
    /// <summary>
    /// Interaction logic for MakePurschaseWindow.xaml
    /// </summary>
    public partial class MakePurschaseWindow : Window
    {
        string _discName;
        DiscInfoClient _infoClient;
        public MakePurschaseWindow(string DiscName)
        {
            InitializeComponent();
            _discName = DiscName;
            _infoClient = new DiscInfoClient();

        }

        private void btnSell_Click(object sender, RoutedEventArgs e)
        {
            _infoClient.AddSell( _discName,  cbCashier.SelectedItem.ToString());

            Console.WriteLine();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                List<SellInfo> vs = _infoClient.AllSellInfo();
                cbCashier.ItemsSource = _infoClient.AllSellInfo().Select(p => p.SellerName).Distinct();
                cbCashier.SelectedIndex = 0;
                txtDiscname.Text = _discName;
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }

        }

    

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
