﻿// <auto-generated/>
namespace UI
{
    using BE.Entidades;
    using BLL;
    using DAL.Dao;
    using log4net;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    public partial class ABMusuario : Form, IABMUsuario
    {

        private readonly IDigitoVerificador digitoVerificador;
        private readonly IFamiliaBLL familiasBLL;
        private readonly IPatenteBLL patenteBLL;
        private readonly IBitacoraBLL bitacoraBLL;
        private readonly IFormControl formControl;
        private const int formId = 1;
        private bool habilitada = false;
        private bool negada = false;
        private bool checkeadafam = false;
        private bool checkeadapat = false;

        ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IUsuarioBLL usuarioBLL;

        public ABMusuario(IBitacoraBLL bitacoraBLL, IFormControl formControl, IFamiliaBLL familiasBLL, IPatenteBLL patenteBLL, IDigitoVerificador digitoVerificador)
        {
            this.bitacoraBLL = bitacoraBLL;
            this.formControl = formControl;
            this.familiasBLL = familiasBLL;
            this.patenteBLL = patenteBLL;
            this.digitoVerificador = digitoVerificador;
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
            var patentes = patenteBLL.Cargar();

            if (!patForm.Exists(item => patUsu.Patentes.Select(item2 => item2.IdPatente).Contains(item.IdPatente = patentes.Where(p => (p.Descripcion == "Alta Usuario")).Select(p => p.IdPatente).FirstOrDefault())))
            {
                btnNuevo.Enabled = false;
            }
            if (!patForm.Exists(item => patUsu.Patentes.Select(item2 => item2.IdPatente).Contains(item.IdPatente = patentes.Where(p => (p.Descripcion == "Baja Usuario")).Select(p => p.IdPatente).FirstOrDefault())))
            {
                btnBorrar.Enabled = false;
            }
            if (!patForm.Exists(item => patUsu.Patentes.Select(item2 => item2.IdPatente).Contains(item.IdPatente = patentes.Where(p => (p.Descripcion == "Mod Usuario")).Select(p => p.IdPatente).FirstOrDefault())))
            {
                btnModificar.Enabled = false;
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            var crear = verificarDatos();
            if (crear)
            {
                var creado = usuarioBLL.Crear(
                    new Usuario()
                    {
                        Nombre = txtNombre.Text,
                        Apellido = txtApellido.Text,
                        Email = txtEmail.Text,
                        Telefono = Int32.Parse(txtTel.Text),
                        Domicilio = txtDomicilio.Text,
                        PrimerLogin = true,
                        CIngresos = 0,
                        Activo = true
                    });

                var usu = usuarioBLL.ObtenerUsuarioConEmail(txtEmail.Text);

                if (creado)
                {
                    GuardarPatentesFamilias(usu);

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
            var usu = usuarioBLL.ObtenerUsuarioConEmail(txtEmail.Text);

            if (modificado)
            {
                GuardarPatentesFamilias(usu);

                log.Info("Se ha creado un nuevo usuario");
                bitacoraBLL.RegistrarEnBitacora(usuActivo);
                MessageBox.Show("Modificacion exitosa");
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

        private void btnNegarPat_Click(object sender, EventArgs e)
        {
            var usuario = (Usuario)dgusuario.CurrentRow.DataBoundItem;

            if (negada)
            {
                var hecho = patenteBLL.HabilitarPatente(patenteBLL.ObtenerIdPatentePorDescripcion(chkLstPatentes.SelectedItem.ToString()), usuario.UsuarioId);
                if (hecho)
                {
                    btnNegarPat.Text = "Negar Patente";
                    habilitada = true;
                    negada = false;
                    ControlPatentes();
                }
            }
            else if (habilitada)
            {
                var hecho = patenteBLL.NegarPatente(patenteBLL.ObtenerIdPatentePorDescripcion(chkLstPatentes.SelectedItem.ToString()), usuario.UsuarioId);
                if (hecho)
                {
                    btnNegarPat.Text = "Habilitar Patente";
                    negada = true;
                    habilitada = false;
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

        public void GuardarPatentesFamilias(Usuario usu)
        {
            var patentes = patenteBLL.ConsultarPatenteUsuario(usu.UsuarioId);
            var familias = familiasBLL.ObtenerIdsFamiliasPorUsuario(usu.UsuarioId);

            if (checkeadafam)
            {
                foreach (string descripcion in chkLstFamilia.SelectedItems)
                {
                    var ids = new List<int>();
                    ids.Add(familiasBLL.ObtenerIdFamiliaPorDescripcion(descripcion));

                    var asignada = familias.Any(idFam => ids.Any(id => id == idFam));

                    if (!asignada)
                    {
                        familiasBLL.GuardarFamiliasUsuario(ids, usu.UsuarioId);
                    }
                    else
                    {
                        familiasBLL.BorrarFamiliasUsuario(ids, usu.UsuarioId);
                    }
                }
            }

            if (checkeadapat)
            {
                foreach (string descripcion in chkLstPatentes.SelectedItems)
                {
                    var ids = new List<int>();
                    ids.Add(patenteBLL.ObtenerIdPatentePorDescripcion(descripcion));
                    var asignada = patentes.Any(idPat => ids.Any(id => id == idPat.IdPatente));

                    if (!asignada)
                    {
                        patenteBLL.GuardarPatentesUsuario(ids, usu.UsuarioId);
                    }
                    else
                    {
                        patenteBLL.BorrarPatentesUsuario(ids, usu.UsuarioId);
                    }
                }
            }
        }

        private void dgusuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = dgusuario.Rows[e.RowIndex];

            txtNombre.Text = selectedRow.Cells[0].Value.ToString();
            txtApellido.Text = selectedRow.Cells[1].Value.ToString();
            txtEmail.Text = selectedRow.Cells[2].Value.ToString();
            txtTel.Text = selectedRow.Cells[3].Value.ToString();
            txtDomicilio.Text = selectedRow.Cells[4].Value.ToString();

            var usu = usuarioBLL.ObtenerUsuarioConEmail(txtEmail.Text);
            var patentes = patenteBLL.ConsultarPatenteUsuario(usu.UsuarioId);
            var familias = familiasBLL.ObtenerIdsFamiliasPorUsuario(usu.UsuarioId);

            BorrarChecks();
            SetearChecks(patentes, familias);

            checkeadafam = false;
            checkeadapat = false;
        }

        private void BorrarChecks()
        {
            while (chkLstFamilia.CheckedIndices.Count > 0)
                chkLstFamilia.SetItemChecked(chkLstFamilia.CheckedIndices[0], false);

            while (chkLstPatentes.CheckedIndices.Count > 0)
                chkLstPatentes.SetItemChecked(chkLstPatentes.CheckedIndices[0], false);
        }

        private void SetearChecks(List<UsuarioPatente> patentes, List<int> familias)
        {
            foreach (var id in familias)
            {
                chkLstFamilia.SetItemChecked(id - 1, true);
            }

            foreach (var pat in patentes)
            {
                chkLstPatentes.SetItemChecked(pat.IdPatente - 1, true);
            }
        }

        private void chkLstPatentes_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            checkeadapat = true;
        }

        private void chkLstFamilia_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            checkeadafam = true;
        }
    }
}
