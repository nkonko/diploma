﻿//<auto-generated/>

namespace UI
{
    partial class BloqueoProductos
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
            this.lblActivos = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstActivos = new System.Windows.Forms.ListBox();
            this.lstInactivos = new System.Windows.Forms.ListBox();
            this.btnActivar = new System.Windows.Forms.Button();
            this.btnDesactivar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblActivos
            // 
            this.lblActivos.AutoSize = true;
            this.lblActivos.Location = new System.Drawing.Point(25, 20);
            this.lblActivos.Name = "lblActivos";
            this.lblActivos.Size = new System.Drawing.Size(125, 17);
            this.lblActivos.TabIndex = 1;
            this.lblActivos.Text = "Productos Activos:";
            this.lblActivos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(338, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Productos Inactivos:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lstActivos
            // 
            this.lstActivos.FormattingEnabled = true;
            this.lstActivos.ItemHeight = 16;
            this.lstActivos.Location = new System.Drawing.Point(28, 51);
            this.lstActivos.Name = "lstActivos";
            this.lstActivos.Size = new System.Drawing.Size(167, 228);
            this.lstActivos.TabIndex = 3;
            // 
            // lstInactivos
            // 
            this.lstInactivos.FormattingEnabled = true;
            this.lstInactivos.ItemHeight = 16;
            this.lstInactivos.Location = new System.Drawing.Point(341, 51);
            this.lstInactivos.Name = "lstInactivos";
            this.lstInactivos.Size = new System.Drawing.Size(166, 228);
            this.lstInactivos.TabIndex = 4;
            // 
            // btnActivar
            // 
            this.btnActivar.Location = new System.Drawing.Point(222, 127);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(91, 34);
            this.btnActivar.TabIndex = 5;
            this.btnActivar.Text = "Activar";
            this.btnActivar.UseVisualStyleBackColor = true;
            this.btnActivar.Click += new System.EventHandler(this.btnActivar_Click_1);
            // 
            // btnDesactivar
            // 
            this.btnDesactivar.Location = new System.Drawing.Point(222, 177);
            this.btnDesactivar.Name = "btnDesactivar";
            this.btnDesactivar.Size = new System.Drawing.Size(91, 34);
            this.btnDesactivar.TabIndex = 6;
            this.btnDesactivar.Text = "Desactivar";
            this.btnDesactivar.UseVisualStyleBackColor = true;
            this.btnDesactivar.Click += new System.EventHandler(this.btnDesactivar_Click);
            // 
            // BloqueoProductos
            // 
            this.ClientSize = new System.Drawing.Size(534, 304);
            this.Controls.Add(this.btnDesactivar);
            this.Controls.Add(this.btnActivar);
            this.Controls.Add(this.lstInactivos);
            this.Controls.Add(this.lstActivos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblActivos);
            this.Name = "BloqueoProductos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BloqueoProductos_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblActivos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstActivos;
        private System.Windows.Forms.ListBox lstInactivos;
        private System.Windows.Forms.Button btnActivar;
        private System.Windows.Forms.Button btnDesactivar;
    }
}