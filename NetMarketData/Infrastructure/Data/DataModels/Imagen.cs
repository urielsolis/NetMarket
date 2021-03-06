//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NetMarketData.Infrastructure.Data.DataModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Imagen
    {
        public long idImagen { get; set; }
        public string rutaImagen { get; set; }
        public Nullable<long> idProducto { get; set; }
        public Nullable<long> idOferta { get; set; }
        public Nullable<long> idEmpresa { get; set; }
        public Nullable<long> idSucursal { get; set; }
        public Nullable<long> idProductoSucursal { get; set; }
        public Nullable<long> idProductoEmpresa { get; set; }
        public Nullable<long> idPersona { get; set; }
        public Nullable<long> idCategoria { get; set; }
        public bool Principal { get; set; }
        public bool eliminado { get; set; }
    
        public virtual CategoriaProducto CategoriaProducto { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual oferta oferta { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual ProductoEmpresa ProductoEmpresa { get; set; }
        public virtual ProductoSucursal ProductoSucursal { get; set; }
        public virtual Sucursal Sucursal { get; set; }
    }
}
