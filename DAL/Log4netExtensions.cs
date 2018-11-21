namespace DAL
{
    using log4net;

    public static class Log4netExtensions
    {
        static readonly log4net.Core.Level nivelAlto = new log4net.Core.Level(50000, "ALTA");
        static readonly log4net.Core.Level nivelMedio = new log4net.Core.Level(40000, "MEDIA");
        static readonly log4net.Core.Level nivelBajo = new log4net.Core.Level(30000, "BAJA");

        public static void Alta(this ILog log, string message)
        {
            log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                nivelAlto, message, null);
        }

        public static void AltaFormat(this ILog log, string message, params object[] args)
        {
            string formattedMessage = string.Format(message, args);
            log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                nivelAlto, formattedMessage, null);
        }

        public static void Media(this ILog log, string message)
        {
            log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                nivelMedio, message, null);
        }

        public static void MediaFormat(this ILog log, string message, params object[] args)
        {
            string formattedMessage = string.Format(message, args);
            log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                nivelMedio, formattedMessage, null);
        }

        public static void Baja(this ILog log, string message)
        {
            log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                nivelBajo, message, null);
        }

        public static void BajaFormat(this ILog log, string message, params object[] args)
        {
            string formattedMessage = string.Format(message, args);
            log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                nivelBajo, formattedMessage, null);
        }

    }
}
