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
        private DispatcherTimer _sTimer;
        private long _bytesSent;
        private long _bytesReceived;
        private long _bytesSentDelta;
        private long _bytesReceivedDelta;
        private long _prevTickReceived;
        private long _prevTickSent;

        public NetworkAdapterContext(NetworkInterface ni)
        {
            _networkInterface = ni;
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(250);
            _timer.Tick += OnTick;
            _timer.Start();
            _sTimer = new DispatcherTimer();
            _sTimer.Interval = TimeSpan.FromMilliseconds(1000);
            _sTimer.Tick += SOnTick;
            _sTimer.Start();
        }

        private void SOnTick(object sender, EventArgs e)
        {
            var receivedTemp= _networkInterface.GetIPStatistics().BytesReceived;
            var sentTemp = _networkInterface.GetIPStatistics().BytesSent;
            
            BytesReceivedDelta = receivedTemp - _prevTickReceived;
            BytesSentDelta = sentTemp - _prevTickSent;
           
            _prevTickSent = sentTemp;
            _prevTickReceived = receivedTemp;
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

        public long BytesSentDelta
        {
            get
            {
                return _bytesSentDelta;
            }

            set
            {
                if (value != _bytesSentDelta)
                {
                    _bytesSentDelta = value;
                    OnPropertyChanged("BytesSentDelta");
                }
            }
        }

        public long BytesReceivedDelta
        {
            get
            {
                return _bytesReceivedDelta;
            }

            set
            {
               if (value != _bytesReceivedDelta)
                {
                    _bytesReceivedDelta = value;
                    OnPropertyChanged("BytesReceivedDelta");
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
