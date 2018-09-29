namespace DAL
{
    using System.Collections.Generic;

    public interface IDigitoVerificador
    {
        ////BE.DigitoVerificador ObtenerDigito(int id_Entidad);

        int CalcularDVHorizontal(string entidad, List<string> columnasString, List<int> columnasInt);
    }
}
