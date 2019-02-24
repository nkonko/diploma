namespace BLL.Imp
{
    using BE.Entidades;
    using DAL.Dao;
    using System.Collections.Generic;

    public class ClienteBLL : IClienteBLL
    {
        public Cliente ClienteSeleccionado { get; set; } = new Cliente();

        private readonly IClienteDAL clienteDAL;

        public ClienteBLL(IClienteDAL clienteDAL)
        {
            this.clienteDAL = clienteDAL;
        }

        public bool Actualizar(Cliente objUpd)
        {
            return clienteDAL.Actualizar(objUpd);
        }

        public bool Borrar(Cliente objDel)
        {
            return clienteDAL.Borrar(objDel);
        }

        public List<Cliente> Cargar()
        {
            return clienteDAL.Cargar();
        }

        public bool Crear(Cliente objAlta)
        {
            return clienteDAL.Crear(objAlta);
        }

        public string ObtenerClienteConId(int? clienteId)
        {
            return clienteDAL.ObtenerClienteConId(clienteId);
        }
    }
}
