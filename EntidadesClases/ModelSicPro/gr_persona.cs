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
    
    public partial class gr_persona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public gr_persona()
        {
            this.co_anticom = new HashSet<co_anticom>();
            this.gr_compania = new HashSet<gr_compania>();
            this.pr_poliza = new HashSet<pr_poliza>();
        }
    
        public string id_per { get; set; }
        public string nomraz { get; set; }
        public long id_tper { get; set; }
        public Nullable<System.DateTime> fechaaniv { get; set; }
        public Nullable<long> id_sal { get; set; }
        public long id_rol { get; set; }
        public long id_tdoc { get; set; }
        public long id_emis { get; set; }
        public string nit_fac { get; set; }
        public Nullable<int> id_suc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<co_anticom> co_anticom { get; set; }
        public virtual co_porcomi co_porcomi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<gr_compania> gr_compania { get; set; }
        public virtual gr_pass gr_pass { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pr_poliza> pr_poliza { get; set; }
    }
}
