namespace BE
{
    using System.Collections.Generic;

    public interface ICRUD<T>
    {
        bool Crear(T objAlta);

        List<T> Cargar();

        bool Borrar(T objDel);

        bool Actualizar(T objUpd);
    }
}
