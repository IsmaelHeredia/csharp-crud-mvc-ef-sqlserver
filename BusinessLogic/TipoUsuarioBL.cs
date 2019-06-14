// Written By Ismael Heredia in the year 2017

using Entities;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class TipoUsuarioBL
    {
        private TipoUsuarioDAO tipousuarioDAO = new TipoUsuarioDAO();

        public List<TipoUsuario> List(string patron)
        {
            return tipousuarioDAO.List(patron);
        }
    }
}
