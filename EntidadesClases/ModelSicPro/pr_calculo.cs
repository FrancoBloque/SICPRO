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
    
    public partial class pr_calculo
    {
        public string id_riesgo { get; set; }
        public string id_spvs { get; set; }
        public string formula { get; set; }
        public Nullable<double> comision { get; set; }
        public string TRIAL360 { get; set; }
    
        public virtual pr_riesgo pr_riesgo { get; set; }
    }
}
