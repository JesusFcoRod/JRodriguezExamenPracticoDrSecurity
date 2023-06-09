﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class JRodriguezExamenPracticoDrSecurityEntities : DbContext
    {
        public JRodriguezExamenPracticoDrSecurityEntities()
            : base("name=JRodriguezExamenPracticoDrSecurityEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Direccion> Direccions { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
    
        public virtual ObjectResult<PersonaGetAll_Result> PersonaGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PersonaGetAll_Result>("PersonaGetAll");
        }
    
        public virtual int PersonaDelete(Nullable<int> idPersona)
        {
            var idPersonaParameter = idPersona.HasValue ?
                new ObjectParameter("IdPersona", idPersona) :
                new ObjectParameter("IdPersona", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PersonaDelete", idPersonaParameter);
        }
    
        public virtual ObjectResult<PersonaFetById_Result> PersonaFetById(Nullable<int> idPersona)
        {
            var idPersonaParameter = idPersona.HasValue ?
                new ObjectParameter("IdPersona", idPersona) :
                new ObjectParameter("IdPersona", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PersonaFetById_Result>("PersonaFetById", idPersonaParameter);
        }
    
        public virtual int PersonaUpdate(Nullable<int> idPersona, string nombre, string apelllidoPaterno, string apellidoMaterno, Nullable<System.DateTime> fechaNacimiento, string sexo, string estadoNacimiento, Nullable<int> idDireccion, string cURP)
        {
            var idPersonaParameter = idPersona.HasValue ?
                new ObjectParameter("IdPersona", idPersona) :
                new ObjectParameter("IdPersona", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apelllidoPaternoParameter = apelllidoPaterno != null ?
                new ObjectParameter("ApelllidoPaterno", apelllidoPaterno) :
                new ObjectParameter("ApelllidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento.HasValue ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(System.DateTime));
    
            var sexoParameter = sexo != null ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(string));
    
            var estadoNacimientoParameter = estadoNacimiento != null ?
                new ObjectParameter("EstadoNacimiento", estadoNacimiento) :
                new ObjectParameter("EstadoNacimiento", typeof(string));
    
            var idDireccionParameter = idDireccion.HasValue ?
                new ObjectParameter("IdDireccion", idDireccion) :
                new ObjectParameter("IdDireccion", typeof(int));
    
            var cURPParameter = cURP != null ?
                new ObjectParameter("CURP", cURP) :
                new ObjectParameter("CURP", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PersonaUpdate", idPersonaParameter, nombreParameter, apelllidoPaternoParameter, apellidoMaternoParameter, fechaNacimientoParameter, sexoParameter, estadoNacimientoParameter, idDireccionParameter, cURPParameter);
        }
    
        public virtual int PersonaAdd(string nombre, string apelllidoPaterno, string apellidoMaterno, Nullable<System.DateTime> fechaNacimiento, string sexo, string estadoNacimiento, Nullable<int> idDireccion, string cURP)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apelllidoPaternoParameter = apelllidoPaterno != null ?
                new ObjectParameter("ApelllidoPaterno", apelllidoPaterno) :
                new ObjectParameter("ApelllidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento.HasValue ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(System.DateTime));
    
            var sexoParameter = sexo != null ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(string));
    
            var estadoNacimientoParameter = estadoNacimiento != null ?
                new ObjectParameter("EstadoNacimiento", estadoNacimiento) :
                new ObjectParameter("EstadoNacimiento", typeof(string));
    
            var idDireccionParameter = idDireccion.HasValue ?
                new ObjectParameter("IdDireccion", idDireccion) :
                new ObjectParameter("IdDireccion", typeof(int));
    
            var cURPParameter = cURP != null ?
                new ObjectParameter("CURP", cURP) :
                new ObjectParameter("CURP", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PersonaAdd", nombreParameter, apelllidoPaternoParameter, apellidoMaternoParameter, fechaNacimientoParameter, sexoParameter, estadoNacimientoParameter, idDireccionParameter, cURPParameter);
        }
    }
}
