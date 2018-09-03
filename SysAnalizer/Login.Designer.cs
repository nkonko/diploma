namespace SysAnalizer
{
    partial class Login
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.txt_contraseña = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Lnk_Recuperar_Password = new System.Windows.Forms.LinkLabel();
            this.btn_ingresar = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.cbo_idioma = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //// 
            //// label1
            //// 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Por favor ingrese usuario y contraseña para ingresar";
            //// 
            //// label2
            //// 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Usuario:";
            //// 
            //// txt_user
            //// 
            this.txt_user.Location = new System.Drawing.Point(12, 71);
            this.txt_user.Margin = new System.Windows.Forms.Padding(2);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(255, 20);
            this.txt_user.TabIndex = 2;
            //// 
            //// txt_contraseña
            //// 
            this.txt_contraseña.Location = new System.Drawing.Point(11, 126);
            this.txt_contraseña.Margin = new System.Windows.Forms.Padding(2);
            this.txt_contraseña.Name = "txt_contraseña";
            this.txt_contraseña.Size = new System.Drawing.Size(255, 20);
            this.txt_contraseña.TabIndex = 4;
            //// 
            //// label3
            //// 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Contraseña:";
            //// 
            //// Lnk_Recuperar_Password
            //// 
            this.Lnk_Recuperar_Password.AutoSize = true;
            this.Lnk_Recuperar_Password.Location = new System.Drawing.Point(10, 154);
            this.Lnk_Recuperar_Password.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lnk_Recuperar_Password.Name = "Lnk_Recuperar_Password";
            this.Lnk_Recuperar_Password.Size = new System.Drawing.Size(114, 13);
            this.Lnk_Recuperar_Password.TabIndex = 5;
            this.Lnk_Recuperar_Password.TabStop = true;
            this.Lnk_Recuperar_Password.Text = "Recuperar Contraseña";
            //// 
            //// btn_ingresar
            //// 
            this.btn_ingresar.Location = new System.Drawing.Point(20, 266);
            this.btn_ingresar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ingresar.Name = "btn_ingresar";
            this.btn_ingresar.Size = new System.Drawing.Size(112, 31);
            this.btn_ingresar.TabIndex = 6;
            this.btn_ingresar.Text = "Ingresar";
            this.btn_ingresar.UseVisualStyleBackColor = true;
            this.btn_ingresar.Click += new System.EventHandler(this.btn_ingresar_Click);
            //// 
            //// btn_salir
            //// 
            this.btn_salir.Location = new System.Drawing.Point(157, 266);
            this.btn_salir.Margin = new System.Windows.Forms.Padding(2);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(92, 31);
            this.btn_salir.TabIndex = 7;
            this.btn_salir.Text = "Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            //// 
            //// cbo_idioma
            //// 
            this.cbo_idioma.FormattingEnabled = true;
            this.cbo_idioma.Location = new System.Drawing.Point(158, 204);
            this.cbo_idioma.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_idioma.Name = "cbo_idioma";
            this.cbo_idioma.Size = new System.Drawing.Size(92, 21);
            this.cbo_idioma.TabIndex = 8;
            //// 
            //// label4
            //// 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 204);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Seleccionar Idioma";
            //// 
            //// Login
            //// 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 318);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbo_idioma);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.btn_ingresar);
            this.Controls.Add(this.Lnk_Recuperar_Password);
            this.Controls.Add(this.txt_contraseña);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_user);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Login";
            this.Text = "SysAnalizer - Acceso ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.TextBox txt_contraseña;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel Lnk_Recuperar_Password;
        private System.Windows.Forms.Button btn_ingresar;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.ComboBox cbo_idioma;
        private System.Windows.Forms.Label label4;
    }
}

