
namespace SysAnalizer
{
    using System;
    using System.Windows.Forms;

    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            string usuario = txt_user.Text;
            string contraseña = txt_contraseña.Text;

            BLL.Usuario.Getinstancia().LogIn(usuario,contraseña);
        }
    }
}
