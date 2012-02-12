namespace SOLID
{
    public static class Logger
    {
        public static void Log(this string format, params object[] args)
        {
            string msg = string.Format(format, args);
            System.Diagnostics.Trace.WriteLine(msg);
        }
         
    }
}