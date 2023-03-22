using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Pokedex.Extensions
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var colorName = value as string;
            if (!Application.Current.Resources.ContainsKey(colorName))
                throw new KeyNotFoundException($"{colorName} not found in resources");
            return Application.Current.Resources[colorName];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
