namespace BLL.Imp
{
    using BE.Entidades;
    using DAL.Dao.Imp;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Resources;
    using System.Windows.Forms;

    public class IdiomaBLL : IIdiomaBLL
    {
        private static readonly string ResourcesFilePath = new FileInfo("Español.resx").FullName;

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
            using (ResXResourceSet resxSet = new ResXResourceSet(ResourcesFilePath))
            {
                foreach (DictionaryEntry item in resxSet)
                {
                    controls[item.Key.ToString()].Text = item.Value.ToString();
                }
            }
        }
    }
}
