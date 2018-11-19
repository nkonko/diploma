namespace BLL.Imp
{
    using BE.Entidades;
    using DAL.Dao;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Resources;
    using System.Windows.Forms;

    public class IdiomaBLL : IIdiomaBLL
    {
        private static readonly string ResourcesFilePath = "C:\\Users\\Nicolas Azzara\\Desktop\\diploma\\diploma\\SysAnalizer\\Recursos\\Español.resx";

        private readonly IIdiomaDAL idiomaDAL;

        public IdiomaBLL(IIdiomaDAL idiomaDAL)
        {
            this.idiomaDAL = idiomaDAL;
        }

        public List<Idioma> ObtenerTodosLosIdiomas()
        {
            return idiomaDAL.ObtenerTodosLosIdiomas();
        }

        public List<TraduccionFormulario> ObtenerTraduccionesFormulario(int idiomaId, string nombreForm)
        {
            return idiomaDAL.ObtenerTraduccionesFormulario(idiomaId, nombreForm);
        }

        public void LlenarRecursos(IDictionary<string, string> traducciones, int idiomaSeleccionado, string nombreFormulario)
        {
            using (ResXResourceWriter resxWriter = new ResXResourceWriter(ResourcesFilePath))
            {
                if (traducciones.Any())
                {
                    foreach (var item in traducciones)
                    {
                        resxWriter.AddResource(item.Key, item.Value);
                    }
                }
            }
        }

        public void LeerRecursos(Control.ControlCollection controls)
        {
            using (ResXResourceSet resxSet = new ResXResourceSet("C:\\Users\\Nicolas Azzara\\Desktop\\diploma\\diploma\\SysAnalizer\\Recursos\\Español.resx"))
            {
                foreach (DictionaryEntry item in resxSet)
                {
                    if (controls.ContainsKey(item.Key.ToString()))
                    {
                        controls[item.Key.ToString()].Text = item.Value.ToString();
                    }
                }
            }
        }
    }
}
