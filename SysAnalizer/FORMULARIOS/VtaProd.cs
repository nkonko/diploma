﻿// <auto-generated/>
namespace UI
{
    using BLL;
    using System;
    using System.Windows.Forms;

    public partial class VtaProd : Form, IVtaProd
    {
        private readonly IProductoBLL productoBLL;
        private readonly IProductos productos;
        private readonly IClienteBLL clienteBLL;
        private readonly IClientes cliente;


        public VtaProd(IProductoBLL productoBLL, IProductos productos, IClienteBLL clienteBLL, IClientes cliente)
        {
            this.productoBLL = productoBLL;
            this.productos = productos;
            this.cliente = cliente;
            this.clienteBLL = clienteBLL;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void VtaProd_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.UtcNow.ToString();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSelCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodProd.Text))
            {
                var resultado = cliente.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    var cli = cliente.ObtenerClienteSeleccionado();
                    MessageBox.Show("");
                }
            }
            else
            {
                var r = clienteBLL.ObtenerCliente(txtCodProd.Text);
            }
        }

        private void btnSelProd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodProd.Text))
            {
                var resultado = productos.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    var prod = productos.GetProductoSeleccionado();
                    MessageBox.Show(prod.Descripcion);
                }
            }
            else
            {
                var r = productoBLL.ObtenerProductoPorCodigo(txtCodProd.Text);
            }
        }

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }
    }
}
