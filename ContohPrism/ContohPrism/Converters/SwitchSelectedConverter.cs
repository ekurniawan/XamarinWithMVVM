using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ContohPrism.Converters
{
    public class SwitchSelectedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var switchChecked = value as ToggledEventArgs;
            if (switchChecked == null)
            {
                throw new ArgumentException("Expected value ToggledEventArgs", nameof(value));
            }
            return switchChecked.Value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
