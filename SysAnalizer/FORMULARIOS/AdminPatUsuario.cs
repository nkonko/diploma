﻿// <auto-generated/>
namespace UI
{
    using BE.Entidades;
    using BLL;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    public partial class AdminPatUsuario : Form, IAdminPat
    {
        private const string lblUsu = "Usuario: ";
        private readonly IPatenteBLL patenteBLL;
        private IABMUsuario aBMUsuario;

        public Usuario UsuarioSeleccionado { get; set; } = new Usuario();

        public Patente PatenteUsuarioSeleccionada { get; set; } = new Patente();

        public Patente PatenteSistemaSeleccionada { get; set; } = new Patente();

        public AdminPatUsuario(IPatenteBLL patenteBLL)
        {
            InitializeComponent();
            this.patenteBLL = patenteBLL;
        }

        private void AdminPatUsuario_Load(object sender, EventArgs e)
        {
            aBMUsuario = IoCContainer.Resolve<IABMUsuario>();

            UsuarioSeleccionado = aBMUsuario.ObtenerUsuarioSeleccionado();

            CargarListas();

            ActualizarSeleccionado();

            CargarLbl();
        }

        private void CargarLbl()
        {
            lblUsuario.Text = string.Empty;
            lblUsuario.Text = lblUsu + UsuarioSeleccionado.Email;
        }

        private void CargarListas()
        {
            LimpiarListas();

            PatSistema.DataSource = patenteBLL.Cargar().Select(pat => pat.Descripcion).ToList();
            PatUsuario.DataSource = UsuarioSeleccionado.Patentes.Select(pat => pat.Descripcion).ToList();
        }

        private void LimpiarListas()
        {
            PatSistema.ClearSelected();
            PatUsuario.ClearSelected();
            PatUsuario.SelectedItem = null;
            PatSistema.DataSource = null;
            PatUsuario.DataSource = null;
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            ActualizarSeleccionado();

            if (!UsuarioSeleccionado.Patentes.Any(patUsu => patUsu.IdPatente == PatenteSistemaSeleccionada.IdPatente))
            {
                UsuarioSeleccionado.Patentes.Add(PatenteSistemaSeleccionada);
            }

            patenteBLL.GuardarPatentesUsuario(new List<int>() { PatenteSistemaSeleccionada.IdPatente }, UsuarioSeleccionado.UsuarioId);

            CargarListas();
        }

        private void ActualizarSeleccionado()
        {
            var descPatenteSistema = PatSistema.GetItemText(PatSistema.SelectedItem);
            var descPatenteUsuario = PatUsuario.GetItemText(PatUsuario.SelectedItem);

            PatenteSistemaSeleccionada = patenteBLL.ObtenerPatentePorDescripcion(descPatenteSistema, UsuarioSeleccionado.UsuarioId);
            PatenteUsuarioSeleccionada = patenteBLL.ObtenerPatentePorDescripcion(descPatenteUsuario, UsuarioSeleccionado.UsuarioId);
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            ActualizarSeleccionado();

            var permitir = patenteBLL.CheckeoPatenteParaBorrar(PatenteUsuarioSeleccionada, UsuarioSeleccionado, aBMUsuario.ObtenerUsuariosBd());

            if (permitir)
            {
                if (UsuarioSeleccionado.Patentes.Any(patUsu => patUsu.IdPatente == PatenteUsuarioSeleccionada.IdPatente))
                {
                    UsuarioSeleccionado.Patentes.RemoveAll(PatUsu => PatUsu.IdPatente == PatenteUsuarioSeleccionada.IdPatente);
                }

                patenteBLL.BorrarPatentesUsuario(new List<int>() { PatenteUsuarioSeleccionada.IdPatente }, UsuarioSeleccionado.UsuarioId);

                PatUsuario.ClearSelected();
            }
            else
            {
                Alert.ShowSimpleAlert("Al menos un usuario debe tener asignada esta patente", "MSJ015");
            }

            CargarListas();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            LimpiarListas();

            this.Hide();
        }

        private void PatUsuario_Click(object sender, EventArgs e)
        {
            ActualizarSeleccionado();
        }

        private void PatSistema_Click(object sender, EventArgs e)
        {
            ActualizarSeleccionado();
        }
    }
}
