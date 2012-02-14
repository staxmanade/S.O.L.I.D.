namespace SOLID
{
    public static class Logger
    {
        public static void Log(this string format, params object[] args)
        {
            System.Diagnostics.Trace.WriteLine(format.FormatWith(args));
        }
         
			public static string FormatWith(this string format, params object[] args)
			{
				return string.Format(format, args);
			}
    }
}