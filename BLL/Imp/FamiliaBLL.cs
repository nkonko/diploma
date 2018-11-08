namespace BLL.Imp
{
    using BE;
    using BE.Entidades;
    using DAL.Dao;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    public class FamiliaBLL : ICRUD<Familia>, IFamiliaBLL
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
            var familiaEnUso = ComprobarUsoFamilia(objDel.FamiliaId);

            if (!familiaEnUso)
            {
                return familiaDAL.Borrar(objDel);
            }

            return false;
        }

        public List<Familia> Cargar()
        {
            return familiaDAL.Cargar();
        }

        public bool Crear(Familia objAlta)
        {
            return familiaDAL.Crear(objAlta);
        }

        public List<Patente> ObtenerPatentesFamilia(int familiaId)
        {
            return familiaDAL.ObtenerPatentesFamilia(familiaId);
        }

        public void GuardarFamiliaUsuario(int familiaId, int usuarioId)
        {
            familiaDAL.GuardarFamiliaUsuario(familiaId, usuarioId);
        }

        public int ObtenerIdFamiliaPorDescripcion(string descripcion)
        {
            return familiaDAL.ObtenerIdFamiliaPorDescripcion(descripcion);
        }

        public int ObtenerIdFamiliaPorUsuario(int usuarioId)
        {
            return familiaDAL.ObtenerIdFamiliaPorUsuario(usuarioId);
        }

        public string ObtenerDescripcionFamiliaPorId(int familiaId)
        {
            return familiaDAL.ObtenerDescripcionFamiliaPorId(familiaId);
        }

        public bool ComprobarUsoFamilia(int familiaId)
        {
            return familiaDAL.ComprobarUsoFamilia(familiaId);
        }

        public List<Patente> ObtenerPatentesFamilia(List<int> familiaId)
        {
            return familiaDAL.ObtenerPatentesFamilia(familiaId);
        }

        public List<int> ObtenerIdsFamiliasPorUsuario(int usuarioId)
        {
            return familiaDAL.ObtenerIdsFamiliasPorUsuario(usuarioId);
        }

        public List<string> ObtenerDescripcionFamiliaPorId(List<int> familiaId)
        {
            return familiaDAL.ObtenerDescripcionFamiliaPorId(familiaId);
        }
    }
}
