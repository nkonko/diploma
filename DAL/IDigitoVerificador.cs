using System.Collections.Generic;

namespace DAL
{
    public interface IDigitoVerificador
    {
        BE.DigitoVerificador ObtenerDigito(int id_Entidad);

        int CalcularDVHorizontal(List<string> registros);
    }
}
