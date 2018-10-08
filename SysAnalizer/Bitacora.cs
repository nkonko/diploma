﻿// <auto-generated/>
namespace UI
{
    using System;
    using System.Windows.Forms;

    public partial class Bitacora : Form
    {
        public Bitacora()
        {
            InitializeComponent();
        }

        private void Bitacora_Load(object sender, EventArgs e)
        {
            FillCheckedList();
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            Hide();
            var principal = Principal.GetInstancia();
            principal.Show();
        }

        private void FillCheckedList()
        {
           var userList = BLL.Usuario.Getinstancia().Retrive();
            
            foreach (var usu in userList)
            {
                checkListUsuarios.Items.Add(usu.Nombre);
            }
        }
    }
}
