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
    
    public partial class pr_polmov
    {
        public long id_poliza { get; set; }
        public long id_movimiento { get; set; }
        public string id_perejec { get; set; }
        public System.DateTime fc_emision { get; set; }
        public System.DateTime fc_inivig { get; set; }
        public System.DateTime fc_finvig { get; set; }
        public decimal prima_bruta { get; set; }
        public Nullable<decimal> prima_neta { get; set; }
        public Nullable<decimal> por_comision { get; set; }
        public Nullable<decimal> comision { get; set; }
        public long id_div { get; set; }
        public bool tipo_cuota { get; set; }
        public double num_cuota { get; set; }
        public long id_clamov { get; set; }
        public string estado { get; set; }
        public long id_dir { get; set; }
        public System.DateTime fc_recepcion { get; set; }
        public string mat_aseg { get; set; }
        public System.DateTime fc_reg { get; set; }
        public string no_liquida { get; set; }
        public long id_mom { get; set; }
    }
}
