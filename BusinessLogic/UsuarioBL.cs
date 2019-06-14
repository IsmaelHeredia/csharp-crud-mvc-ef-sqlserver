// Written By Ismael Heredia in the year 2017

using DAO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class UsuarioBL
    {
        private UsuarioDAO usuarioDAO = new UsuarioDAO();

        public List<Usuario> List(string patron)
        {
            return usuarioDAO.List(patron);
        }

        public Usuario Get(int id)
        {
            return usuarioDAO.Get(id);
        }

        public bool Add(Usuario usuario)
        {
            return usuarioDAO.Add(usuario);
        }

        public bool Update(Usuario usuario)
        {
            return usuarioDAO.Update(usuario);
        }

        public bool Delete(int id)
        {
            return usuarioDAO.Delete(id);
        }

        public bool check_exists_usuario_add(string nombre)
        {
            return usuarioDAO.check_exists_usuario_add(nombre);
        }

        public bool check_exists_usuario_edit(int id, string nombre)
        {
            return usuarioDAO.check_exists_usuario_edit(id, nombre);
        }

        public bool check_login(string usuario, string clave)
        {
            return usuarioDAO.check_login(usuario, clave);
        }

        public int get_id_by_user(string usuario)
        {
            return usuarioDAO.get_id_by_user(usuario);
        }

        public string get_user_type(string usuario)
        {
            return usuarioDAO.get_user_type(usuario);
        }

        public bool change_username(int id, string nuevo_usuario)
        {
            return usuarioDAO.change_username(id,nuevo_usuario);
        }

        public bool change_password(int id, string nueva_clave)
        {
            return usuarioDAO.change_password(id, nueva_clave);
        }

    }
}
