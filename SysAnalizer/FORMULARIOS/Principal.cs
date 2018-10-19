﻿// <auto-generated/>
namespace UI
{
    using DAL;
    using System;
    using System.Windows.Forms;
    using Microsoft.VisualBasic;
    using log4net;

    public partial class Principal : Form, IPrincipal
    {
        private readonly IFormControl formControl;
        private readonly IUsuarioDAL usuarioDAL;
        private readonly IVtaProd venta_De_Productos;
        private readonly IABMUsuario abmUsuario;
        private readonly IBitacora bitacora;

        public Principal(IUsuarioDAL usuarioDAL, IVtaProd venta_De_Productos, IABMUsuario abmUsuario, IBitacora bitacora, IFormControl formControl)
        {
            InitializeComponent();
            this.formControl = formControl;
            this.usuarioDAL = usuarioDAL;
            this.venta_De_Productos = venta_De_Productos;
            this.abmUsuario = abmUsuario;
            this.bitacora = bitacora;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
        }

        private void nuevaVenta_Click(object sender, EventArgs e)
        {
            this.Hide();
            venta_De_Productos.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void usuariosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            formControl.ObtenerFormulario();
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            bitacora.Show();
        }

        private void verProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void ComprobarSiEsPrimerLogin(string usuario)
        {
            var usu = usuarioDAL.ObtenerUsuarioConEmail(usuario);
            if (usu.PrimerLogin)
            {
                var nuevaContraseña = Interaction.InputBox("Ingrese su nuevo password", "Nuevo Password", "");
                var cambioExitoso = usuarioDAL.CambiarPassword(usu, nuevaContraseña, true);
                if (cambioExitoso)
                {
                    //Log.Info("Password Actualizado");
                    MessageBox.Show("Su Password fue actualizado");
                }
                else
                {
                    //Log.Info("Fallo la actualizacion del password");
                    MessageBox.Show("Error Password no actualizado");
                }
            }
        }

        private void backUpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
