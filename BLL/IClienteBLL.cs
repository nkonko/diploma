namespace BLL
{
    using BE;
    using BE.Entidades;

    public interface IClienteBLL : ICRUD<Cliente>
    {
        string ObtenerClienteConId(int? clienteId);
    }
}
