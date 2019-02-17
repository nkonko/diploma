﻿// <auto-generated/>
namespace UI
{
    using BE.Entidades;
    using BLL;
    using DAL;
    using DAL.Dao;
    using EasyEncryption;
    using log4net;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public partial class ABMusuario : Form, IABMUsuario
    {
        private readonly IDigitoVerificador digitoVerificador;
        private readonly IFamiliaBLL familiasBLL;
        private readonly IPatenteBLL patenteBLL;
        private readonly IBitacoraBLL bitacoraBLL;
        private readonly IFormControl formControl;
        private readonly IBloqueoUsuario bloqueoUsuario;
        private readonly IAdminPat adminPat;
        private readonly IAdminFam adminFam;
        private readonly INegarPat negarPat;
        private readonly IIdiomaBLL idiomaBLL;

        private const int formId = 3;
        private const string entidad = "Usuario";
        public const string key = "bZr2URKx";
        public const string iv = "HNtgQw0w";

        public Usuario UsuarioActivo { get; set; }

        public List<Usuario> usuariosBD { get; set; } = new List<Usuario>() { new Usuario() };

        public Usuario UsuarioSeleccionado { get; set; } = new Usuario();

        public Patente PatenteSeleccionada { get; set; } = new Patente();

        public Familia FamiliaSeleccionada { get; set; } = new Familia();

        ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IUsuarioBLL usuarioBLL;

        public ABMusuario(IBitacoraBLL bitacoraBLL, IFormControl formControl, IFamiliaBLL familiasBLL, IPatenteBLL patenteBLL, IDigitoVerificador digitoVerificador, IBloqueoUsuario bloqueoUsuario, IIdiomaBLL idiomaBLL, IAdminPat adminPat, IAdminFam adminFam, INegarPat negarPat)
        {
            this.bitacoraBLL = bitacoraBLL;
            this.formControl = formControl;
            this.familiasBLL = familiasBLL;
            this.patenteBLL = patenteBLL;
            this.digitoVerificador = digitoVerificador;
            this.bloqueoUsuario = bloqueoUsuario;
            this.idiomaBLL = idiomaBLL;
            this.negarPat = negarPat;
            this.adminFam = adminFam;
            this.adminPat = adminPat;
            InitializeComponent();
            dgusuario.AutoGenerateColumns = false;
        }

        #region nuevo

        private void usuarios_Load(object sender, EventArgs e)
        {
            usuarioBLL = IoCContainer.Resolve<IUsuarioBLL>();

            HacerLoad();

            Traduccir();
        }

        private void HacerLoad()
        {
            UsuarioActivo = formControl.ObtenerInfoUsuario();

            ControlPatentes();

            CargarRefrescarDatagrid();

            SetearObjetosSeleccionados();

            CargarPatentesFamiliaUsuarioSeleccionado();

            CargaControles();
        }

        private void ControlPatentes()
        {
            var patForm = formControl.ObtenerPermisosFormulario(formId);
            var usuarioActivo = formControl.ObtenerPermisosUsuario();
            var patentesSistema = patenteBLL.Cargar();

            if (!patForm.Exists(item => usuarioActivo.Patentes.Select(item2 => item2.IdPatente).Contains(item.IdPatente = patentesSistema.Where(p => (p.Descripcion == "Alta Usuario")).Select(p => p.IdPatente).FirstOrDefault())))
            {
                btnNuevo.Enabled = false;

            }
            else
            {
                btnNuevo.Enabled = true;

                if (usuarioActivo.Patentes.FirstOrDefault(p => p.Descripcion == "Alta Usuario").Negada)
                {
                    btnNuevo.Enabled = false;
                }
            }

            if (!patForm.Exists(item => usuarioActivo.Patentes.Select(item2 => item2.IdPatente).Contains(item.IdPatente = patentesSistema.Where(p => (p.Descripcion == "Baja Usuario")).Select(p => p.IdPatente).FirstOrDefault())))
            {
                btnBorrar.Enabled = false;
            }
            else
            {
                btnBorrar.Enabled = true;

                if (usuarioActivo.Patentes.FirstOrDefault(p => p.Descripcion == "Baja Usuario").Negada)
                {
                    btnNuevo.Enabled = false;
                }
            }

            if (!patForm.Exists(item => usuarioActivo.Patentes.Select(item2 => item2.IdPatente).Contains(item.IdPatente = patentesSistema.Where(p => (p.Descripcion == "Mod Usuario")).Select(p => p.IdPatente).FirstOrDefault())))
            {
                btnModificar.Enabled = false;
            }
            else
            {
                btnModificar.Enabled = true;

                if (usuarioActivo.Patentes.FirstOrDefault(p => p.Descripcion == "Mod Usuario").Negada)
                {
                    btnNuevo.Enabled = false;
                }
            }
        }

        private void CargarRefrescarDatagrid()
        {
            dgusuario.DataSource = null;

            usuariosBD = usuarioBLL.TraerUsuariosConPatentesYFamilias();

            foreach (var usuario in usuariosBD)
            {
                usuario.Email = DES.Decrypt(usuario.Email, key, iv);
            }

            dgusuario.DataSource = usuariosBD;
        }

        private void SetearObjetosSeleccionados()
        {
            UsuarioSeleccionado = (Usuario)dgusuario.CurrentRow.DataBoundItem;
        }

        private void Traduccir()
        {
            formControl.Traducciones.Clear();
            formControl.Traducciones = GetTraducciones();
            idiomaBLL.LlenarRecursos(formControl.Traducciones, formControl.LenguajeSeleccionado.IdIdioma, Application.OpenForms[0].Name);
            idiomaBLL.LeerRecursos(this.Controls);
        }

        private IDictionary<string, string> GetTraducciones()
        {
            formControl.Traducciones = idiomaBLL.ObtenerTraduccionesFormulario(formControl.LenguajeSeleccionado.IdIdioma, Application.OpenForms[2].Name).ToDictionary(k => k.ControlName ?? k.MensajeCodigo, v => v.Traduccion);

            return formControl.Traducciones;
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

        private void dgusuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                MessageBox.Show("Revisar");
                return;
            }

            if (e.RowIndex >= 0)
            {
                UsuarioSeleccionado = (Usuario)dgusuario.CurrentRow.DataBoundItem;

                CargarPatentesFamiliaUsuarioSeleccionado();

                CargaControles();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ABMusuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        #endregion

        private void MantenerUsuarioSeleccionado()
        {
            var indice = dgusuario.SelectedRows[0].Index;
            dgusuario.DataSource = null;

            usuariosBD = usuarioBLL.TraerUsuariosConPatentesYFamilias();

            foreach (var usuario in usuariosBD)
            {
                usuario.Email = DES.Decrypt(usuario.Email, key, iv);
            }

            dgusuario.DataSource = usuariosBD;
            dgusuario.Rows[0].Selected = false;
            dgusuario.Rows[indice].Selected = true;
        }

        private void CargarPatentesFamiliaUsuarioSeleccionado()
        {
            FormExtensions.CatchException(this, () =>
            {
                UsuarioSeleccionado.Patentes = new List<Patente>();
                UsuarioSeleccionado.Familia = new List<Familia>();
                UsuarioSeleccionado.Patentes.AddRange(usuarioBLL.ObtenerPatentesDeUsuario(UsuarioSeleccionado.UsuarioId));
                UsuarioSeleccionado.Familia = familiasBLL.ObtenerFamiliasUsuario(UsuarioSeleccionado.UsuarioId);
                foreach (var familia in UsuarioSeleccionado.Familia)
                {
                    familia.Patentes = familiasBLL.ObtenerPatentesFamilia(familia.FamiliaId);
                }
            });
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
                        Alert.ShowSimpleAlert("Registro exitoso", "MSJ017");
                        CargarRefrescarDatagrid();
                    }
                    else
                    {
                        Log4netExtensions.Baja(log, "El registro de nuevo usuario ha fallado");
                        bitacoraBLL.RegistrarEnBitacora(usu);
                        Alert.ShowSimpleAlert("El registro de nuevo usuario ha fallado", "MSJ019");
                    }
                }
            }
            else
            {
                Alert.ShowSimpleAlert("No pueden haber 2 usuarios con el mismo email", "MSJ021");
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
                    Alert.ShowSimpleAlert("Modificacion exitosa", "MSJ023");
                    CargarRefrescarDatagrid();
                }
                else
                {
                    Log4netExtensions.Baja(log, "La modificacion ha fallado");
                    bitacoraBLL.RegistrarEnBitacora(UsuarioActivo);
                    Alert.ShowSimpleAlert("La modificacion ha fallado", "MSJ025");
                    CargarRefrescarDatagrid();
                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            var permitir = verificarDatos();

            if (permitir)
            {
                if (CheckeoPatentes(UsuarioSeleccionado))
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
                        Alert.ShowSimpleAlert("Borrado exitoso", "MSJ027");
                        CargarRefrescarDatagrid();
                    }
                    else
                    {
                        Log4netExtensions.Baja(log, "El borrado de usuario ha fallado");
                        bitacoraBLL.RegistrarEnBitacora(UsuarioActivo);
                        Alert.ShowSimpleAlert("El borrado de usuario ha fallado", "MSJ029");
                        CargarRefrescarDatagrid();
                    }
                }
                else
                {
                    Log4netExtensions.Media(log, "Una patente se encuentra en uso y no puede borrarse");
                    bitacoraBLL.RegistrarEnBitacora(UsuarioActivo);
                    Alert.ShowSimpleAlert("Una patente se encuentra en uso y no puede borrarse", "MSJ013");
                    CargarRefrescarDatagrid();
                }
            }
        }

        private void btnUsuariosInactivos_Click(object sender, EventArgs e)
        {
            bloqueoUsuario.ShowDialog();
        }

        private bool verificarDatos()
        {
            var returnValue = true;

            if (txtEmail.Text == DES.Decrypt(UsuarioActivo.Email, key, iv))
            {
                Alert.ShowSimpleAlert("No puede realizar acciones sobre el usuario activo", "MSJ031");
                Log4netExtensions.Alta(log, "Se intento eliminar o modificar al usuario activo");
                returnValue = false;
            }

            foreach (TextBox tb in Controls.OfType<TextBox>())
            {
                if (string.IsNullOrEmpty(tb.Text.Trim()))
                {
                    Alert.ShowSimpleAlert("Todos los datos deben estar completos", "MSJ033");
                    Log4netExtensions.Baja(log, "Todos los datos deben estar completos");
                    returnValue = false;
                    break;
                }

                if (tb.Name == "txtNombre")
                {
                    if (!Regex.IsMatch(tb.Text, @"[a-zA-Z]"))
                    {
                        MessageBox.Show("El campo nombre no acepta numeros");
                        returnValue = false;
                    }
                }

                if (tb.Name == "txtApellido")
                {
                    if (!Regex.IsMatch(tb.Text, @"[a-zA-Z]"))
                    {
                        MessageBox.Show("El campo apellido no acepta numeros");
                        returnValue = false;
                    }
                }

                if (tb.Name == "txtTel")
                {
                    if (Regex.IsMatch(tb.Text, @"[a-zA-Z]"))
                    {
                        MessageBox.Show("no puede ingresar letras");
                        returnValue = false;
                    }
                }
            }

            return returnValue;
        }

        public bool CheckeoPatentes(Usuario usuario)
        {
            var returnValue = true;

            if (usuariosBD.Count == 1)
            {
                return false;
            }

            if (usuario.Patentes.Count > 0 || usuario.Familia.Count > 0)
            {
                returnValue = patenteBLL.CheckeoUsuarioParaBorrar(usuario, usuariosBD);
            }

            return returnValue;

        }

        private void SetearBotonNegada(List<Patente> patentes)
        {
            if (UsuarioSeleccionado.Patentes?.Count > 0)
            {
                if (UsuarioSeleccionado.Patentes[0].Negada)
                {
                    btnNegarPat.Text = "Habilitar Patente";
                }
                else
                {
                    btnNegarPat.Text = "Negar Patente";
                }
            }
        }

        #region Eventos grids
        //private void dgusuario_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (UsuarioSeleccionado != null)
        //    {
        //        return;
        //    }

        //    try
        //    {
        //        UsuarioSeleccionado = (Usuario)dgusuario.CurrentRow.DataBoundItem;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void dgusuario_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            CargarRefrescarDatagrid();
            this.dgusuario.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }
        #endregion

        private void btnAsignarPat_Click(object sender, EventArgs e)
        {
            adminPat.ShowDialog();
            HacerLoad();
        }

        private void btnNegarPat_Click(object sender, EventArgs e)
        {
            negarPat.ShowDialog();
            HacerLoad();
        }

        private void btnAsignarFam_Click(object sender, EventArgs e)
        {
            adminFam.ShowDialog();
            HacerLoad();
        }

        public Usuario ObtenerUsuarioSeleccionado()
        {
            return UsuarioSeleccionado;
        }

        public List<Usuario> ObtenerUsuariosBd()
        {
            return usuariosBD;
        }
    }
}