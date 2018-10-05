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
    /// Interaction logic for AllSellings.xaml
    /// </summary>
    public partial class AllSellings : Window
    {
        DiscInfoClient _infoClient;
        public AllSellings()
        {
            InitializeComponent();
            _infoClient = new DiscInfoClient();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            infoGrid.ItemsSource = _infoClient.AllSellInfo();
            txtPopular.Text = _infoClient.MostPopularGroup();
        }
    }
}
