﻿// <auto-generated/>
namespace UI
{
    using BE.Entidades;
    using BLL;
    using BLL.Imp;
    using log4net;
    using Microsoft.VisualBasic;
    using System;
    using System.Linq;
    using System.Windows.Forms;

    public partial class ABMusuario : Form, IABMUsuario
    {
        ////private readonly IPrincipal principal;
        private readonly IFamiliaBLL familiasBLL;
        private readonly IPatenteBLL patenteBLL;
        private readonly IBitacoraBLL bitacoraBLL;
        private readonly IFormControl formControl;

        ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IUsuarioBLL usuarioBLL;

        public ABMusuario(IBitacoraBLL bitacoraBLL, IFormControl formControl, IFamiliaBLL familiasBLL, IPatenteBLL patenteBLL)
        {
            this.bitacoraBLL = bitacoraBLL;
            this.formControl = formControl;
            this.familiasBLL = familiasBLL;
            this.patenteBLL = patenteBLL;
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void usuarios_Load(object sender, EventArgs e)
        {
            usuarioBLL = IoCContainer.Resolve<IUsuarioBLL>();
            CargarRefrescarDatagrid();
            chkLstPatentes.DataSource = patenteBLL.Cargar().Select(pat => pat.Descripcion).ToList();
            cboFamilia.DataSource = familiasBLL.Cargar().Select(fam => fam.Descripcion).ToList();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            var crear = verificarDatos();
            if (crear)
            {
                var creado = usuarioBLL.Crear(new Usuario() { Nombre = txtNombre.Text, Apellido = txtApellido.Text, Email = txtEmail.Text, Telefono = Int32.Parse(txtTel.Text), PrimerLogin = true, CIngresos = 0, Activo = true });
                var usu = formControl.ObtenerInfoUsuario();
                if (creado)
                {
                    familiasBLL.GuardarFamiliaUsuario(familiasBLL.ObtenerIdFamiliaPorDescripcion(cboFamilia.SelectedText), usu.IdUsuario);
                    patenteBLL.GuardarPatenteUsuario(patenteBLL.ObtenerIdPatentePorDescripcion(chkLstPatentes.SelectedItem.ToString()), usu.IdUsuario);
                    log.Info("Se ha creado un nuevo usuario");
                    bitacoraBLL.RegistrarEnBitacora(usu);
                    MessageBox.Show("Registro exitoso");
                    CargarRefrescarDatagrid();
                }
                else
                {
                    log.Info("El registro de nuevo usuario ha fallado");
                    bitacoraBLL.RegistrarEnBitacora(usu);
                    MessageBox.Show("El registro de nuevo usuario ha fallado");
                }

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
                MessageBox.Show("Modificacion exitosa");
                dgusuario.Rows.Clear();
                CargarRefrescarDatagrid();
            }
            else
            {
                log.Info("La modificacion ha fallado");
                bitacoraBLL.RegistrarEnBitacora(usu);
                MessageBox.Show("La modificacion ha fallado");
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
                MessageBox.Show("Borrado exitoso");
                CargarRefrescarDatagrid();
            }
            else
            {
                log.Info("El borrado de usuario ha fallado");
                bitacoraBLL.RegistrarEnBitacora(usu);
                MessageBox.Show("El borrado de usuario ha fallado");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            ////principal.Show();
        }

        private void CargarRefrescarDatagrid()
        {
            dgusuario.DataSource = usuarioBLL.Cargar();
            dgusuario.Columns.Remove("IdUsuario");
            dgusuario.Columns.Remove("PrimerLogin");
            dgusuario.Columns.Remove("IdIdioma");
            dgusuario.Columns.Remove("IdCanalVenta");
            dgusuario.Columns.Remove("Activo");
            dgusuario.Columns.Remove("Contraseña");
            dgusuario.Columns.Remove("CIngresos");
            dgusuario.Columns.Remove("DVH");
            dgusuario.Refresh();
        }
        private bool verificarDatos()
        {
            var returnValue = true;
            foreach (TextBox tb in Controls.OfType<TextBox>())
            {
                if (string.IsNullOrEmpty(tb.Text.Trim()))
                {
                    MessageBox.Show("Todos los datos deben estar completos");
                    returnValue = false;
                    break;
                }
            }

            if (string.IsNullOrEmpty(cboFamilia.SelectedItem.ToString()))
            {
                MessageBox.Show("Debe seleccionar una familia");
                returnValue = false;
            }

            if (chkLstPatentes.Items.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos una patente");
                returnValue = false;
            }

            return returnValue;
        }
    }
}
