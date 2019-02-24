namespace UI
{
    using BLL;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Resources;
    using System.Windows.Forms;

    public class Traductor : ITraductor
    {
        private readonly IFormControl formControl;
        private readonly IIdiomaBLL idiomaBLL;

        public Traductor(IFormControl formControl, IIdiomaBLL idiomaBLL)
        {
            this.formControl = formControl;
            this.idiomaBLL = idiomaBLL;
        }

        public void Traduccir(Control control, string nombreForm)
        {
            BorrarRecursos();
            formControl.Traducciones.Clear();
            formControl.Traducciones = GetTraducciones(nombreForm);
            idiomaBLL.LlenarRecursos(formControl.Traducciones, formControl.LenguajeSeleccionado.IdIdioma, nombreForm);
            idiomaBLL.LeerRecursos(control.Controls);
        }

        public string ObtenerPathRecursos()
        {
            return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Recursos\\Español.resx";
        }

        private void BorrarRecursos()
        {
            using (ResXResourceWriter resxWriter = new ResXResourceWriter(ObtenerPathRecursos()))
            {
                resxWriter.Dispose();
            }
        }

        private IDictionary<string, string> GetTraducciones(string nombreForm)
        {
            formControl.Traducciones = idiomaBLL.ObtenerTraduccionesFormulario(formControl.LenguajeSeleccionado.IdIdioma, nombreForm).ToDictionary(k => k.ControlName ?? k.MensajeCodigo, v => v.Traduccion);

            return formControl.Traducciones;
        }
    }
}
