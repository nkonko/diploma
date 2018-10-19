namespace DAL.Dao
{
    using BE;
    using BE.Entidades;

    public interface IBitacoraDAL
    {
        void FiltrarBitacora(FiltrosBitacora filtros);

        Bitacora LeerBitacoraConId(int bitacoraId);

        int GenerarDVH(Usuario usu);

        int ObtenerUltimoIdBitacora();
    }
}
