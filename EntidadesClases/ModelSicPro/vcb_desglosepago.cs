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
    
    public partial class vcb_desglosepago
    {
        public long id_poliza { get; set; }
        public long id_movimiento { get; set; }
        public string num_poliza { get; set; }
        public string no_liquida { get; set; }
        public Nullable<decimal> cuota { get; set; }
        public Nullable<long> recliq { get; set; }
        public Nullable<decimal> monto { get; set; }
        public string pago { get; set; }
    }
}
