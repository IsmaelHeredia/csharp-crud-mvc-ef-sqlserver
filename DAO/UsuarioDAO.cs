// Written By Ismael Heredia in the year 2017

using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAO
{
    public class UsuarioDAO
    {
        public List<Usuario> List(string patron)
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                sistemaEntities context = new sistemaEntities();
                if (patron == null)
                {
                    patron = "";
                }
                usuarios = (from u in context.usuarios
                            select u).Where(p => p.nombre.Contains(patron)).ToList();
            }
            catch
            {
                throw;
            }
            return usuarios;
        }

        public Usuario Get(int id)
        {
            Usuario usuario = new Usuario();
            try
            {
                sistemaEntities context = new sistemaEntities();
                usuario = (from u in context.usuarios
                                select u).Where(p => p.id == id).Single();
            }
            catch
            {
                return null;
            }
            return usuario;
        }

        public bool Add(Usuario usuario)
        {
            bool respuesta = false;

            try
            {
                sistemaEntities context = new sistemaEntities();
                context.usuarios.Add(usuario);
                context.SaveChanges();
                respuesta = true;
            }
            catch
            {
                respuesta = false;
            }

            return respuesta;
        }

        public bool Update(Usuario usuario)
        {
            bool respuesta = false;

            try
            {
                sistemaEntities context = new sistemaEntities();
                Usuario usuario_update = context.usuarios.Single(u => u.id == usuario.id);
                usuario_update.id_tipo = usuario.id_tipo;
                context.SaveChanges();
                respuesta = true;
            }
            catch
            {
                respuesta = false;
            }

            return respuesta;
        }

        public bool Delete(int id)
        {
            bool respuesta = false;

            try
            {
                sistemaEntities context = new sistemaEntities();
                Usuario usuario = context.usuarios.Single(u => u.id == id);
                context.usuarios.Remove(usuario);
                context.SaveChanges();
                respuesta = true;
            }
            catch
            {
                respuesta = false;
            }

            return respuesta;
        }

        public bool check_exists_usuario_add(string nombre)
        {
            Boolean respuesta = false;
            try
            {
                sistemaEntities context = new sistemaEntities();
                var query = (from u in context.usuarios
                             select u).Where(u => u.nombre == nombre).ToList();
                if (query.Count() >= 1)
                {
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }
            }
            catch
            {
                throw;
            }
            return respuesta;
        }

        public bool check_exists_usuario_edit(int id, string nombre)
        {
            Boolean respuesta = false;
            try
            {
                sistemaEntities context = new sistemaEntities();
                var query = (from u in context.usuarios
                             select u).Where(u => u.nombre == nombre && u.id != id).ToList();
                if (query.Count() >= 1)
                {
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }
            }
            catch
            {
                throw;
            }
            return respuesta;
        }

        public bool check_login(string usuario, string clave)
        {
            sistemaEntities context = new sistemaEntities();
            var query = from u in context.usuarios
                        where u.nombre == usuario
                        && u.clave == clave
                        select u;

            if (query.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string get_user_type(string nombre)
        {
            string nombre_tipo = "";
            Usuario usuario = new Usuario();
            try
            {
                sistemaEntities context = new sistemaEntities();
                usuario = (from u in context.usuarios
                           select u).Where(u => u.nombre == nombre).Single();
                nombre_tipo = usuario.tipo.nombre;
            }
            catch
            {
                throw;
            }
            return nombre_tipo;
        }

        public int get_id_by_user(string nombre)
        {
            int id = 0;
            Usuario usuario = new Usuario();
            try
            {
                sistemaEntities context = new sistemaEntities();
                usuario = (from u in context.usuarios
                           select u).Where(u => u.nombre == nombre).Single();
                id = usuario.id;
            }
            catch
            {
                throw;
            }
            return id;
        }

        public bool change_username(int id, string nuevo_usuario)
        {
            try
            {
                sistemaEntities context = new sistemaEntities();
                Usuario usuario = context.usuarios.Single(u => u.id == id);
                usuario.nombre = nuevo_usuario;
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool change_password(int id, string nueva_clave)
        {
            try
            {
                sistemaEntities context = new sistemaEntities();
                Usuario usuario = context.usuarios.Single(u => u.id == id);
                usuario.clave = nueva_clave;
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
