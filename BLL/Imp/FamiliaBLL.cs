namespace BLL.Imp
{
    using BE;
    using DAL;
    using DAL.Imp;
    using System;
    using System.Collections.Generic;

    public class FamiliaBLL : ICRUD<Familia>
    {
        private readonly IFamiliaDAL familiaDAL;

        public FamiliaBLL(IFamiliaDAL familiaDAL)
        {
            this.familiaDAL = familiaDAL;
        }

        public bool Actualizar(Familia objUpd)
        {
            return familiaDAL.Actualizar(objUpd);
        }

        public bool Borrar(Familia objDel)
        {
            return familiaDAL.Borrar(objDel);
        }

        public List<Familia> Cargar()
        {
            return familiaDAL.Cargar();
        }

        public bool Crear(Familia objAlta)
        {
            return familiaDAL.Crear(objAlta);
        }
    }
}
