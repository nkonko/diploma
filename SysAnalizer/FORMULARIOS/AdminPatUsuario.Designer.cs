﻿// <auto-generated/>
namespace UI
{
    partial class AdminPatUsuario
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
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PatUsuario = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PatSistema = new System.Windows.Forms.ListBox();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(12, 16);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(69, 23);
            this.btnVolver.TabIndex = 62;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(87, 21);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.TabIndex = 61;
            this.lblUsuario.Text = "Usuario:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PatUsuario);
            this.groupBox1.Location = new System.Drawing.Point(12, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 200);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Patentes Usuario";
            // 
            // PatUsuario
            // 
            this.PatUsuario.FormattingEnabled = true;
            this.PatUsuario.Location = new System.Drawing.Point(7, 20);
            this.PatUsuario.Name = "PatUsuario";
            this.PatUsuario.Size = new System.Drawing.Size(163, 173);
            this.PatUsuario.TabIndex = 0;
            this.PatUsuario.Click += new System.EventHandler(this.PatUsuario_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PatSistema);
            this.groupBox2.Location = new System.Drawing.Point(228, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(176, 200);
            this.groupBox2.TabIndex = 61;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Patentes Sistema";
            // 
            // PatSistema
            // 
            this.PatSistema.FormattingEnabled = true;
            this.PatSistema.Location = new System.Drawing.Point(6, 19);
            this.PatSistema.Name = "PatSistema";
            this.PatSistema.Size = new System.Drawing.Size(163, 173);
            this.PatSistema.TabIndex = 1;
            this.PatSistema.Click += new System.EventHandler(this.PatSistema_Click);
            // 
            // btnAsignar
            // 
            this.btnAsignar.Location = new System.Drawing.Point(335, 255);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(69, 23);
            this.btnAsignar.TabIndex = 63;
            this.btnAsignar.Text = "<-- Asignar ";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(12, 255);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(69, 23);
            this.btnQuitar.TabIndex = 64;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // AdminPatUsuario
            // 
            this.ClientSize = new System.Drawing.Size(419, 295);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.groupBox1);
            this.Name = "AdminPatUsuario";
            this.Text = "Patentes Usuario";
            this.Load += new System.EventHandler(this.AdminPatUsuario_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.ListBox PatUsuario;
        private System.Windows.Forms.ListBox PatSistema;
    }
}