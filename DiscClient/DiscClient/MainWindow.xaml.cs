using DiscClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

namespace DiscClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DiscInfoClient _infoClient; 
        public MainWindow()
        {
            InitializeComponent();
            _infoClient = new DiscInfoClient();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {

                List<DiscClient.ServiceReference1.SellInfo> sellInfos = _infoClient.AllSellInfo();
                List<Disc> discs= _infoClient.ShowAllDiscs();
                AllDisc.ItemsSource = _infoClient.ShowAllDiscs();
                //infoGrid.ItemsSource = _infoClient.AllSellInfo();
                //cbGroup.ItemsSource = _infoClient.AllSellInfo().Select(p=>p.BandName).Distinct();
                //cbGroup.SelectedIndex = 0;
                //List<GroupInfo> group = _infoClient.TotalAmountSellGroup("Наутилус");
              

            }
            catch (FaultException ex)
            {
                MessageBox.Show(ex.Message);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }

        private void cnGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selectedItem =comboBox.SelectedItem.ToString();
           List<GroupInfo> groupInfos= _infoClient.TotalAmountSellGroup(selectedItem);
//            GroupGrid.ItemsSource = groupInfos;


        }

        private void btnShowAll_Click(object sender, RoutedEventArgs e)
        {
            AllSellings allSellings = new AllSellings();
            allSellings.ShowDialog();

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddDiscWindow addDiscWindow = new AddDiscWindow();
            addDiscWindow.ShowDialog();
            AllDisc.ItemsSource = null;
            AllDisc.ItemsSource = _infoClient.ShowAllDiscs();
        }

        private void btnSell_Click(object sender, RoutedEventArgs e)
        {
            if(AllDisc.SelectedItems.Count>0)
            {
                Disc disc = AllDisc.SelectedItem as Disc;
                MakePurschaseWindow makePurschase = new MakePurschaseWindow(disc.Name);
                makePurschase.ShowDialog();
                MessageBox.Show("Ok");
                
            }
        }
    }
}
