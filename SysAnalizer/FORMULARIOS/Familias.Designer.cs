﻿// <auto-generated/>
namespace UI
{
    partial class Familias
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
            this.btnNueva = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnBaja = new System.Windows.Forms.Button();
            this.chklstFamilias = new System.Windows.Forms.CheckedListBox();
            this.btnModificarTodo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(10, 11);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(2);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(68, 25);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnNueva
            // 
            this.btnNueva.Location = new System.Drawing.Point(175, 55);
            this.btnNueva.Margin = new System.Windows.Forms.Padding(2);
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Size = new System.Drawing.Size(68, 28);
            this.btnNueva.TabIndex = 2;
            this.btnNueva.Text = "Nueva";
            this.btnNueva.UseVisualStyleBackColor = true;
            this.btnNueva.Click += new System.EventHandler(this.btnNueva_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(175, 95);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(69, 35);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar nombre";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnBaja
            // 
            this.btnBaja.Location = new System.Drawing.Point(175, 196);
            this.btnBaja.Margin = new System.Windows.Forms.Padding(2);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(69, 28);
            this.btnBaja.TabIndex = 4;
            this.btnBaja.Text = "Baja";
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // chklstFamilias
            // 
            this.chklstFamilias.FormattingEnabled = true;
            this.chklstFamilias.Location = new System.Drawing.Point(10, 55);
            this.chklstFamilias.Margin = new System.Windows.Forms.Padding(2);
            this.chklstFamilias.Name = "chklstFamilias";
            this.chklstFamilias.Size = new System.Drawing.Size(141, 169);
            this.chklstFamilias.TabIndex = 5;
            this.chklstFamilias.SelectedIndexChanged += new System.EventHandler(this.chklstFamilias_SelectedIndexChanged);
            // 
            // btnModificarTodo
            // 
            this.btnModificarTodo.Location = new System.Drawing.Point(175, 145);
            this.btnModificarTodo.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificarTodo.Name = "btnModificarTodo";
            this.btnModificarTodo.Size = new System.Drawing.Size(69, 37);
            this.btnModificarTodo.TabIndex = 6;
            this.btnModificarTodo.Text = "Modificar Patentes";
            this.btnModificarTodo.UseVisualStyleBackColor = true;
            this.btnModificarTodo.Click += new System.EventHandler(this.btnModificarTodo_Click);
            // 
            // Familias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 239);
            this.Controls.Add(this.btnModificarTodo);
            this.Controls.Add(this.chklstFamilias);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNueva);
            this.Controls.Add(this.btnVolver);
            this.Name = "Familias";
            this.Text = "Familias";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Familias_FormClosing);
            this.Load += new System.EventHandler(this.Familias_Load);
            this.Enter += new System.EventHandler(this.Familias_Enter);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnNueva;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.CheckedListBox chklstFamilias;
        private System.Windows.Forms.Button btnModificarTodo;
    }
}