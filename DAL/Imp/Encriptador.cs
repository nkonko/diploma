namespace DAL
{
    using System.Security.Cryptography;
    using System.Text;

    public class Encriptador : IEncriptador
    {
        public string Desencriptar()
        {
            return null;
        }

        public string Encriptar(string contraseña)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(contraseña));
            byte[] encriptado = md5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 1; i < encriptado.Length; i++)
            {
                str.Append(encriptado[i].ToString("x2"));
            }

            return str.ToString();
        }
    }
}
