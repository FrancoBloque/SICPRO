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
    
    public partial class pr_poliza
    {
        public long id_poliza { get; set; }
        public string num_poliza { get; set; }
        public long id_producto { get; set; }
        public string id_perclie { get; set; }
        public string id_spvs { get; set; }
        public Nullable<long> id_gru { get; set; }
        public Nullable<bool> clase_poliza { get; set; }
        public Nullable<bool> estado { get; set; }
        public Nullable<System.DateTime> fc_reg { get; set; }
        public string id_percart { get; set; }
        public Nullable<long> id_suc { get; set; }
    
        public virtual gr_persona gr_persona { get; set; }
        public virtual pr_producto pr_producto { get; set; }
    }
}
