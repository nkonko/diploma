﻿// <auto-generated/>
namespace UI
{
    using BE.Entidades;
    using System.Windows.Forms;

    public interface IVentaUI
    {
        Form MdiParent { get; set; }

        void Show();

        Venta ObtenerVentaSeleccionada(); 
    }
}