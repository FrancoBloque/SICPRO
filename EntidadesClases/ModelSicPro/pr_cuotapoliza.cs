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
    
    public partial class pr_cuotapoliza
    {
        public long id_poliza { get; set; }
        public long id_movimiento { get; set; }
        public decimal cuota { get; set; }
        public Nullable<System.DateTime> fecha_pago { get; set; }
        public Nullable<decimal> cuota_total { get; set; }
        public Nullable<decimal> cuota_neta { get; set; }
        public Nullable<decimal> cuota_comis { get; set; }
        public Nullable<decimal> cuota_pago { get; set; }
        public Nullable<decimal> cuota_comicob { get; set; }
        public string TRIAL360 { get; set; }
    
        public virtual pr_polmov pr_polmov { get; set; }
    }
}
