﻿// <auto-generated/>
namespace UI
{
    using System.Windows.Forms;
    using BE.Entidades;
    using BLL;
    using EasyEncryption;

    public partial class DatosUsuario : Form, IDatosUsuario
    {
        private readonly IFormControl formControl;
        private readonly IUsuarioBLL usuarioBLL;

        public const string key = "bZr2URKx";
        public const string iv = "HNtgQw0w";

        public Usuario UsuarioActivo { get; set; }

        public DatosUsuario(IFormControl formControl, IUsuarioBLL usuarioBLL)
        {
            this.usuarioBLL = usuarioBLL;
            this.formControl = formControl;
            InitializeComponent();
        }

        private void DatosUsuario_Load(object sender, System.EventArgs e)
        {
            UsuarioActivo = formControl.ObtenerInfoUsuario();

            lblNombre.Text = lblNombre.Text + UsuarioActivo.Nombre;
            lblApellido.Text = lblApellido.Text + UsuarioActivo.Apellido;
            lblDireccion.Text = lblDireccion.Text + UsuarioActivo.Domicilio;
            lblEmail.Text = lblEmail.Text + DES.Decrypt(UsuarioActivo.Email, key, iv);
            lblTelefono.Text = lblTelefono.Text + UsuarioActivo.Telefono;
        }

        private void btnActualizar_Click(object sender, System.EventArgs e)
        {
            usuarioBLL.Actualizar(new Usuario() { Nombre = txtNombre.Text, Telefono = int.Parse(txtTel.Text), Apellido = txtApellido.Text, Domicilio = txtDireccion.Text, Email = DES.Decrypt(UsuarioActivo.Email, key, iv) });
        }

        private void DatosUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }

        private void btnCambiarDatos_Click(object sender, System.EventArgs e)
        {
            txtNombre.Visible = true;
            txtApellido.Visible = true;
            txtDireccion.Visible = true;
            txtTel.Visible = true;

        }
    }
}
