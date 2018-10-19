namespace BLL
{
    using BE.Entidades;
    using System.Collections.Generic;

    public interface IVentaBLL
    {
        bool Actualizar(Venta objUpd);

        bool Borrar(Venta objDel);

        List<Venta> Cargar();

        bool Crear(Venta objAlta);
    }
}