using ControladorDePedidos.Model;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ControladorDePedidos.WPF
{
    public class ConversorDeData : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            var data = (DateTime)value;

            if (data == new DateTime())
            {
                return "-";
            }
            else
            {
                return data.ToString("dd/MM/yyy");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
