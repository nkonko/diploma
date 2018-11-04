namespace UI
{
    using BE.Entidades;
    using BLL;
    using DAL.Utils;
    using System.Collections.Generic;
    using System.Linq;

    public class FormControl : BaseDao, IFormControl
    {
        private Usuario UsuarioActivo { get; set; }

        private readonly IUsuarioBLL usuarioBLL;
        private readonly IFamiliaBLL familiaBLL;
        private readonly IFormControlBLL formControlBLL;

        public FormControl(IUsuarioBLL usuarioBLL, IFamiliaBLL familiaBLL, IFormControlBLL formControlBLL)
        {
            this.usuarioBLL = usuarioBLL;
            this.familiaBLL = familiaBLL;
            this.formControlBLL = formControlBLL;
        }

        public List<Patente> ObtenerPermisosFormularios()
        {
            return formControlBLL.ObtenerPermisosFormularios();
        }

        public Usuario ObtenerPermisosUsuario()
        {
            var patentes = new List<Patente>();

            patentes.AddRange(usuarioBLL.ObtenerPatentesDeUsuario(UsuarioActivo.IdUsuario));

            patentes.AddRange(familiaBLL.ObtenerPatentesFamilia(UsuarioActivo.Familia.FamiliaId));

            patentes = patentes.GroupBy(p => p.IdPatente).Select(grp => grp.First()).ToList();

            UsuarioActivo.Patentes = patentes;

            return UsuarioActivo;
        }

        public void GuardarDatosSesionUsuario(Usuario usuario)
        {
            usuario.Familia = new Familia();
            usuario.Familia.FamiliaId = familiaBLL.ObtenerIdFamiliaPorUsuario(usuario.IdUsuario);
            usuario.Familia.Descripcion = familiaBLL.ObtenerDescripcionFamiliaPorId(usuario.Familia.FamiliaId);

            UsuarioActivo = usuario;
        }

        public Usuario ObtenerInfoUsuario()
        {
            return UsuarioActivo;
        }

        ////public Dictionary<string, bool> AccesosUsuario()
        ////{
        ////    var accesos = new Hashtable();
            
        ////    var patentesForm = ObtenerPermisosFormularios();
        ////    var patentesUsu = ObtenerPermisosUsuario().Patentes;
        ////    ////var patUsu = patentesUsu.Select(x => x.IdPatente);
        ////    ////var iguales = patUsu.Intersect(patentesForm.Select(pf => pf.IdPatente));

        ////    var q = patentesUsu.Where(item => patentesForm.Select(item2 => item2.IdPatente).Contains(item.IdPatente)).ToList();
        ////    var d = (from item in patentesForm
        ////            where item.IdPatente.Equals(from item2 in patentesUsu select item.IdPatente)
        ////            select item.Descripcion).ToList();
        ////    accesos.Add(d, q);

        ////    foreach (var form in patentesForm)
        ////    {
        ////        foreach (var patUsu in patentesUsu)
        ////        {
        ////            if (form.IdPatente == patUsu.IdPatente)
        ////            {
        ////                accesos.Add(form.Descripcion, true);
        ////            }
        ////            else
        ////            {
        ////                accesos.Add(form.Descripcion, false);
        ////            }
        ////        }
        ////    }

        ////    return null;
        ////}
    }
}
