using System.Globalization;

namespace PMEGP_Physical_V.Converters
{
    public class BoolToIconColorConverter : IValueConverter
    {
        public Color SelectedColor { get; set; } = Colors.White;
        public Color UnselectedColor { get; set; } = Colors.Black;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b)
                return b ? SelectedColor : UnselectedColor;

            return UnselectedColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
