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
    
    public partial class pr_recibo
    {
        public long id_recibo { get; set; }
        public decimal anio_recibo { get; set; }
        public Nullable<System.DateTime> fecha_entregado { get; set; }
        public string id_suc { get; set; }
        public string id_perucb { get; set; }
        public string id_perclie { get; set; }
        public Nullable<System.DateTime> fecha_cobro { get; set; }
        public Nullable<decimal> monto_cobro { get; set; }
        public Nullable<decimal> monto_resto { get; set; }
        public string recibo_por { get; set; }
        public Nullable<long> id_div { get; set; }
        public Nullable<long> id_apli { get; set; }
        public Nullable<long> id_liq { get; set; }
        public Nullable<decimal> cont_bs { get; set; }
        public Nullable<decimal> cont_sus { get; set; }
        public Nullable<decimal> cheq_bs { get; set; }
        public Nullable<decimal> cheq_sus { get; set; }
    }
}
