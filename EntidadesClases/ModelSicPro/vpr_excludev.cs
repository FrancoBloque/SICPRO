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
    
    public partial class vpr_excludev
    {
        public long id_poliza { get; set; }
        public long id_movimiento { get; set; }
        public decimal excluye_cuota { get; set; }
        public Nullable<decimal> smonto_exclusion { get; set; }
        public Nullable<decimal> sneta_exclusion { get; set; }
        public Nullable<decimal> scomision_exclusion { get; set; }
        public decimal smonto_devolucion { get; set; }
        public decimal sneta_devolucion { get; set; }
        public decimal scomision_devolucion { get; set; }
    }
}