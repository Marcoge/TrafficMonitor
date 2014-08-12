using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Collections.ObjectModel;

namespace TrafficMonitor
{
    public sealed class AppContext
    {
        public AppContext()
        {
            Adapters = new ObservableCollection<NetworkAdapterContext>();
        }

        public ObservableCollection<NetworkAdapterContext> Adapters { get; set; }
        public NetworkAdapterContext SelectedAdapter { get; set; }



        internal void Start()
        {
            var interfaceTemp = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var interfs in interfaceTemp)
            {
                Adapters.Add(new NetworkAdapterContext(interfs));
            }
        }
    }
}
