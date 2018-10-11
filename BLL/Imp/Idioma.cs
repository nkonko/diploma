namespace BLL
{
    using System.Collections.Generic;

    public class Idioma : BE.ICRUD<BE.Idioma>
    {
        private static Idioma instancia;

        private Idioma()
        {
        }

        public static Idioma Getinstancia()
        {
            if (instancia != null)
            {
                instancia = new Idioma();
            }

            return instancia;
        }

        public bool Crear(BE.Idioma objAlta)
        {
            return DAL.Idioma.Getinstancia().Crear(objAlta);
        }

        public List<BE.Idioma> Cargar()
        {
            return DAL.Idioma.Getinstancia().Cargar();
        }

        public bool Borrar(BE.Idioma objDel)
        {
            return DAL.Idioma.Getinstancia().Borrar(objDel);
        }

        public bool Actualizar(BE.Idioma objUpd)
        {
            return DAL.Idioma.Getinstancia().Actualizar(objUpd);
        }
    }
}
