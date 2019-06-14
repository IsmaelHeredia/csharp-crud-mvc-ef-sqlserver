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
    public class ProveedorDAO
    {
        public List<Proveedor> List(string patron)
        {
            List<Proveedor> proveedores = new List<Proveedor>();
            try
            {
                sistemaEntities context = new sistemaEntities();
                if (patron == null)
                {
                    patron = "";
                }
                proveedores = (from p in context.proveedores
                               select p).Where(p => p.nombre.Contains(patron)).ToList();
            }
            catch
            {
                throw;
            }
            return proveedores;
        }

        public Proveedor Get(int id)
        {
            Proveedor proveedor = new Proveedor();
            try
            {
                sistemaEntities context = new sistemaEntities();
                proveedor = (from p in context.proveedores
                                  select p).Where(p => p.id == id).Single();
            }
            catch
            {
                return null;
            }
            return proveedor;
        }

        public bool Add(Proveedor proveedor)
        {
            bool respuesta = false;

            try
            {
                sistemaEntities context = new sistemaEntities();
                context.proveedores.Add(proveedor);
                context.SaveChanges();
                respuesta = true;
            }
            catch
            {
                respuesta = false;
            }

            return respuesta;
        }

        public bool Update(Proveedor proveedor)
        {
            bool respuesta = false;

            try
            {
                sistemaEntities context = new sistemaEntities();
                Proveedor proveedor_update = context.proveedores.Single(p => p.id == proveedor.id);
                proveedor_update.nombre = proveedor.nombre;
                proveedor_update.direccion = proveedor.direccion;
                proveedor_update.telefono = proveedor.telefono;
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
                Proveedor proveedor = context.proveedores.Single(p => p.id == id);
                context.proveedores.Remove(proveedor);
                context.SaveChanges();
                respuesta = true;
            }
            catch
            {
                respuesta = false;
            }

            return respuesta;
        }

        public bool check_exists_proveedor_add(string nombre)
        {
            Boolean respuesta = false;
            try
            {
                sistemaEntities context = new sistemaEntities();
                var query = (from p in context.proveedores
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

        public bool check_exists_proveedor_edit(int id, string nombre)
        {
            Boolean respuesta = false;
            try
            {
                sistemaEntities context = new sistemaEntities();
                var query = (from p in context.proveedores
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
