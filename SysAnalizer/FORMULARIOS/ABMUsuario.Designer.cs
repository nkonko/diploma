﻿// <auto-generated/>
namespace UI
{
    partial class ABMusuario
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
            this.dgusuario = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Domicilio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkLstPatentes = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chkLstFamilia = new System.Windows.Forms.CheckedListBox();
            this.btnNegarPat = new System.Windows.Forms.Button();
            this.btnUsuariosInactivos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgusuario)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(11, 11);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(74, 27);
            this.btnVolver.TabIndex = 27;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // dgusuario
            // 
            this.dgusuario.AllowUserToAddRows = false;
            this.dgusuario.AllowUserToDeleteRows = false;
            this.dgusuario.AllowUserToResizeRows = false;
            this.dgusuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgusuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Apellido,
            this.Email,
            this.Telefono,
            this.Domicilio});
            this.dgusuario.Location = new System.Drawing.Point(11, 213);
            this.dgusuario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgusuario.Name = "dgusuario";
            this.dgusuario.ReadOnly = true;
            this.dgusuario.RowTemplate.Height = 24;
            this.dgusuario.Size = new System.Drawing.Size(437, 182);
            this.dgusuario.TabIndex = 26;
            this.dgusuario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgusuario_CellClick);
            this.dgusuario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgusuario.SelectionChanged += new System.EventHandler(this.dgusuario_SelectionChanged);
            this.dgusuario.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgusuario_DataError);
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Apellido
            // 
            this.Apellido.DataPropertyName = "Apellido";
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // Telefono
            // 
            this.Telefono.DataPropertyName = "Telefono";
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            // 
            // Domicilio
            // 
            this.Domicilio.DataPropertyName = "Domicilio";
            this.Domicilio.HeaderText = "Domicilio";
            this.Domicilio.Name = "Domicilio";
            this.Domicilio.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(248, 66);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Domicilio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Apellido:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Nombre:";
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(11, 162);
            this.btnBorrar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(74, 27);
            this.btnBorrar.TabIndex = 10;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(11, 112);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(74, 27);
            this.btnModificar.TabIndex = 9;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btn_modificar_Click);
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Location = new System.Drawing.Point(250, 82);
            this.txtDomicilio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(200, 20);
            this.txtDomicilio.TabIndex = 4;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(104, 82);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(125, 20);
            this.txtApellido.TabIndex = 3;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(104, 41);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(125, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(11, 59);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(74, 27);
            this.btnNuevo.TabIndex = 8;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(250, 41);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 20);
            this.txtEmail.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(248, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "E-mail:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(104, 128);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(125, 20);
            this.txtTel.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(101, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Teléfono:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chkLstPatentes
            // 
            this.chkLstPatentes.FormattingEnabled = true;
            this.chkLstPatentes.Location = new System.Drawing.Point(464, 41);
            this.chkLstPatentes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkLstPatentes.Name = "chkLstPatentes";
            this.chkLstPatentes.Size = new System.Drawing.Size(114, 124);
            this.chkLstPatentes.TabIndex = 37;
            this.chkLstPatentes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstPatentes_ItemCheck);
            this.chkLstPatentes.SelectedIndexChanged += new System.EventHandler(this.chkLstPatentes_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(461, 208);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "Familia:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(461, 24);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Patentes:";
            // 
            // chkLstFamilia
            // 
            this.chkLstFamilia.FormattingEnabled = true;
            this.chkLstFamilia.Location = new System.Drawing.Point(464, 225);
            this.chkLstFamilia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkLstFamilia.Name = "chkLstFamilia";
            this.chkLstFamilia.Size = new System.Drawing.Size(114, 124);
            this.chkLstFamilia.TabIndex = 40;
            this.chkLstFamilia.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstFamilia_ItemCheck);
            // 
            // btnNegarPat
            // 
            this.btnNegarPat.Enabled = false;
            this.btnNegarPat.Location = new System.Drawing.Point(593, 41);
            this.btnNegarPat.Name = "btnNegarPat";
            this.btnNegarPat.Size = new System.Drawing.Size(75, 38);
            this.btnNegarPat.TabIndex = 41;
            this.btnNegarPat.Text = "Negar Patente";
            this.btnNegarPat.UseVisualStyleBackColor = true;
            this.btnNegarPat.Click += new System.EventHandler(this.btnNegarPat_Click);
            // 
            // btnUsuariosInactivos
            // 
            this.btnUsuariosInactivos.Location = new System.Drawing.Point(593, 341);
            this.btnUsuariosInactivos.Name = "btnUsuariosInactivos";
            this.btnUsuariosInactivos.Size = new System.Drawing.Size(75, 53);
            this.btnUsuariosInactivos.TabIndex = 42;
            this.btnUsuariosInactivos.Text = "Usuarios Inactivos";
            this.btnUsuariosInactivos.UseVisualStyleBackColor = true;
            this.btnUsuariosInactivos.Click += new System.EventHandler(this.btnUsuariosInactivos_Click);
            // 
            // ABMusuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 406);
            this.Controls.Add(this.btnUsuariosInactivos);
            this.Controls.Add(this.btnNegarPat);
            this.Controls.Add(this.chkLstFamilia);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkLstPatentes);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dgusuario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.txtDomicilio);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnNuevo);
            this.Name = "ABMusuario";
            this.Text = "ABM usuarios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ABMusuario_FormClosing);
            this.Load += new System.EventHandler(this.usuarios_Load);
            this.Enter += new System.EventHandler(this.ABMusuario_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.dgusuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridView dgusuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox chkLstPatentes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckedListBox chkLstFamilia;
        private System.Windows.Forms.Button btnNegarPat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Domicilio;
        private System.Windows.Forms.Button btnUsuariosInactivos;
    }
}