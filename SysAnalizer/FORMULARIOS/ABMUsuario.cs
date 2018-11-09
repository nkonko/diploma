﻿// <auto-generated/>
namespace UI
{
    using BE.Entidades;
    using BLL;
    using log4net;
    using System;
    using System.Linq;
    using System.Windows.Forms;

    public partial class ABMusuario : Form, IABMUsuario
    {
        private readonly IFamiliaBLL familiasBLL;
        private readonly IPatenteBLL patenteBLL;
        private readonly IBitacoraBLL bitacoraBLL;
        private readonly IFormControl formControl;
        private const int formId = 1;
        private bool habilitada = false;
        private bool negada = false;

        ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IUsuarioBLL usuarioBLL;

        public ABMusuario(IBitacoraBLL bitacoraBLL, IFormControl formControl, IFamiliaBLL familiasBLL, IPatenteBLL patenteBLL)
        {
            this.bitacoraBLL = bitacoraBLL;
            this.formControl = formControl;
            this.familiasBLL = familiasBLL;
            this.patenteBLL = patenteBLL;
            InitializeComponent();
            dgusuario.AutoGenerateColumns = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void usuarios_Load(object sender, EventArgs e)
        {
            btnNegarPat.Enabled = false;
            ControlPatentes();
            usuarioBLL = IoCContainer.Resolve<IUsuarioBLL>();
            CargarRefrescarDatagrid();
            chkLstPatentes.DataSource = patenteBLL.Cargar().Select(pat => pat.Descripcion).ToList();
            chkLstFamilia.DataSource = familiasBLL.Cargar().Select(fam => fam.Descripcion).ToList();
        }

        private void ControlPatentes()
        {
            var patForm = formControl.ObtenerPermisosFormulario(formId);
            var patUsu = formControl.ObtenerPermisosUsuario();

            if (!patForm.Exists(item => patUsu.Patentes.Select(item2 => item2.IdPatente).Contains(item.IdPatente = 1)))
            {
                btnNuevo.Enabled = false;
            }
            if (!patForm.Exists(item => patUsu.Patentes.Select(item2 => item2.IdPatente).Contains(item.IdPatente = 2)))
            {
                btnBorrar.Enabled = false;
            }
            if (!patForm.Exists(item => patUsu.Patentes.Select(item2 => item2.IdPatente).Contains(item.IdPatente = 8)))
            {
                btnModificar.Enabled = false;
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            var crear = verificarDatos();
            if (crear)
            {
                var creado = usuarioBLL.Crear(new Usuario() { Nombre = txtNombre.Text, Apellido = txtApellido.Text, Email = txtEmail.Text, Telefono = Int32.Parse(txtTel.Text), Domicilio = txtDomicilio.Text, PrimerLogin = true, CIngresos = 0, Activo = true });
                var usu = usuarioBLL.ObtenerUsuarioConEmail(txtEmail.Text);
                if (creado)
                {
                    familiasBLL.GuardarFamiliaUsuario(familiasBLL.ObtenerIdFamiliaPorDescripcion(chkLstFamilia.SelectedItem.ToString()), usu.UsuarioId);
                    patenteBLL.GuardarPatenteUsuario(patenteBLL.ObtenerIdPatentePorDescripcion(chkLstPatentes.SelectedItem.ToString()), usu.UsuarioId);
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
            var modificado = usuarioBLL.Actualizar(new Usuario() { Nombre = txtNombre.Text, Apellido = txtApellido.Text, Email = txtEmail.Text, Telefono = Int32.Parse(txtTel.Text), Domicilio = txtDomicilio.Text, PrimerLogin = true, CIngresos = 0, Activo = true });
            var usuActivo = formControl.ObtenerInfoUsuario();

            if (modificado)
            {
                log.Info("Se ha creado un nuevo usuario");
                bitacoraBLL.RegistrarEnBitacora(usuActivo);
                MessageBox.Show("Modificacion exitosa");
                dgusuario.Rows.Clear();
                CargarRefrescarDatagrid();
            }
            else
            {
                log.Info("La modificacion ha fallado");
                bitacoraBLL.RegistrarEnBitacora(usuActivo);
                MessageBox.Show("La modificacion ha fallado");
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            var usuario = (Usuario)dgusuario.CurrentRow.DataBoundItem;
            var sinPatentes = patenteBLL.ComprobarPatentesUsuario(usuario.UsuarioId);
            if (sinPatentes)
            {
                var borrado = usuarioBLL.Borrar(usuario);
                var usuActivo = formControl.ObtenerInfoUsuario();

                if (borrado)
                {
                    log.Info("Se ha creado un nuevo usuario");
                    bitacoraBLL.RegistrarEnBitacora(usuActivo);
                    MessageBox.Show("Borrado exitoso");
                    CargarRefrescarDatagrid();
                }
                else
                {
                    log.Info("El borrado de usuario ha fallado");
                    bitacoraBLL.RegistrarEnBitacora(usuActivo);
                    MessageBox.Show("El borrado de usuario ha fallado");
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            ////principal.Show();
        }

        private void CargarRefrescarDatagrid()
        {
            var usuarios = usuarioBLL.Cargar();

            dgusuario.DataSource = usuarios;
            Usuario obj = (Usuario)dgusuario.CurrentRow.DataBoundItem;
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

            if (chkLstFamilia.CheckedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una familia");
                returnValue = false;
            }

            if (chkLstPatentes.CheckedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos una patente");
                returnValue = false;
            }

            return returnValue;
        }
       
        ///revisar como bloquear el switch de patentes y cambio de usuario que deja el boton habilitado
        private void btnNegarPat_Click(object sender, EventArgs e)
        {
            var usuario = (Usuario)dgusuario.CurrentRow.DataBoundItem;

            if (negada)
            {
                var hecho = patenteBLL.HabilitarPatente(patenteBLL.ObtenerIdPatentePorDescripcion(chkLstPatentes.SelectedItem.ToString()), usuario.UsuarioId);
                if (hecho)
                {
                    btnNegarPat.Text = "Negar Patente";
                    ControlPatentes();
                }
            }
            else if (habilitada)
            {
                var hecho = patenteBLL.NegarPatente(patenteBLL.ObtenerIdPatentePorDescripcion(chkLstPatentes.SelectedItem.ToString()), usuario.UsuarioId);
                if (hecho)
                {
                    btnNegarPat.Text = "Habilitar Patente";
                    ControlPatentes();
                }
            }
        }

        private void chkLstPatentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var usuario = (Usuario)dgusuario.CurrentRow.DataBoundItem;
            var patentes = patenteBLL.ConsultarPatenteUsuario(usuario.UsuarioId);
            var negadas = patentes.Where(pat => (pat.Negada == true)).ToList();

            if (patentes.Count > 0)
            {
                if (negadas.Exists(x => x.IdPatente == patenteBLL.ObtenerIdPatentePorDescripcion(chkLstPatentes.SelectedItem.ToString())))
                {
                    btnNegarPat.Text = "Habilitar Patente";
                    negada = true;
                    habilitada = false;
                }
                else
                {
                    btnNegarPat.Text = "Negar Patente";
                    habilitada = true;
                    negada = false;
                }
            }
            else
            {
                btnNegarPat.Enabled = false;
            }
        }

        private void dgusuario_SelectionChanged(object sender, EventArgs e)
        {
            var usuario = (Usuario)dgusuario.CurrentRow.DataBoundItem;
            var patentes = patenteBLL.ConsultarPatenteUsuario(usuario.UsuarioId);
            if (patentes.Count > 0)
            {
                btnNegarPat.Enabled = true;
            }
            else
            {
                btnNegarPat.Enabled = false;
            }

            }
    }
}
