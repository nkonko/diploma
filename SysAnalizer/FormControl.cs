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

            patentes.AddRange(usuarioBLL.ObtenerPatentesDeUsuario(UsuarioActivo.UsuarioId));

            patentes.AddRange(familiaBLL.ObtenerPatentesFamilia(UsuarioActivo.Familia.Select(x => x.FamiliaId).ToList()));

            patentes = patentes.GroupBy(p => p.IdPatente).Select(grp => grp.First()).ToList();

            UsuarioActivo.Patentes = patentes;

            return UsuarioActivo;
        }

        public void GuardarDatosSesionUsuario(Usuario usuario)
        {
            usuario.Familia = new List<Familia>();

            var famIds = familiaBLL.ObtenerIdsFamiliasPorUsuario(usuario.UsuarioId);

            foreach (var id in famIds)
            {
                usuario.Familia.Add(new Familia() { FamiliaId = id, Descripcion = familiaBLL.ObtenerDescripcionFamiliaPorId(id) });
            }

            UsuarioActivo = usuario;
        }

        public Usuario ObtenerInfoUsuario()
        {
            return UsuarioActivo;
        }

        public List<Patente> ObtenerPermisosFormulario(int formId)
        {
            return formControlBLL.ObtenerPermisosFormulario(formId);
        }
    }
}
