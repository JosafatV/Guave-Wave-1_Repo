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
    
    public partial class View_VentaPorCliente
    {
        public int IdVenta { get; set; }
        public Nullable<System.DateTime> Timestamp { get; set; }
        public string Estado { get; set; }
        public int IdCliente { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public string EstadoCliente { get; set; }
    }
}
