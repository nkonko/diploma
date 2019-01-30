namespace UI
{
    using log4net;
    using System;
    using System.Collections;
    using System.Resources;
    using System.Windows.Forms;

    public static class Alert
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Alert));

        /// <summary>
        /// Methos that shos a simple alert
        /// </summary>
        /// <param name="msj"></param>
        /// <param name="messageNumber"></param>
        public static void ShowSimpleAlert(string msj, string messageNumber = null)
        {
            var mensaje = ProcessMessage(messageNumber);
            MessageBox.Show(mensaje);
        }

        /// <summary>
        /// Method that handles alert showing buttons and icon
        /// </summary>
        /// <param name="msj"></param>
        /// <param name="title"></param>
        /// <param name="buttons"></param>
        /// <param name="icon"></param>
        /// <param name="messageNumber"></param>
        public static void ShowAlterWithButtonAndIcon(string msj, string title, MessageBoxButtons buttons, MessageBoxIcon icon, string messageNumber = null)
        {
            var mensaje = ProcessMessage(messageNumber);
            MessageBox.Show(mensaje, title, buttons, icon);
        }

        /// <summary>
        /// Conformation messagebox
        /// </summary>
        /// <param name="messageCode"></param>
        /// <param name="title"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public static DialogResult ConfirmationMessage(string messageCode, string title, MessageBoxButtons buttons)
        {
            var mensaje = ProcessMessage(messageCode);
            return MessageBox.Show(mensaje, "Salir del sistema", MessageBoxButtons.YesNo);
        }

        /// <summary>
        /// This methods handles the translations for messageboxes
        /// </summary>
        /// <param name="messageNumber"></param>
        /// <returns></returns>
        private static string ProcessMessage(string messageNumber)
        {
            try
            {
                var path = ObtenerPath();
                using (ResXResourceSet resxSet = new ResXResourceSet(path + "Recursos\\Español.resx"))
                {
                    foreach (DictionaryEntry item in resxSet)
                    {
                        if (item.Key != null && (string)item.Key == messageNumber)
                        {
                            return item.Value.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Ocurrio un error al leer el idioma del archivo de recursos. Error: {0}", ex.Message);
            }

            return null;
        }

        private static string ObtenerPath()
        {
            var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            path = path.Remove(0, 6);
            path = path.Substring(0, 60);
            return path;
        }
    }
}
