//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntidadesClases.ModelSicPro
{
    using System;
    using System.Collections.Generic;
    
    public partial class vcb_repcob3
    {
        public string id_suc { get; set; }
        public string sucursal { get; set; }
        public Nullable<System.DateTime> fecha_cobro { get; set; }
        public Nullable<decimal> monto_cobro { get; set; }
        public Nullable<long> id_apli { get; set; }
        public string aplicacion { get; set; }
        public string id_spvs { get; set; }
        public string compania { get; set; }
        public Nullable<long> id_div { get; set; }
        public string divisa { get; set; }
        public long id_recibo { get; set; }
    }
}
