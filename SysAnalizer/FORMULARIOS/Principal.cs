﻿// <auto-generated/>
namespace UI
{
    using BLL;
    using DAL.Dao;
    using Microsoft.VisualBasic;
    using System;
    using System.Windows.Forms;

    public partial class Principal : Form, IPrincipal
    {
        private readonly IFormControl formControl;
        private readonly IUsuarioDAL usuarioDAL;
        private readonly IVtaProd venta_De_Productos;
        private readonly IABMUsuario abmUsuario;
        private readonly IBitacora bitacora;
        private readonly IFamilias familias;
        private readonly IFamiliaBLL familiaBLL;

        public Principal(IUsuarioDAL usuarioDAL, IVtaProd venta_De_Productos, IABMUsuario abmUsuario, IBitacora bitacora, IFormControl formControl, IFamilias familias, IFamiliaBLL familiaBLL)
        {
            InitializeComponent();
            this.formControl = formControl;
            this.usuarioDAL = usuarioDAL;
            this.venta_De_Productos = venta_De_Productos;
            this.abmUsuario = abmUsuario;
            this.bitacora = bitacora;
            this.familias = familias;
            this.familiaBLL = familiaBLL;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            ////Traer id de familia que machee con idusuario de familiaUsuario
            var idFamilia = familiaBLL.Cargar().Find(

            var acceso = formControl.AccesosUsuario();

            if(acceso[abmUsuario.GetType().FullName])
            {
                usuariosToolStripMenuItem.Enabled = false;
            }
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
            abmUsuario.Show();
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

        private void familiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            familias.Show();
        }

        private void verUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
