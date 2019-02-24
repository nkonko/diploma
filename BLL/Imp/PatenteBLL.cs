namespace BLL.Imp
{
    using BE.Entidades;
    using DAL.Dao;
    using System.Collections.Generic;

    public class PatenteBLL : IPatenteBLL
    {
        private readonly IPatenteDAL patenteDAL;

        public PatenteBLL(IPatenteDAL patenteDAL)
        {
            this.patenteDAL = patenteDAL;
        }

        public bool AsignarPatente(int familiaId, int patenteId)
        {
            return patenteDAL.AsignarPatente(familiaId, patenteId);
        }

        public List<Patente> Cargar()
        {
            return patenteDAL.Cargar();
        }

        public void GuardarPatentesUsuario(List<int> patenteId, int usuarioId)
        {
            patenteDAL.GuardarPatentesUsuario(patenteId, usuarioId);
        }

        public bool BorrarPatente(int familiaId, int patenteId)
        {
            return patenteDAL.BorrarPatente(familiaId, patenteId);
        }

        public int ObtenerIdPatentePorDescripcion(string descripcion)
        {
            return patenteDAL.ObtenerIdPatentePorDescripcion(descripcion);
        }

        public bool ComprobarPatentesUsuario(int usuarioId)
        {
            return patenteDAL.ComprobarPatentesUsuario(usuarioId);
        }

        public List<FamiliaPatente> ConsultarPatenteFamilia(int familiaId)
        {
            return patenteDAL.ConsultarPatenteFamilia(familiaId);
        }

        public bool NegarPatente(int patenteId, int usuarioId)
        {
            return patenteDAL.NegarPatenteUsuario(patenteId, usuarioId);
        }

        public bool HabilitarPatente(int patenteId, int usuarioId)
        {
            return patenteDAL.HabilitarPatenteUsuario(patenteId, usuarioId);
        }

        public List<UsuarioPatente> ConsultarPatenteUsuario(int usuarioId)
        {
            return patenteDAL.ConsultarPatenteUsuario(usuarioId);
        }

        public void BorrarPatentesUsuario(List<int> ids, int usuarioId)
        {
            patenteDAL.BorrarPatentesUsuario(ids, usuarioId);
        }

        public bool CheckeoDePatentesParaBorrar(Usuario usuario, List<Usuario> usuariosGlobales, bool requestFamilia = false, bool requestFamiliaUsuario = false, bool borrado = false, int familiaAQuitarId = 0)
        {
            return patenteDAL.CheckeoDePatentesParaBorrar(usuario, usuariosGlobales, requestFamilia, requestFamiliaUsuario, borrado, familiaAQuitarId);
        }

        public bool CheckeoFamiliaParaBorrar(Familia familia, List<Usuario> usuariosGlobales)
        {
            return patenteDAL.CheckeoFamiliaParaBorrar(familia, usuariosGlobales);
        }

        public bool CheckeoUsuarioParaBorrar(Usuario usuario, List<Usuario> usuariosGlobales)
        {
            return patenteDAL.CheckeoUsuarioParaBorrar(usuario, usuariosGlobales);
        }

        public bool CheckeoPatenteParaBorrar(Patente patente, Usuario usuario, List<Usuario> usuariosGlobales, bool paraNegar = false)
        {
            return patenteDAL.CheckeoPatenteParaBorrar(patente, usuario, usuariosGlobales, paraNegar);
        }

        public Patente ObtenerPatentePorDescripcion(string descripcion, int usuarioId)
        {
            return patenteDAL.ObtenerPatentePorDescripcion(descripcion, usuarioId);
        }
    }
}
