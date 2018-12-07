namespace BLL.Imp
{
    using BE;
    using BE.Entidades;
    using DAL.Dao;
    using System.Collections.Generic;

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
                familiaDAL.BorrarFamiliaDeFamiliaPatente(objDel.FamiliaId);

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

        public List<Patente> ObtenerPatentesFamilia(int familiaId)
        {
            return familiaDAL.ObtenerPatentesFamilia(familiaId);
        }

        public void GuardarFamiliasUsuario(List<int> familiasId, int usuarioId)
        {
            familiaDAL.GuardarFamiliasUsuario(familiasId, usuarioId);
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
            return familiaDAL.ObtenerPatentesDeFamilias(familiaId);
        }

        public List<int> ObtenerIdsFamiliasPorUsuario(int usuarioId)
        {
            return familiaDAL.ObtenerIdsFamiliasPorUsuario(usuarioId);
        }

        public List<string> ObtenerDescripcionFamiliaPorId(List<int> familiaId)
        {
            return familiaDAL.ObtenerDescripcionFamiliaPorId(familiaId);
        }

        public void BorrarFamiliasUsuario(List<Familia> familias, int usuarioId)
        {
            familiaDAL.BorrarFamiliasUsuario(familias, usuarioId);
        }

        public List<Familia> ObtenerFamiliasUsuario(int usuarioId)
        {
            return familiaDAL.ObtenerFamiliasUsuario(usuarioId);
        }

        public List<Usuario> ObtenerUsuariosPorFamilia(int familiaId)
        {
            return familiaDAL.ObtenerUsuariosPorFamilia(familiaId);
        }

        public Familia ObtenerFamiliaConDescripcion(string descripcion)
        {
            return familiaDAL.ObtenerFamiliaConDescripcion(descripcion);
        }
    }
}
