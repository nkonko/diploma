namespace DAL.Dao.Imp
{
    using BE;
    using BE.Entidades;
    using DAL.Utils;
    using System.Collections.Generic;

    public class ClienteDAL : BaseDao, ICRUD<Cliente>, ICLienteDAL
    {
        public bool Actualizar(Cliente objUpd)
        {
            var queryString = $"UPDATE Cliente SET NombreCompleto = @nombre, Email = @email, Telefono = @telefono, Domicilio = @domicilio, WHERE ClienteId = @ClienteId";

            return CatchException(() =>
            {
                return Exec(
                    queryString,
                    new
                    {
                        @nombre = objUpd.NombreCompleto,
                        @email = objUpd.Email,
                        @telefono = objUpd.Telefono,
                        @domicilio = objUpd.Domicilio,
                        @ClienteId = objUpd.ClienteId
                    });
            });
        }

        public bool Borrar(Cliente objDel)
        {
            var queryString = string.Format("UPDATE Cliente SET Activo = 0 WHERE ClienteId = {0}", objDel.ClienteId);

            return CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public List<Cliente> Cargar()
        {
            var queryString = "SELECT * FROM Cliente";

            return CatchException(() =>
            {
                return Exec<Cliente>(queryString);
            });
        }

        public bool Crear(Cliente objAlta)
        {
            var queryString = "INSERT INTO Cliente(NombreCompleto, Email, Telefono, Domicilio, Activo) VALUES (@nombre, @email, @telefono," +
                " @domicilio, @activo)";

            return CatchException(() =>
            {
                return Exec(
                    queryString,
                    new
                    {
                        @nombre = objAlta.NombreCompleto,
                        @email = objAlta.Email,
                        @telefono = objAlta.Telefono,
                        @domicilio = objAlta.Domicilio,
                        @activo = 1
                    });
            });
        }
    }
}
