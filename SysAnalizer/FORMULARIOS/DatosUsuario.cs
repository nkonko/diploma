namespace UI
{
    using System.Windows.Forms;

    public partial class DatosUsuario : Form, IDatosUsuario
    {
        private readonly IFormControl formControl;

        public DatosUsuario(IFormControl formControl)
        {
            this.formControl = formControl;
            InitializeComponent();
        }

        private void DatosUsuario_Load(object sender, System.EventArgs e)
        {
            var usu = formControl.ObtenerInfoUsuario();

            lblNombre.Text = lblNombre.Text + usu.Nombre;
            lblApellido.Text = lblApellido.Text + usu.Apellido;
            lblDireccion.Text = lblDireccion.Text + usu.Domicilio;
            lblEmail.Text = lblEmail.Text + usu.Email;
            lblTelefono.Text = lblTelefono.Text + usu.Telefono;

        }

        private void btnActualizar_Click(object sender, System.EventArgs e)
        {

        }
    }
}
