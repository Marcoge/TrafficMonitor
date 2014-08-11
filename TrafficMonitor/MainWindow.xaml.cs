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
using System.Net.NetworkInformation;

namespace TrafficMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        IPGlobalProperties computerProperties;
        NetworkInterface[] nics;
        
        public MainWindow()
        {
            InitializeComponent();
            populateCb();
        }

        private void populateCb()
        {
            computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            nics = NetworkInterface.GetAllNetworkInterfaces();
            if (nics == null || nics.Length <1)
            {
                //Message for no interface
            }
            else
            {
                foreach (NetworkInterface ninterface in nics)
                {
                    CbIPInterfaces.Items.Add(ninterface.Name);
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = CbIPInterfaces.SelectedIndex;
            var BytesReceived = nics[index].GetIPv4Statistics().BytesReceived;
            var BytesSent = nics[index].GetIPv4Statistics().BytesSent;    
            TxtBlock1.Text = "Bytes received: "+ BytesReceived.ToString()+"\r\n"+"Bytes sent: "+ BytesSent.ToString()+"\r\n";
        }
    }
}
