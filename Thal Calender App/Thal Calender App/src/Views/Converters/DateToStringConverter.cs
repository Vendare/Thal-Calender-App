using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using Thal_Calender_App.src.DataTypes;

namespace Thal_Calender_App.src.Views.Converters
{
    [ValueConversion(typeof(ThalDate), typeof(string))]
    class DateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            StringBuilder sb = new StringBuilder();

            var date = (ThalDate)value;

            sb.Append(date.DayOfWeek.ToString()).Append(", ");
            sb.Append(date.Day + " ");
            sb.Append(date.MonthName + " ");
            sb.Append(date.Year);

            return sb.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
