namespace DAL.Dao
{
    using BE.Entidades;
    using System.Collections.Generic;

    public interface IFamiliaDAL
    {
        bool Actualizar(Familia objUpd);

        bool Borrar(Familia objDel);

        List<Familia> Cargar();

        bool Crear(Familia objAlta);

        List<Patente> ObtenerPatentesFamilia(int familiaId);
    }
}