//// El objetivo de esta clase es el de poder devolver permisos de los formularios en base a las patentes que tenga cargado el usuario, las patentes se deberan cargar luego
//// de consultarlas mediante la dal patente, se sumaran a las patentes del usuario las patentes obtenidas por la familia, otra funcionalidad sera la de mantener
//// la informacion del usuario.
namespace UI
{
    using BE.Entidades;
    using BLL;
    using DAL.Utils;
    using System;
    using System.Collections.Generic;

    public class FormControl : BaseDao, IFormControl
    {
        private Usuario UsuarioActivo { get; set; }

        private readonly IUsuarioBLL usuarioBLL;
        private readonly IFamiliaBLL familiaBLL;

        public FormControl(IUsuarioBLL usuarioBLL, IFamiliaBLL familiaBLL)
        {
            this.usuarioBLL = usuarioBLL;
            this.familiaBLL = familiaBLL;
        }

        public List<Formulario> ObtenerPermisosFormularios()
        {
            var query = "SELECT * FROM FormularioPatente";

            return CatchException(() =>
            {
                return Exec<Formulario>(query);
            });
        }

        public Usuario ObtenerPermisosUsuario()
        {
            var patentes = new List<Patente>();

            patentes.AddRange(usuarioBLL.ObtenerPatentesDeUsuario(UsuarioActivo.IdUsuario));

            patentes.AddRange(familiaBLL.ObtenerPatentesFamilia(UsuarioActivo.Familia.IdFamilia));

            UsuarioActivo.Patentes = patentes;

            return UsuarioActivo;
        }

        public void GuardarDatosSesionUsuario(Usuario usuario)
        {
            UsuarioActivo = usuario;
        }

        public Usuario ObtenerInfoUsuario()
        {
            return UsuarioActivo;
        }

        public Dictionary<string, bool> AccesosUsuario()
        {
            var accesos = new Dictionary<string, bool>();
            var patentesForm = ObtenerPermisosFormularios();
            var patentesUsu = ObtenerPermisosUsuario().Patentes;
            ////var patUsu = patentesUsu.Select(x => x.IdPatente);
            ////var iguales = patUsu.Intersect(patentesForm.Select(pf => pf.IdPatente));

            foreach (var form in patentesForm)
            {
                foreach (var patUsu in patentesUsu)
                {
                    if (form.IdPatente == patUsu.IdPatente)
                    {
                        accesos.Add(form.Descripcion, true);
                    }
                    else
                    {
                        accesos.Add(form.Descripcion, false);
                    }
                }
            }

            return accesos;
        }
    }
}
