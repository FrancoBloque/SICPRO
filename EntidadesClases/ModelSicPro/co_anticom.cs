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
    
    public partial class co_anticom
    {
        public int id_anco { get; set; }
        public System.DateTime fc_solicitud { get; set; }
        public string doc_cont { get; set; }
        public Nullable<decimal> imp_anticipo { get; set; }
        public string desc_anti { get; set; }
        public string id_percart { get; set; }
        public string TRIAL357 { get; set; }
    
        public virtual gr_persona gr_persona { get; set; }
    }
}
