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
    
    public partial class vcb_sumexclucuotas
    {
        public long id_poliza { get; set; }
        public long id_movimiento { get; set; }
        public long id_excluye { get; set; }
        public decimal excluye_cuota { get; set; }
        public Nullable<decimal> monto_exclusion_s { get; set; }
        public Nullable<decimal> neta_exclusion_s { get; set; }
        public Nullable<decimal> comision_exclusion_s { get; set; }
    }
}
