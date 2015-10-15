namespace SystemDot.MessageRouteInspector.Server.Queries
{
    using System;
    using System.Globalization;

    public static class DateTimeExtensions
    {
        public static string ToJavaString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture);
        }
    }
}