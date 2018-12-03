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
    using EasyEncryption;
    using DAL;

    public partial class ABMusuario : Form, IABMUsuario
    {
        private readonly IDigitoVerificador digitoVerificador;
        private readonly IFamiliaBLL familiasBLL;
        private readonly IPatenteBLL patenteBLL;
        private readonly IBitacoraBLL bitacoraBLL;
        private readonly IFormControl formControl;
        private readonly IBloqueoUsuario bloqueoUsuario;

        private const int formId = 3;
        private const string entidad = "Usuario";
        public const string key = "bZr2URKx";
        public const string iv = "HNtgQw0w";

        private bool habilitada = false;
        private bool negada = false;
        private bool checkeadafam = false;
        private bool checkeadapat = false;

        public Usuario UsuarioActivo { get; set; }

        public Usuario UsuarioSeleccionado { get; set; } = new Usuario();

        public List<Usuario> usuariosBD { get; set; } = new List<Usuario>() { new Usuario() };

        ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IUsuarioBLL usuarioBLL;

        public ABMusuario(IBitacoraBLL bitacoraBLL, IFormControl formControl, IFamiliaBLL familiasBLL, IPatenteBLL patenteBLL, IDigitoVerificador digitoVerificador, IBloqueoUsuario bloqueoUsuario)
        {
            this.bitacoraBLL = bitacoraBLL;
            this.formControl = formControl;
            this.familiasBLL = familiasBLL;
            this.patenteBLL = patenteBLL;
            this.digitoVerificador = digitoVerificador;
            this.bloqueoUsuario = bloqueoUsuario;
            InitializeComponent();
            dgusuario.AutoGenerateColumns = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void usuarios_Load(object sender, EventArgs e)
        {
            chkLstPatentes.Enabled = false;
            chkLstFamilia.Enabled = false;
            btnNegarPat.Enabled = true;

            ControlPatentes();

            usuarioBLL = IoCContainer.Resolve<IUsuarioBLL>();
            UsuarioActivo = formControl.ObtenerInfoUsuario();

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
            if (!usuariosBD.Exists(usuario => usuario.Email == txtEmail.Text))
            {
                var permitir = verificarDatos();
                if (permitir)
                {
                    var creado = usuarioBLL.Crear(
                        new Usuario()
                        {
                            Nombre = txtNombre.Text,
                            Apellido = txtApellido.Text,
                            Email = txtEmail.Text,
                            Telefono = int.Parse(txtTel.Text),
                            Domicilio = txtDomicilio.Text,
                            PrimerLogin = true,
                            ContadorIngresosIncorrectos = 0,
                            Activo = true
                        });

                    var usu = usuarioBLL.ObtenerUsuarioConEmail(txtEmail.Text);

                    if (creado)
                    {
                        if (digitoVerificador.ComprobarPrimerDigito(digitoVerificador.Entidades.Find(x => x == entidad)))
                        {
                            digitoVerificador.InsertarDVVertical(digitoVerificador.Entidades.Find(x => x == entidad));
                        }
                        else
                        {
                            digitoVerificador.ActualizarDVVertical(digitoVerificador.Entidades.Find(x => x == entidad));
                        }

                        Log4netExtensions.Media(log, "Se ha creado un nuevo usuario");
                        bitacoraBLL.RegistrarEnBitacora(usu);
                        MessageBox.Show("Registro exitoso");
                        CargarRefrescarDatagrid();
                    }
                    else
                    {
                        Log4netExtensions.Baja(log, "El registro de nuevo usuario ha fallado");
                        bitacoraBLL.RegistrarEnBitacora(usu);
                        MessageBox.Show("El registro de nuevo usuario ha fallado");
                    }
                }
            }
            else
            {
                MessageBox.Show("No pueden haber 2 usuarios con el mismo email");
                Log4netExtensions.Alta(log, "Se intento guardar o modificar un usuario con el mismo email");
            }
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            var permitir = verificarDatos();
            if (permitir)
            {
                var modificado = usuarioBLL.Actualizar(new Usuario() { Nombre = txtNombre.Text, Apellido = txtApellido.Text, Email = txtEmail.Text, Telefono = int.Parse(txtTel.Text), Domicilio = txtDomicilio.Text, PrimerLogin = true, ContadorIngresosIncorrectos = 0, Activo = true });

                if (modificado)
                {
                    if (digitoVerificador.ComprobarPrimerDigito(digitoVerificador.Entidades.Find(x => x == entidad)))
                    {
                        digitoVerificador.InsertarDVVertical(digitoVerificador.Entidades.Find(x => x == entidad));
                    }
                    else
                    {
                        digitoVerificador.ActualizarDVVertical(digitoVerificador.Entidades.Find(x => x == entidad));
                    }

                    Log4netExtensions.Baja(log, string.Format("Se ha modificado al usuario {0}", DES.Decrypt(UsuarioSeleccionado.Email, key, iv)));
                    bitacoraBLL.RegistrarEnBitacora(UsuarioActivo);
                    MessageBox.Show("Modificacion exitosa");
                    CargarRefrescarDatagrid();
                }
                else
                {
                    Log4netExtensions.Baja(log, "La modificacion ha fallado");
                    bitacoraBLL.RegistrarEnBitacora(UsuarioActivo);
                    MessageBox.Show("La modificacion ha fallado");
                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            var esBorrado = true;

            var permitir = verificarDatos();
            permitir = CheckeoPatentes(UsuarioSeleccionado, esBorrado);

            if (permitir)
            {
                var borrado = usuarioBLL.Borrar(UsuarioSeleccionado);

                if (borrado)
                {
                    familiasBLL.BorrarFamiliasUsuario(UsuarioSeleccionado.Familia, UsuarioSeleccionado.UsuarioId);

                    if (digitoVerificador.ComprobarPrimerDigito(digitoVerificador.Entidades.Find(x => x == entidad)))
                    {
                        digitoVerificador.InsertarDVVertical(digitoVerificador.Entidades.Find(x => x == entidad));
                    }
                    else
                    {
                        digitoVerificador.ActualizarDVVertical(digitoVerificador.Entidades.Find(x => x == entidad));
                    }

                    Log4netExtensions.Alta(log, string.Format("Se borrado al usuario {0}", UsuarioSeleccionado.Email));
                    bitacoraBLL.RegistrarEnBitacora(UsuarioActivo);
                    MessageBox.Show("Borrado exitoso");
                    CargarRefrescarDatagrid();
                }
                else
                {
                    Log4netExtensions.Baja(log, "El borrado de usuario ha fallado");
                    bitacoraBLL.RegistrarEnBitacora(UsuarioActivo);
                    MessageBox.Show("El borrado de usuario ha fallado");
                }
            }
            else
            {
                Log4netExtensions.Media(log, "Una patente se encuentra en uso y no puede borrarse");
                bitacoraBLL.RegistrarEnBitacora(UsuarioActivo);
                Alert.ShowSimpleAlert("MSJ", "Una patente se encuentra en uso y no puede borrarse");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void CargarRefrescarDatagrid()
        {
            usuariosBD = usuarioBLL.Cargar();

            foreach (var usuario in usuariosBD)
            {
                usuario.Email = DES.Decrypt(usuario.Email, key, iv);
            }

            dgusuario.DataSource = usuariosBD;
            dgusuario.Refresh();
        }

        private bool verificarDatos()
        {
            var returnValue = true;

            if (txtEmail.Text == DES.Decrypt(UsuarioActivo.Email, key, iv))
            {
                MessageBox.Show("No puede realizar acciones sobre el usuario activo");
                Log4netExtensions.Alta(log, "Se intento eliminar o modificar al usuario activo");
                returnValue = false;
            }

            foreach (TextBox tb in Controls.OfType<TextBox>())
            {
                if (string.IsNullOrEmpty(tb.Text.Trim()))
                {
                    MessageBox.Show("Todos los datos deben estar completos");
                    Log4netExtensions.Baja(log, "Todos los datos deben estar completos");
                    returnValue = false;
                    break;
                }
            }

            return returnValue;
        }

        public bool CheckeoPatentes(Usuario usuario, bool requestFamilia = false, bool requestFamiliaUsuario = false, bool esBorrado = false, int idFamiliaAQuitar = 0)
        {
            var returnValue = true;
            if (usuario.Patentes.Count > 0 || usuario.Familia.Count > 0)
            {
                returnValue = patenteBLL.CheckeoDePatentesParaBorrar(usuario, requestFamilia, requestFamiliaUsuario, esBorrado, idFamiliaAQuitar);
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
                var id = patenteBLL.ObtenerIdPatentePorDescripcion(chkLstPatentes.SelectedItem.ToString());

                usuario.Familia = new List<Familia>();
                usuario.Familia = familiasBLL.ObtenerFamiliasUsuario(usuario.UsuarioId);

                if (CheckeoPatentes(usuario))
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
                else
                {
                    Alert.ShowSimpleAlert("Al menos un usuario debe tener asignada esta patente");
                    Log4netExtensions.Alta(log, "Al menos un usuario debe tener asignada esta patente");
                }
            }
        }

        private void chkLstPatentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var usuario = (Usuario)dgusuario.CurrentRow.DataBoundItem;
            var patentes = patenteBLL.ConsultarPatenteUsuario(usuario.UsuarioId);
            var negadas = patentes.Where(pat => (pat.Negada == true)).ToList();

            //if (patentes.Count > 0)
            //{
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
            //}
        }

        private void dgusuario_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                UsuarioSeleccionado = (Usuario)dgusuario.CurrentRow.DataBoundItem;
                var patentes = patenteBLL.ConsultarPatenteUsuario(UsuarioSeleccionado.UsuarioId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgusuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UsuarioSeleccionado = (Usuario)dgusuario.CurrentRow.DataBoundItem;

            chkLstPatentes.Enabled = true;
            chkLstFamilia.Enabled = true;

            checkeadapat = true;
            checkeadafam = true;

            if (e.RowIndex < 0)
            {
                return;
            }

            CargaControles();

            CargarPatentesFamiliaUsuarioSeleccionado();

            BorrarChecks();
            SetearChecks(UsuarioSeleccionado.Patentes, UsuarioSeleccionado.Familia);

            checkeadafam = false;
            checkeadapat = false;
        }

        private void CargarPatentesFamiliaUsuarioSeleccionado()
        {
            FormExtensions.CatchException(this, () =>
            {
                UsuarioSeleccionado.Patentes = new List<Patente>();
                UsuarioSeleccionado.Familia = new List<Familia>();
                UsuarioSeleccionado.Patentes.AddRange(usuarioBLL.ObtenerPatentesDeUsuario(UsuarioSeleccionado.UsuarioId));

                var familiasIds = familiasBLL.ObtenerIdsFamiliasPorUsuario(UsuarioSeleccionado.UsuarioId);
                familiasIds.ForEach(id => UsuarioSeleccionado.Familia.Add(new Familia() { FamiliaId = id }));
            });
        }

        private void CargaControles()
        {
            FormExtensions.CatchException(this, () =>
            {
                txtNombre.Text = UsuarioSeleccionado.Nombre;
                txtApellido.Text = UsuarioSeleccionado.Apellido;
                txtEmail.Text = UsuarioSeleccionado.Email;
                txtTel.Text = UsuarioSeleccionado.Telefono.ToString();
                txtDomicilio.Text = UsuarioSeleccionado.Domicilio;
            });
        }

        private void BorrarChecks()
        {
            FormExtensions.CatchException(this, () =>
            {
                while (chkLstFamilia.CheckedIndices.Count > 0)
                    chkLstFamilia.SetItemChecked(chkLstFamilia.CheckedIndices[0], false);

                while (chkLstPatentes.CheckedIndices.Count > 0)
                    chkLstPatentes.SetItemChecked(chkLstPatentes.CheckedIndices[0], false);
            });
        }

        private void SetearChecks(List<Patente> patentes, List<Familia> familias)
        {
            FormExtensions.CatchException(this, () =>
            {
                foreach (var familia in familias)
                {
                    var descFamilia = familiasBLL.Cargar().Where(x => x.FamiliaId == familia.FamiliaId).Select(x => x.Descripcion).ToList()[0];
                    chkLstFamilia.SetItemChecked(chkLstFamilia.FindString(descFamilia), true);
                    checkeadafam = true;
                }

                foreach (var pat in patentes)
                {
                    var descPatente = patenteBLL.Cargar().Where(x => x.IdPatente == pat.IdPatente).Select(x => x.Descripcion).ToList()[0];
                    chkLstPatentes.SetItemChecked(chkLstPatentes.FindString(descPatente), true);
                    checkeadapat = true;
                }
            });
        }

        private void chkLstPatentes_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!checkeadapat)
            {
                var ids = new List<int>();
                var usuario = (Usuario)dgusuario.CurrentRow.DataBoundItem;

                if (!chkLstPatentes.GetItemChecked(chkLstPatentes.SelectedIndex))
                {
                    ids.Add(patenteBLL.ObtenerIdPatentePorDescripcion(chkLstPatentes.SelectedItem.ToString()));

                    patenteBLL.GuardarPatentesUsuario(ids, usuario.UsuarioId);

                }
                else
                {
                    ids.Add(patenteBLL.ObtenerIdPatentePorDescripcion(chkLstPatentes.SelectedItem.ToString()));

                    if (CheckeoPatentes(usuario))
                    {
                        patenteBLL.BorrarPatentesUsuario(ids, usuario.UsuarioId);
                    }
                    else
                    {
                        Alert.ShowSimpleAlert("Al menos un usuario debe tener asignada esta patente");
                        Log4netExtensions.Alta(log, "Al menos un usuario debe tener asignada esta patente");
                    }
                }
            }
        }

        private void chkLstFamilia_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!checkeadafam)
            {
                var ids = new List<int>();
                var usuario = (Usuario)dgusuario.CurrentRow.DataBoundItem;
                usuario.Familia = new List<Familia>();
                usuario.Familia = familiasBLL.ObtenerFamiliasUsuario(usuario.UsuarioId);

                if (!chkLstFamilia.GetItemChecked(chkLstFamilia.SelectedIndex))
                {
                    ids.Add(familiasBLL.ObtenerIdFamiliaPorDescripcion(chkLstFamilia.SelectedItem.ToString()));
                    familiasBLL.GuardarFamiliasUsuario(ids, usuario.UsuarioId);
                }
                else
                {
                    if (CheckeoPatentes(usuario, false, true, false, familiasBLL.ObtenerIdFamiliaPorDescripcion(chkLstFamilia.SelectedItem.ToString())))
                    {
                        familiasBLL.BorrarFamiliasUsuario(usuario.Familia, usuario.UsuarioId);
                    }
                    else
                    {
                        MessageBox.Show("No puede quitar esta familia");
                    }
                }
            }
        }

        private void ABMusuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void btnUsuariosInactivos_Click(object sender, EventArgs e)
        {
            var resultado = bloqueoUsuario.ShowDialog();
            if (resultado == DialogResult.OK)
            {
            }
        }

        private void ABMusuario_Enter(object sender, EventArgs e)
        {
            CargarRefrescarDatagrid();
            chkLstPatentes.DataSource = patenteBLL.Cargar().Select(pat => pat.Descripcion).ToList();
            chkLstFamilia.DataSource = familiasBLL.Cargar().Select(fam => fam.Descripcion).ToList();
        }
    }
}
