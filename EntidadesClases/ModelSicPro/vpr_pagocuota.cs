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
    
    public partial class vpr_pagocuota
    {
        public long id_poliza { get; set; }
        public long id_movimiento { get; set; }
        public Nullable<decimal> s_cuota_total { get; set; }
        public Nullable<decimal> s_cuota_pago { get; set; }
    }
}
