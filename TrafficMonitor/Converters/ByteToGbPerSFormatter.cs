using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TrafficMonitor.Converters
{
     [ValueConversion(typeof(String),typeof(String))]

    public class ByteToGbPerSFormatter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            String s = "";
            float teilen;
            Int64 temp = (Int64)value;

            if (temp >= 1024 && temp < 1048576 )
            {
                teilen = ((float)temp / 1024);
                return s = teilen.ToString("0.00") + (" KB/s");
            }
            if (temp >= 1048576 && temp < 1073741824)
            {
                teilen = ((float)temp / 1048576);
                return s = teilen.ToString("0.00") + (" MB/s");
            }
            if (temp >= 1073741824 )
            {
                teilen = ((float)temp / 1073741824);
                return s = teilen.ToString("0.00") + ("GB/s");
            }
            else
            {
                return s;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

