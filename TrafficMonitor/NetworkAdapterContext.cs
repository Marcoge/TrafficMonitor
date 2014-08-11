using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace TrafficMonitor
{
    public class NetworkAdapterContext : INotifyPropertyChanged
    {
        private NetworkInterface _networkInterface;
        private DispatcherTimer _timer;
        private long _bytesSent;
        private long _bytesReceived;

        public NetworkAdapterContext(NetworkInterface ni)
        {
            _networkInterface = ni;
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(42);
            _timer.Tick += OnTick;
            _timer.Start();
        }

        private void OnTick(object sender, EventArgs e)
        {
            BytesSent = _networkInterface.GetIPStatistics().BytesSent;
            BytesReceived = _networkInterface.GetIPStatistics().BytesReceived;
        }

        public String AdapterName { get { return _networkInterface.Name; } }
        
        public long BytesSent
        {
            get
            {
                return _bytesSent;
            }

            set
            {
                if (value != _bytesSent)
                {
                    _bytesSent = value;
                    OnPropertyChanged("BytesSent");
                }
            }
        }
        
        public long BytesReceived
        {
            get
            {
                return _bytesReceived;
            }

            set
            {
                if (value != _bytesReceived)
                {
                    _bytesReceived = value;
                    OnPropertyChanged("BytesReceived");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
