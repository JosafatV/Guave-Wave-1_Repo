//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WaveWebApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class View_ProductoPorVenta
    {
        public int IdProducto { get; set; }
        public string EAN { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public Nullable<short> Cantidad { get; set; }
        public string Estado { get; set; }
        public Nullable<System.DateTime> Timestamp { get; set; }
        public int IdVenta { get; set; }
        public int IdCaja { get; set; }
        public int IdSucursal { get; set; }
        public string NombreSucursal { get; set; }
        public string Direccion { get; set; }
    }
}
