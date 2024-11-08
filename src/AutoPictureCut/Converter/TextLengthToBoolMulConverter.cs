using System.Globalization;
using System.Windows.Data;

namespace AutoPictureCut.Converter
{
    internal class TextLengthToBoolMulConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values?.Count(m => !string.IsNullOrEmpty(m?.ToString())) == 2;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
