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
    
    public partial class vcb_listacuoamort
    {
        public long id_poliza { get; set; }
        public long id_movimiento { get; set; }
        public decimal cuota { get; set; }
        public Nullable<decimal> cuota_total { get; set; }
        public Nullable<decimal> monto_pago { get; set; }
        public Nullable<double> factura { get; set; }
        public Nullable<System.DateTime> fecha_factura { get; set; }
    }
}