namespace DAL
{
    public interface IDigitoVerificador
    {
        BE.DigitoVerificador ObtenerDigito(int id_Entidad);

        void CalcularDVHorizontal();
    }
}
