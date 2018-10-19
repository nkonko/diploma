namespace DAL.Dao
{
    using System.Collections.Generic;

    public interface IDigitoVerificador
    {
        int CalcularDVHorizontal(List<string> columnasString = null, List<int> columnasInt = null);
    }
}
