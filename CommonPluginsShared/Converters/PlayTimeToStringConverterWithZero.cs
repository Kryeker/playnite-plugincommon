﻿using Playnite.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace CommonPluginsShared.Converters
{
    public class PlayTimeToStringConverterWithZero : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                string.Format(ResourceProvider.GetString("LOCPlayedMinutes"), 0);
            }

            var seconds = (value is long) ? ulong.Parse(((long)value).ToString()) : (ulong)value;
            if (seconds == 0)
            {
                string.Format(ResourceProvider.GetString("LOCPlayedMinutes"), 0);
            }

            var time = TimeSpan.FromSeconds(seconds);
            if (time.TotalSeconds < 60)
            {
                return string.Format(ResourceProvider.GetString("LOCPlayedSeconds"), time.Seconds);
            }
            else if (time.TotalHours < 1)
            {
                return string.Format(ResourceProvider.GetString("LOCPlayedMinutes"), time.Minutes);
            }
            else
            {
                return string.Format(ResourceProvider.GetString("LOCPlayedHours"), Math.Floor(time.TotalHours), time.Minutes);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
