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
    public class ProductoDAO
    {
        public List<Producto> List(string patron)
        {
            List<Producto> productos = new List<Producto>();
            try
            {
                sistemaEntities context = new sistemaEntities();
                if (patron == null)
                {
                    patron = "";
                }
                productos = (from p in context.productos
                             select p).Where(p => p.nombre.Contains(patron)).ToList();
            }
            catch
            {
                throw;
            }
            
            return productos;
        }

        public Producto Get(int id)
        {
            Producto producto = new Producto();
            try
            {
                sistemaEntities context = new sistemaEntities();
                producto = (from p in context.productos
                                 select p).Where(p => p.id == id).Single();
            }
            catch
            {
                return null;
            }
            return producto;
        }

        public bool Add(Producto producto)
        {
            bool respuesta = false;

            try
            {
                sistemaEntities context = new sistemaEntities();
                context.productos.Add(producto);
                context.SaveChanges();
                respuesta = true;
            }
            catch
            {
                respuesta = false;
            }

            return respuesta;
        }

        public bool Update(Producto producto)
        {
            bool respuesta = false;

            try
            {
                sistemaEntities context = new sistemaEntities();
                Producto producto_update = context.productos.Single(p => p.id == producto.id);
                producto_update.nombre = producto.nombre;
                producto_update.descripcion = producto.descripcion;
                producto_update.precio = producto.precio;
                producto_update.id_proveedor = producto.id_proveedor;
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
            try
            {
                sistemaEntities context = new sistemaEntities();
                Producto producto = context.productos.Single(p => p.id == id);
                context.productos.Remove(producto);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool check_exists_producto_add(string nombre)
        {
            Boolean respuesta = false;
            try
            {
                sistemaEntities context = new sistemaEntities();
                var query = (from p in context.productos
                             select p).Where(p => p.nombre == nombre).ToList();
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

        public bool check_exists_producto_edit(int id,string nombre)
        {
            Boolean respuesta = false;
            try
            {
                sistemaEntities context = new sistemaEntities();
                var query = (from p in context.productos
                             select p).Where(p => p.nombre == nombre && p.id != id).ToList();
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
    }
}
