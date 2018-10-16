namespace DAL
{
    using BE;

    public interface IBitacoraDAL
    {
        void FiltrarBitacora(Filtros filtros);

        Bitacora LeerBitacoraConId(int bitacoraId);

        int GenerarDVH(Usuario usu);

        string ObtenerUltimoIdBitacora();
    }
}
