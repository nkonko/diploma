﻿// <auto-generated/>
namespace UI
{
    partial class BloqueoUsuario
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
            this.lstActivos = new System.Windows.Forms.ListBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnActivar = new System.Windows.Forms.Button();
            this.btnDesactivar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lstInactivos = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstActivos
            // 
            this.lstActivos.FormattingEnabled = true;
            this.lstActivos.ItemHeight = 16;
            this.lstActivos.Location = new System.Drawing.Point(12, 100);
            this.lstActivos.Name = "lstActivos";
            this.lstActivos.Size = new System.Drawing.Size(218, 292);
            this.lstActivos.TabIndex = 0;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(12, 12);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(83, 30);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnActivar
            // 
            this.btnActivar.Location = new System.Drawing.Point(256, 172);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(83, 30);
            this.btnActivar.TabIndex = 2;
            this.btnActivar.Text = "Activar";
            this.btnActivar.UseVisualStyleBackColor = true;
            this.btnActivar.Click += new System.EventHandler(this.btnActivar_Click);
            // 
            // btnDesactivar
            // 
            this.btnDesactivar.Location = new System.Drawing.Point(256, 243);
            this.btnDesactivar.Name = "btnDesactivar";
            this.btnDesactivar.Size = new System.Drawing.Size(83, 30);
            this.btnDesactivar.TabIndex = 3;
            this.btnDesactivar.Text = "Desactivar";
            this.btnDesactivar.UseVisualStyleBackColor = true;
            this.btnDesactivar.Click += new System.EventHandler(this.btnDesactivar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Usuarios Activos";
            // 
            // lstInactivos
            // 
            this.lstInactivos.FormattingEnabled = true;
            this.lstInactivos.ItemHeight = 16;
            this.lstInactivos.Location = new System.Drawing.Point(369, 100);
            this.lstInactivos.Name = "lstInactivos";
            this.lstInactivos.Size = new System.Drawing.Size(218, 292);
            this.lstInactivos.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(366, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Usuarios Inactivos";
            // 
            // BloqueoUsuario
            // 
            this.ClientSize = new System.Drawing.Size(597, 404);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstInactivos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDesactivar);
            this.Controls.Add(this.btnActivar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lstActivos);
            this.Name = "BloqueoUsuario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BloqueUsuario_FormClosing);
            this.Load += new System.EventHandler(this.BloqueUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstActivos;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnActivar;
        private System.Windows.Forms.Button btnDesactivar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstInactivos;
        private System.Windows.Forms.Label label2;
    }
}