﻿// <auto-generated/>
namespace UI
{
    partial class Venta_de_productos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCliente = new System.Windows.Forms.Label();
            this.btnSelCliente = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodProd = new System.Windows.Forms.TextBox();
            this.txtCant = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radioVtaSimple = new System.Windows.Forms.RadioButton();
            this.radioVtaCC = new System.Windows.Forms.RadioButton();
            this.dgVenta = new System.Windows.Forms.DataGridView();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSelProd = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(16, 71);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(69, 17);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "CLIENTE:";
            this.lblCliente.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnSelCliente
            // 
            this.btnSelCliente.Location = new System.Drawing.Point(19, 102);
            this.btnSelCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelCliente.Name = "btnSelCliente";
            this.btnSelCliente.Size = new System.Drawing.Size(121, 60);
            this.btnSelCliente.TabIndex = 1;
            this.btnSelCliente.Text = "Seleccionar Cliente";
            this.btnSelCliente.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "CODIGO PRODUCTO";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtCodProd
            // 
            this.txtCodProd.Location = new System.Drawing.Point(19, 203);
            this.txtCodProd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCodProd.Name = "txtCodProd";
            this.txtCodProd.Size = new System.Drawing.Size(175, 22);
            this.txtCodProd.TabIndex = 3;
            // 
            // txtCant
            // 
            this.txtCant.Location = new System.Drawing.Point(19, 254);
            this.txtCant.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCant.Name = "txtCant";
            this.txtCant.Size = new System.Drawing.Size(95, 22);
            this.txtCant.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "CANTIDAD";
            // 
            // radioVtaSimple
            // 
            this.radioVtaSimple.AutoSize = true;
            this.radioVtaSimple.Location = new System.Drawing.Point(181, 102);
            this.radioVtaSimple.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioVtaSimple.Name = "radioVtaSimple";
            this.radioVtaSimple.Size = new System.Drawing.Size(112, 21);
            this.radioVtaSimple.TabIndex = 6;
            this.radioVtaSimple.TabStop = true;
            this.radioVtaSimple.Text = "Venta Simple";
            this.radioVtaSimple.UseVisualStyleBackColor = true;
            // 
            // radioVtaCC
            // 
            this.radioVtaCC.AutoSize = true;
            this.radioVtaCC.Location = new System.Drawing.Point(181, 142);
            this.radioVtaCC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioVtaCC.Name = "radioVtaCC";
            this.radioVtaCC.Size = new System.Drawing.Size(177, 21);
            this.radioVtaCC.TabIndex = 7;
            this.radioVtaCC.TabStop = true;
            this.radioVtaCC.Text = "Venta Cuenta Corriente";
            this.radioVtaCC.UseVisualStyleBackColor = true;
            // 
            // dgVenta
            // 
            this.dgVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.Cantidad,
            this.PrecioVenta,
            this.importe});
            this.dgVenta.Location = new System.Drawing.Point(379, 15);
            this.dgVenta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgVenta.Name = "dgVenta";
            this.dgVenta.RowTemplate.Height = 24;
            this.dgVenta.Size = new System.Drawing.Size(459, 426);
            this.dgVenta.TabIndex = 8;
            this.dgVenta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // PrecioVenta
            // 
            this.PrecioVenta.HeaderText = "Precio Venta";
            this.PrecioVenta.Name = "PrecioVenta";
            // 
            // importe
            // 
            this.importe.HeaderText = "importe";
            this.importe.Name = "importe";
            // 
            // btnSelProd
            // 
            this.btnSelProd.Location = new System.Drawing.Point(19, 290);
            this.btnSelProd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelProd.Name = "btnSelProd";
            this.btnSelProd.Size = new System.Drawing.Size(121, 60);
            this.btnSelProd.TabIndex = 9;
            this.btnSelProd.Text = "Seleccionar Producto";
            this.btnSelProd.UseVisualStyleBackColor = true;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(16, 423);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(47, 17);
            this.lblFecha.TabIndex = 10;
            this.lblFecha.Text = "fecha:";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(12, 12);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(85, 31);
            this.btnVolver.TabIndex = 11;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Location = new System.Drawing.Point(273, 390);
            this.btnFinalizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(100, 50);
            this.btnFinalizar.TabIndex = 13;
            this.btnFinalizar.Text = "Finalizar Venta";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // Venta_de_productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 471);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.btnSelProd);
            this.Controls.Add(this.dgVenta);
            this.Controls.Add(this.radioVtaCC);
            this.Controls.Add(this.radioVtaSimple);
            this.Controls.Add(this.txtCant);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCodProd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSelCliente);
            this.Controls.Add(this.lblCliente);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Venta_de_productos";
            this.Text = "Venta_de_productos";
            this.Load += new System.EventHandler(this.Venta_de_productos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Button btnSelCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodProd;
        private System.Windows.Forms.TextBox txtCant;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioVtaSimple;
        private System.Windows.Forms.RadioButton radioVtaCC;
        private System.Windows.Forms.DataGridView dgVenta;
        private System.Windows.Forms.Button btnSelProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnFinalizar;
    }
}