namespace UI
{
    public interface IPrincipal
    {
        void Show();

        void ComprobarSiEsPrimerLogin(string usuario);
    }
}
