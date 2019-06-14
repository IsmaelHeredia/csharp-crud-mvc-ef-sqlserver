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
    public class ProveedorBL
    {
        private ProveedorDAO proveedorDAO = new ProveedorDAO();

        public List<Proveedor> List(string patron)
        {
            return proveedorDAO.List(patron);
        }

        public Proveedor Get(int id)
        {
            return proveedorDAO.Get(id);
        }

        public bool Add(Proveedor proveedor)
        {
            return proveedorDAO.Add(proveedor);
        }

        public bool Update(Proveedor proveedor)
        {
            return proveedorDAO.Update(proveedor);
        }

        public bool Delete(int id)
        {
            return proveedorDAO.Delete(id);
        }

        public bool check_exists_proveedor_add(string nombre)
        {
            return proveedorDAO.check_exists_proveedor_add(nombre);
        }

        public bool check_exists_proveedor_edit(int id, string nombre)
        {
            return proveedorDAO.check_exists_proveedor_edit(id, nombre);
        }

    }
}
