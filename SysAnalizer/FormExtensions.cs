namespace UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public static class FormExtensions
    {
        public static void CatchException(this Form form, Action func, Action<Exception> onError = null)
        {
            try
            {
                func();
            }
            catch (Exception ex)
            {
                ///
                onError?.Invoke(ex);
            }
        }

        public static void ShowMessageError(this Form frm, string msg)
        {
            MessageBox.Show(frm, msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
