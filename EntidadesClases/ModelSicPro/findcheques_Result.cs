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
    
    public partial class findcheques_Result
    {
        public string cheque { get; set; }
        public string id_spvs { get; set; }
        public string nomrazcia { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<decimal> comision_pc { get; set; }
        public Nullable<decimal> comisaldo_pc { get; set; }
        public string pago_mes { get; set; }
        public Nullable<decimal> pc_mes { get; set; }
        public Nullable<decimal> pc_anio { get; set; }
    }
}