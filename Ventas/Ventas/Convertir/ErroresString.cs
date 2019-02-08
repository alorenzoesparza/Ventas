using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Ventas.Convertir
{
    public class ErroresString : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            string parametro = (string)value.ToString();
            if (parametro.Length < 3 || string.IsNullOrWhiteSpace(parametro))
                return false;    // input is empty
            else
                return true;   // data has been entered 
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
