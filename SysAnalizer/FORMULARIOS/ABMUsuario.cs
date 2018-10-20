﻿// <auto-generated/>
namespace UI
{
    using BE.Entidades;
    using BLL;
    using log4net;
    using Microsoft.VisualBasic;
    using System;
    using System.Windows.Forms;

    public partial class ABMusuario : Form, IABMUsuario
    {
        ////private readonly IPrincipal principal;
        private readonly IBitacoraBLL bitacoraBLL;
        private readonly IFormControl formControl;

        ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IUsuarioBLL usuarioBLL;

        public ABMusuario(IBitacoraBLL bitacoraBLL, IFormControl formControl)
        {
            this.bitacoraBLL = bitacoraBLL;
            this.formControl = formControl;
            ///this.principal = principal;
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void usuarios_Load(object sender, EventArgs e)
        {
            usuarioBLL = IoCContainer.Resolve<IUsuarioBLL>();
            dgusuario.DataSource = usuarioBLL.Cargar();
            dgusuario.Columns.Remove("IdUsuario");
            dgusuario.Columns.Remove("PrimerLogin");
            dgusuario.Columns.Remove("IdIdioma");
            dgusuario.Columns.Remove("IdCanalVenta");
            dgusuario.Columns.Remove("Activo");
            dgusuario.Columns.Remove("CIngresos");
            dgusuario.Columns.Remove("DVH");
            dgusuario.Refresh();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            var creado = usuarioBLL.Crear(new Usuario() { Nombre = txtNombre.Text, Apellido = txtApellido.Text, Email = txtEmail.Text, Telefono = Int32.Parse(txtTel.Text), PrimerLogin = true, CIngresos = 0, Activo = true });
            var usu = formControl.ObtenerInfoUsuario();
            if (creado)
            {
                log.Info("Se ha creado un nuevo usuario");
                bitacoraBLL.RegistrarEnBitacora(usu);
                MessageBox.Show("Registro exitoso");
                dgusuario.Rows.Clear();
                dgusuario.DataSource = usuarioBLL.Cargar();
                dgusuario.Refresh();
            }
            else
            {
                log.Info("El registro de nuevo usuario ha fallado");
                bitacoraBLL.RegistrarEnBitacora(usu);
                MessageBox.Show("El registro de nuevo usuario ha fallado");
            }
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            var modificado = usuarioBLL.Actualizar(new Usuario() { Nombre = txtNombre.Text, Apellido = txtApellido.Text, Email = txtEmail.Text, Telefono = Int32.Parse(txtTel.Text), PrimerLogin = true, CIngresos = 0, Activo = true });
            var usu = formControl.ObtenerInfoUsuario();
            if (modificado)
            {
                log.Info("Se ha creado un nuevo usuario");
                bitacoraBLL.RegistrarEnBitacora(usu);
                MessageBox.Show("Registro exitoso");
                dgusuario.Rows.Clear();
                dgusuario.DataSource = usuarioBLL.Cargar();
                dgusuario.Refresh();
            }
            else
            {
                log.Info("El registro de nuevo usuario ha fallado");
                bitacoraBLL.RegistrarEnBitacora(usu);
                MessageBox.Show("El registro de nuevo usuario ha fallado");
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            var usuario = new Usuario() { Email = Interaction.InputBox("Ingrese email", "Borrar Usuario") };
            var borrado = usuarioBLL.Borrar(usuario);
            var usu = formControl.ObtenerInfoUsuario();
            if (borrado)
            {
                log.Info("Se ha creado un nuevo usuario");
                bitacoraBLL.RegistrarEnBitacora(usu);
                MessageBox.Show("Registro exitoso");
                dgusuario.Rows.Clear();
                dgusuario.DataSource = usuarioBLL.Cargar();
                dgusuario.Refresh();
            }
            else
            {
                log.Info("El registro de nuevo usuario ha fallado");
                bitacoraBLL.RegistrarEnBitacora(usu);
                MessageBox.Show("El registro de nuevo usuario ha fallado");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            ////principal.Show();
        }
    }
}
