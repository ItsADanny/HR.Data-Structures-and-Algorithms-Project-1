public static class Utilities
{
    public static DateTime DTFromSTR(string datetimeString) =>
        DateTime.ParseExact(datetimeString, "yyyy-MM-dd HH:mm:ss,fff",
                            System.Globalization.CultureInfo.InvariantCulture);

    public static string STRFromDT(DateTime datetime) =>
        datetime.ToString("yyyy-MM-dd HH:mm:ss,fff");

    public static string DTToDisplaySTR(DateTime datetime) =>
        datetime.ToString("yyyy-MM-dd HH:mm:ss");
}