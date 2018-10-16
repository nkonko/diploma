﻿// <auto-generated/>
namespace UI
{
    using BLL;
    using DAL.Utils;
    using log4net;
    using System;
    using System.Windows.Forms;

    public partial class ABMusuario : Form, IABMUsuario
    {
        ////private readonly IPrincipal principal;
        ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IUsuarioBLL usuarioBLL;

        public ABMusuario()
        {
            ///this.principal = principal;
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void usuarios_Load(object sender, EventArgs e)
        {
            usuarioBLL = IoCContainer.Resolve<IUsuarioBLL>();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
           var creado = usuarioBLL.Crear(new BE.Usuario() { Nombre = txtNombre.Text, Apellido = txtApellido.Text, Email = txtEmail.Text, Telefono = Int32.Parse(txtTel.Text), PrimerLogin = true, CIngresos = 0, Activo = true });
            if (creado)
            {
                log.Info("Se ha creado un nuevo usuario");
                MessageBox.Show("Registro exitoso");
            }
            else
            {
                log.Info("El registro de nuevo usuario ha fallado");
                MessageBox.Show("El registro de nuevo usuario ha fallado");
            }
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            usuarioBLL.Actualizar(new BE.Usuario() { Nombre = txtNombre.Text, Apellido = txtApellido.Text, Email = txtEmail.Text, Telefono = Int32.Parse(txtTel.Text), PrimerLogin = true, CIngresos = 0, Activo = true });
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            usuarioBLL.Borrar(new BE.Usuario() { Email = txtEmail.Text });
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
           ////principal.Show();
        }
    }
}
