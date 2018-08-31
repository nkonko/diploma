﻿namespace BLL
{
    using System.Collections.Generic;
    public class Usuario : BE.ICRUD<BE.Usuario>
    {

        private Usuario()
        {
        }

        private static Usuario instancia;

        public static Usuario Getinstancia()
        {
            if (instancia == null)
            {
                instancia = new Usuario();
            }
            return instancia;
        }

        public bool logIn(string email,string contraseña)
        {
            return DAL.Usuario.Getinstancia().LogIn(email,contraseña);
        }


        public bool Create(BE.Usuario ObjAlta)
        {
            return DAL.Usuario.Getinstancia().Create(ObjAlta);
        }

        public List<BE.Usuario> Retrive()
        {
            return DAL.Usuario.Getinstancia().Retrive();
        }

        public bool Delete(BE.Usuario ObjDel)
        {
            return DAL.Usuario.Getinstancia().Delete(ObjDel);
        }

        public bool Update(BE.Usuario ObjUpd)
        {
            return DAL.Usuario.Getinstancia().Update(ObjUpd);
        }
    }
}
