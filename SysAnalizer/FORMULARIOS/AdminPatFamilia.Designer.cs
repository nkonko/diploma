﻿// <auto-generated/>
namespace UI
{
    partial class AdminPatFamilia
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
            this.lblFamilia = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstPatentes = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(16, 15);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(92, 28);
            this.btnVolver.TabIndex = 58;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblFamilia
            // 
            this.lblFamilia.AutoSize = true;
            this.lblFamilia.Location = new System.Drawing.Point(116, 21);
            this.lblFamilia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFamilia.Name = "lblFamilia";
            this.lblFamilia.Size = new System.Drawing.Size(56, 17);
            this.lblFamilia.TabIndex = 56;
            this.lblFamilia.Text = "Familia:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstPatentes);
            this.groupBox1.Location = new System.Drawing.Point(16, 76);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(243, 208);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PATENTES";
            // 
            // lstPatentes
            // 
            this.lstPatentes.FormattingEnabled = true;
            this.lstPatentes.Items.AddRange(new object[] {
            "Patente 1",
            "Patente 2",
            "Patente 3",
            "Patente 4",
            "Patente 5",
            "Patente 6",
            "Patente 7",
            "Patente 8",
            "Patente 9"});
            this.lstPatentes.Location = new System.Drawing.Point(20, 23);
            this.lstPatentes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstPatentes.Name = "lstPatentes";
            this.lstPatentes.Size = new System.Drawing.Size(201, 157);
            this.lstPatentes.TabIndex = 55;
            this.lstPatentes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstPatentes_ItemCheck);
            this.lstPatentes.SelectedIndexChanged += new System.EventHandler(this.lstPatentes_SelectedIndexChanged);
            // 
            // AdminPatFamilia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 313);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lblFamilia);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AdminPatFamilia";
            this.Text = "AdminPatFamilia";
            this.Load += new System.EventHandler(this.AdminPatFamilia_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblFamilia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox lstPatentes;
    }
}