// Written By Ismael Heredia in the year 2017

using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace DAO
{
    public class TipoUsuarioDAO
    {
        public List<TipoUsuario> List(string patron)
        {
            List<TipoUsuario> tipos = new List<TipoUsuario>();
            try
            {
                sistemaEntities context = new sistemaEntities();
                if (patron == null)
                {
                    patron = "";
                }
                tipos = (from t in context.tipos_usuarios
                         select t).Where(t => t.nombre.Contains(patron)).ToList();
            }
            catch
            {
                throw;
            }
            return tipos;
        }
    }
}
