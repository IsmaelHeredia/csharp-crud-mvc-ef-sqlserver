﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class sistemaEntities : DbContext
    {
        public sistemaEntities()
            : base("name=sistemaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Producto> productos { get; set; }
        public DbSet<Proveedor> proveedores { get; set; }
        public DbSet<TipoUsuario> tipos_usuarios { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
    }
}
