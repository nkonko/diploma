//// El objetivo de esta clase es el de poder devolver permisos de los formularios en base a las patentes que tenga cargado el usuario, las patentes se deberan cargar luego
//// de consultarlas mediante la dal patente, se sumaran a las patentes del usuario las patentes obtenidas por la familia, otra funcionalidad sera la de mantener
//// la informacion del usuario.
namespace UI
{
    using BE.Entidades;
    using BLL;
    using System.Collections.Generic;

    public class FormControl : IFormControl
    {
        private Usuario UsuarioActivo { get; set; }

        ////private readonly IVtaProd ventaDeProductos;
        private readonly IUsuarioBLL usuarioBLL;
        private readonly IFamiliaBLL familiaBLL;

        public FormControl(IUsuarioBLL usuarioBLL, IFamiliaBLL familiaBLL)
        {
            this.usuarioBLL = usuarioBLL;
            this.familiaBLL = familiaBLL;
        }

        public void ObtenerFormulario()
        {
            
            ////usuarioABM.Show();
        }

        public void ObtenerPermisos()
        {
            var patentes = new List<Patente>();

            patentes.AddRange(usuarioBLL.ObtenerPatentesDeUsuario(UsuarioActivo.IdUsuario));

            patentes.AddRange(familiaBLL.ObtenerPatentesFamilia(UsuarioActivo.Familia.IdFamilia));

            UsuarioActivo.Patentes = patentes;
        }

        public void GuardarDatosSesionUsuario(Usuario usuario)
        {
            UsuarioActivo = usuario;
        }

        public Usuario ObtenerInfoUsuario()
        {
            return UsuarioActivo;
        }
    }
}
