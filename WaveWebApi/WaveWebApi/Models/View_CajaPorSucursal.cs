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
    
    public partial class View_CajaPorSucursal
    {
        public int IdCaja { get; set; }
        public Nullable<decimal> Dinero { get; set; }
        public string Estado { get; set; }
        public int IdSucursal { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public Nullable<int> Telefono { get; set; }
        public string EstadoSucursal { get; set; }
    }
}
