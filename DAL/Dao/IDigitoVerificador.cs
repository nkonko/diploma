namespace DAL.Dao
{
    using System.Collections.Generic;

    public interface IDigitoVerificador
    {
        List<string> Entidades { get; set; }

        int CalcularDVHorizontal(List<string> columnasString = null, List<int> columnasInt = null);

        void InsertarDVVertical(string entidad);

        void ActualizarDVVertical(string entidad);

        bool ComprobarPrimerDigito(string entidad);

        bool ComprobarIntegridad();
    }
}
