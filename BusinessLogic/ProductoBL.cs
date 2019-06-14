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
    public class ProductoBL
    {
        private ProductoDAO productoDAO = new ProductoDAO();

        public List<Producto> List(string patron)
        {
            return productoDAO.List(patron);
        }
        public Producto Get(int id)
        {
            return productoDAO.Get(id);
        }

        public bool Add(Producto producto)
        {
            return productoDAO.Add(producto);
        }

        public bool Update(Producto producto)
        {
            return productoDAO.Update(producto);
        }

        public bool Delete(int id)
        {
            return productoDAO.Delete(id);
        }

        public bool check_exists_producto_add(string nombre)
        {
            return productoDAO.check_exists_producto_add(nombre);
        }

        public bool check_exists_producto_edit(int id, string nombre)
        {
            return productoDAO.check_exists_producto_edit(id,nombre);
        }

    }
}