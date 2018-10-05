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
    /// Interaction logic for AddDiscWindow.xaml
    /// </summary>
    public partial class AddDiscWindow : Window
    {
        DiscInfoClient _infoClient;
        public AddDiscWindow()
        {
            InitializeComponent();
            _infoClient = new DiscInfoClient();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> vs = _infoClient.AllSellInfo().Select(p => p.FormatName).Distinct().ToList();
            cbFormat.ItemsSource = _infoClient.AllSellInfo().Select(p=>p.FormatName).Distinct();
            cbFormat.SelectedIndex = 0;
          
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            SellInfo sellInfo = new SellInfo();
            if(!string.IsNullOrWhiteSpace(txtBand.Text)&& !string.IsNullOrWhiteSpace(txtName.Text))
            {
                sellInfo.CDName = txtName.Text;
                sellInfo.BandName = txtBand.Text;


                try
                {
                    string str1 = dpDate.SelectedDate.Value.ToShortDateString();
                    string str2 = dpDate.SelectedDate.Value.ToShortDateString().Substring(str1.Length - 4);
                    sellInfo.Cd_Date = int.Parse(str2);
                    str1 = dpDateFound.SelectedDate.Value.ToShortDateString();
                    str2 = dpDateFound.SelectedDate.Value.ToShortDateString().Substring(str1.Length - 4);
                    sellInfo.BandDate= int.Parse(str2);
               
               // MessageBox.Show(cbFormat.SelectedItem.ToString());
                sellInfo.FormatName = cbFormat.SelectedItem.ToString();


                _infoClient.AddDiscBand(sellInfo);
                Console.WriteLine("Ok");
 }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    
                }
                //MainWindow mainWindow = new MainWindow();
                

            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
