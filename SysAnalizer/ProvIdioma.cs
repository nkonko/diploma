namespace UI
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Resources;
    using System.Windows.Forms;

    public class ProvIdioma : Form, IProvIdioma
    {
        private IFormControl formControl;

        public ProvIdioma()
        {
            formControl = IoCContainer.Resolve<IFormControl>();
        }

        public void LlenarRecursos(IDictionary<string, string> traducciones, int idiomaSeleccionado, string nombreFormulario)
        {
            this.CatchException(
                () =>
            {
                using (ResXResourceWriter resxWriter = new ResXResourceWriter(formControl.ObtenerDirectorio()))
                {
                    if (traducciones.Any())
                    {
                        foreach (var item in traducciones)
                        {
                            resxWriter.AddResource(item.Key, item.Value);
                        }
                    }
                }
            },
            (ex) => MessageBox.Show($"Ocurrio un error al llenar el archivo de recursos: {ex.Message}"));
        }

        public void LeerRecursos(Control.ControlCollection controls)
        {
            this.CatchException(
                () =>
            {
                using (ResXResourceSet resxSet = new ResXResourceSet(formControl.ObtenerDirectorio()))
                {
                    foreach (DictionaryEntry item in resxSet)
                    {
                        controls[item.Key.ToString()].Text = item.Value.ToString();
                    }
                }
            },
            (ex) => MessageBox.Show($"Ocurrio un error: {ex.Message}"));
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ProvIdioma
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "ProvIdioma";
            this.Load += new System.EventHandler(this.ProvIdioma_Load);
            this.ResumeLayout(false);

        }

        private void ProvIdioma_Load(object sender, System.EventArgs e)
        {

        }
    }
}
