﻿// <auto-generated/>
namespace UI
{
    partial class BitacoraUI
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ModeloBitacoraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btn_filtrar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkListCriticidad = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkListUsuarios = new System.Windows.Forms.CheckedListBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_volver = new System.Windows.Forms.Button();
            this.rpv1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.chkTodos = new System.Windows.Forms.CheckBox();
            this.chkTodas = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ModeloBitacoraBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ModeloBitacoraBindingSource
            // 
            this.ModeloBitacoraBindingSource.DataSource = typeof(UI.Modelo.ModeloBitacora);
            // 
            // btn_filtrar
            // 
            this.btn_filtrar.Location = new System.Drawing.Point(148, 389);
            this.btn_filtrar.Name = "btn_filtrar";
            this.btn_filtrar.Size = new System.Drawing.Size(100, 23);
            this.btn_filtrar.TabIndex = 69;
            this.btn_filtrar.Text = "Filtrar";
            this.btn_filtrar.UseVisualStyleBackColor = true;
            this.btn_filtrar.Click += new System.EventHandler(this.btn_filtrar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkListCriticidad);
            this.groupBox2.Location = new System.Drawing.Point(23, 243);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 128);
            this.groupBox2.TabIndex = 66;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "criticidad";
            // 
            // checkListCriticidad
            // 
            this.checkListCriticidad.FormattingEnabled = true;
            this.checkListCriticidad.Items.AddRange(new object[] {
            "Baja",
            "Media",
            "Alta"});
            this.checkListCriticidad.Location = new System.Drawing.Point(12, 17);
            this.checkListCriticidad.Name = "checkListCriticidad";
            this.checkListCriticidad.Size = new System.Drawing.Size(200, 79);
            this.checkListCriticidad.TabIndex = 44;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkListUsuarios);
            this.groupBox1.Location = new System.Drawing.Point(23, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 128);
            this.groupBox1.TabIndex = 65;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "usuarios";
            // 
            // checkListUsuarios
            // 
            this.checkListUsuarios.FormattingEnabled = true;
            this.checkListUsuarios.Location = new System.Drawing.Point(14, 17);
            this.checkListUsuarios.Name = "checkListUsuarios";
            this.checkListUsuarios.Size = new System.Drawing.Size(200, 79);
            this.checkListUsuarios.TabIndex = 43;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker2.Location = new System.Drawing.Point(687, 53);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 64;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(634, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "HASTA:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker1.Location = new System.Drawing.Point(327, 57);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 62;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(274, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "DESDE:";
            // 
            // btn_volver
            // 
            this.btn_volver.Location = new System.Drawing.Point(23, 18);
            this.btn_volver.Margin = new System.Windows.Forms.Padding(2);
            this.btn_volver.Name = "btn_volver";
            this.btn_volver.Size = new System.Drawing.Size(100, 24);
            this.btn_volver.TabIndex = 70;
            this.btn_volver.Text = "Volver";
            this.btn_volver.UseVisualStyleBackColor = true;
            this.btn_volver.Click += new System.EventHandler(this.btn_volver_Click);
            // 
            // rpv1
            // 
            reportDataSource1.Name = "DS_Bitacora";
            reportDataSource1.Value = this.ModeloBitacoraBindingSource;
            this.rpv1.LocalReport.DataSources.Add(reportDataSource1);
            this.rpv1.LocalReport.ReportEmbeddedResource = "UI.Reporte.Bitacora.rdlc";
            this.rpv1.Location = new System.Drawing.Point(277, 94);
            this.rpv1.Name = "rpv1";
            this.rpv1.ServerReport.BearerToken = null;
            this.rpv1.Size = new System.Drawing.Size(612, 234);
            this.rpv1.TabIndex = 71;
            // 
            // chkTodos
            // 
            this.chkTodos.AutoSize = true;
            this.chkTodos.Location = new System.Drawing.Point(35, 57);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Size = new System.Drawing.Size(56, 17);
            this.chkTodos.TabIndex = 72;
            this.chkTodos.Text = "Todos";
            this.chkTodos.UseVisualStyleBackColor = true;
            this.chkTodos.CheckedChanged += new System.EventHandler(this.chkTodos_CheckedChanged);
            // 
            // chkTodas
            // 
            this.chkTodas.AutoSize = true;
            this.chkTodas.Location = new System.Drawing.Point(37, 222);
            this.chkTodas.Name = "chkTodas";
            this.chkTodas.Size = new System.Drawing.Size(56, 17);
            this.chkTodas.TabIndex = 73;
            this.chkTodas.Text = "Todas";
            this.chkTodas.UseVisualStyleBackColor = true;
            this.chkTodas.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // BitacoraUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 424);
            this.Controls.Add(this.chkTodas);
            this.Controls.Add(this.chkTodos);
            this.Controls.Add(this.rpv1);
            this.Controls.Add(this.btn_volver);
            this.Controls.Add(this.btn_filtrar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BitacoraUI";
            this.Text = "Bitacora";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BitacoraUI_FormClosing);
            this.Load += new System.EventHandler(this.Bitacora_Load);
            this.Enter += new System.EventHandler(this.BitacoraUI_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.ModeloBitacoraBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_filtrar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox checkListCriticidad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox checkListUsuarios;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_volver;
        private Microsoft.Reporting.WinForms.ReportViewer rpv1;
        private System.Windows.Forms.BindingSource ModeloBitacoraBindingSource;
        private System.Windows.Forms.CheckBox chkTodos;
        private System.Windows.Forms.CheckBox chkTodas;
    }
}