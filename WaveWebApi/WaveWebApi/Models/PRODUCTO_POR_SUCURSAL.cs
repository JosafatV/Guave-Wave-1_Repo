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
    
    public partial class PRODUCTO_POR_SUCURSAL
    {
        public int IdSucursal { get; set; }
        public int IdProducto { get; set; }
        public Nullable<short> Stock { get; set; }
        public Nullable<short> StockMinimo { get; set; }
        public string Estado { get; set; }
    }
}
