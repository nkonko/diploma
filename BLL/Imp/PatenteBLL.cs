namespace BLL.Imp
{
    using System.Collections.Generic;
    using BE;
    using DAL.Imp;

    public class PatenteBLL : ICRUD<Patente>
    {
        private readonly IPatenteDAL patenteDAL;

        public PatenteBLL(IPatenteDAL patenteDAL)
        {
            this.patenteDAL = patenteDAL;
        }

        public bool Actualizar(Patente objUpd)
        {
            throw new System.NotImplementedException();
        }

        public bool Borrar(Patente objDel)
        {
            throw new System.NotImplementedException();
        }

        public List<Patente> Cargar()
        {
            throw new System.NotImplementedException();
        }

        public bool Crear(Patente objAlta)
        {
            throw new System.NotImplementedException();
        }
    }
}
