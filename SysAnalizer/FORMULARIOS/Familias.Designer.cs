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
            this.lstFamilias = new System.Windows.Forms.ListBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnNueva = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnBaja = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstFamilias
            // 
            this.lstFamilias.FormattingEnabled = true;
            this.lstFamilias.ItemHeight = 16;
            this.lstFamilias.Location = new System.Drawing.Point(36, 69);
            this.lstFamilias.Name = "lstFamilias";
            this.lstFamilias.Size = new System.Drawing.Size(286, 212);
            this.lstFamilias.TabIndex = 0;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(13, 13);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(91, 31);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            // 
            // btnNueva
            // 
            this.btnNueva.Location = new System.Drawing.Point(36, 303);
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Size = new System.Drawing.Size(90, 34);
            this.btnNueva.TabIndex = 2;
            this.btnNueva.Text = "Nueva";
            this.btnNueva.UseVisualStyleBackColor = true;
            this.btnNueva.Click += new System.EventHandler(this.btnNueva_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(132, 303);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(92, 34);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnBaja
            // 
            this.btnBaja.Location = new System.Drawing.Point(230, 303);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(92, 34);
            this.btnBaja.TabIndex = 4;
            this.btnBaja.Text = "Baja";
            this.btnBaja.UseVisualStyleBackColor = true;
            // 
            // Familias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 364);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNueva);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lstFamilias);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Familias";
            this.Text = "Familias";
            this.Load += new System.EventHandler(this.Familias_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstFamilias;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnNueva;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnBaja;
    }
}