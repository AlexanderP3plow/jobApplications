using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Globalization;
namespace JobApplications.Converter;

public class StatusToBrushConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value switch
        {
            "Active" => Brushes.Green,
            "Cancelled" => Brushes.Red,
            _ => Brushes.White
        };
    }
    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
