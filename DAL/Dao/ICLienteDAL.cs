namespace DAL.Dao
{
    using BE;
    using BE.Entidades;

    public interface IClienteDAL : ICRUD<Cliente>
    {
        string ObtenerClienteConId(int? clienteId);
    }
}