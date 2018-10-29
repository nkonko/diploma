namespace BLL.Imp
{
    using System.Collections.Generic;
    using BE.Entidades;
    using DAL.Dao;

    public class PatenteBLL : IPatenteBLL
    {
        private readonly IPatenteDAL patenteDAL;

        public PatenteBLL(IPatenteDAL patenteDAL)
        {
            this.patenteDAL = patenteDAL;
        }

        public List<Patente> Cargar()
        {
            return patenteDAL.Cargar();
        }

        public void GuardarPatenteUsuario(int patenteId, int usuarioId)
        {
            patenteDAL.GuardarPatenteUsuario(patenteId, usuarioId);
        }

        public int ObtenerIdPatentePorDescripcion(string descripcion)
        {
            return patenteDAL.ObtenerIdPatentePorDescripcion(descripcion);
        }
    }
}
