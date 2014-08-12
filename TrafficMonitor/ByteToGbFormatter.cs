using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TrafficMonitor
{
    [ValueConversion(typeof(String),typeof(String))]

    public sealed class ByteToGbFormatter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var s = (String)value;
            long temp = long.Parse(s);

            if (temp >= 1024 && temp < 1048576 )
            {
                return s = (temp / 1024).ToString() + (" KB");
            }
            if (temp >= 1048576 && temp < 1073741824)
            {
                return s = (temp / 1048576).ToString() + (" MB");
            }
            if (temp >= 1073741824 )
            {
                return s = (temp / 1073741824).ToString() + ("GB");
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
