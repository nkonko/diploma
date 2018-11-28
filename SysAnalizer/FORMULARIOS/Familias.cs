﻿// <auto-generated/>
namespace UI
{
    using BE.Entidades;
    using BLL;
    using Microsoft.VisualBasic;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    public partial class Familias : Form, IFamilias
    {
        public Familia familiaSeleccionada = null;
        private readonly IFamiliaBLL familiaBLL;
        private readonly IAdminPatFamilia adminPatFamilia;
        private readonly IPatenteBLL patenteBLL;

        public Familias(IFamiliaBLL familiaBLL, IUsuarioBLL usuarioBLL, IAdminPatFamilia adminPatFamilia, IPatenteBLL patenteBLL)
        {
            InitializeComponent();
            this.familiaBLL = familiaBLL;
            this.adminPatFamilia = adminPatFamilia;
            this.patenteBLL = patenteBLL;
        }

        private void Familias_Load(object sender, EventArgs e)
        {
            CargarFamilias();

        }

        private void CargarFamilias()
        {
            var descripciones = new List<string>();

            foreach (var familia in familiaBLL.Cargar())
            {
                descripciones.Add(familia.Descripcion);
            }

            chklstFamilias.DataSource = descripciones;
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            var nombreFamilia = "";

            var items = InputBox.fillItems("NombreFamilia", nombreFamilia);

            InputBox input = InputBox.Show("Ingrese el nombre para la nueva familia", items, InputBoxButtons.OKCancel);

            if (input.Result == InputBoxResult.OK)
            {
                nombreFamilia = input.Items["NombreFamilia"];
            }

            var familias = familiaBLL.Cargar();

            if (!familias.Select(x => x.Descripcion).Contains(nombreFamilia))
            {
                var creada = familiaBLL.Crear(new Familia() { Descripcion = nombreFamilia });
                var creadaId = familiaBLL.ObtenerIdFamiliaPorDescripcion(nombreFamilia);

                familiaSeleccionada = new Familia() { FamiliaId = creadaId, Descripcion = nombreFamilia };

                if (creada)
                {
                    adminPatFamilia.FamiliaNueva = true;

                    var resultado = adminPatFamilia.ShowDialog();

                    if (resultado == DialogResult.OK)
                    {
                        MessageBox.Show("Familia y Patentes registradas");
                    }
                }

                CargarFamilias();
                chklstFamilias.Refresh();
            }
            else
            {
                MessageBox.Show("La familia ya existe");
            }
        }

        public Familia ObtenerFamiliaSeleccionada()
        {
            return familiaSeleccionada;
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            var desc = chklstFamilias.SelectedItem.ToString();
            var returnValue = false;
            var usuarios = familiaBLL.ObtenerUsuariosPorFamilia(familiaBLL.ObtenerIdFamiliaPorDescripcion(desc));

            foreach (var usuario in usuarios)
            {
                if (patenteBLL.CheckeoDePatentesParaBorrar(usuario, true))
                {
                    returnValue = true;
                }
                else
                {
                    MessageBox.Show("La familia actualmente esta en uso");
                }
            }

            if (returnValue)
            {
                var exitoso = familiaBLL.Borrar(new Familia() { Descripcion = desc, FamiliaId = familiaBLL.ObtenerIdFamiliaPorDescripcion(desc) });
            }

            CargarFamilias();
            chklstFamilias.Refresh();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            var desc = chklstFamilias.SelectedItem.ToString();
            var nuevoNombre = "";

            var items = InputBox.fillItems("Familia", nuevoNombre);
            InputBox input = InputBox.Show("Ingrese un nuevo nombre", items, InputBoxButtons.OKCancel);

            if (input.Result == InputBoxResult.OK)
            {
                nuevoNombre = input.Items["Familia"];
            }

            var familias = familiaBLL.Cargar();

            if (!familias.Select(x => x.Descripcion).Contains(nuevoNombre))
            {
                var exitoso = familiaBLL.Actualizar(new Familia() { Descripcion = nuevoNombre, FamiliaId = familiaBLL.ObtenerIdFamiliaPorDescripcion(desc) });
                var creadaId = familiaBLL.ObtenerIdFamiliaPorDescripcion(nuevoNombre);

                familiaSeleccionada = new Familia() { FamiliaId = creadaId, Descripcion = nuevoNombre };

                if (exitoso)
                {
                    adminPatFamilia.ShowDialog();
                    MessageBox.Show("Familia y Patentes Actualizadas");
                }

                CargarFamilias();
                chklstFamilias.Refresh();
            }
            else
            {
                MessageBox.Show("La familia ya existe");
            }
            CargarFamilias();
            chklstFamilias.Refresh();
        }

        private void Familias_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void Familias_Enter(object sender, EventArgs e)
        {

        }
    }
}