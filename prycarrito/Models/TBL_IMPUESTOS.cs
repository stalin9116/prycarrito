//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace prycarrito.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_IMPUESTOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_IMPUESTOS()
        {
            this.TBL_DETALLEIMPUESTOS = new HashSet<TBL_DETALLEIMPUESTOS>();
        }
    
        public int imp_id { get; set; }
        public string imp_codigosri { get; set; }
        public string imp_descripcion { get; set; }
        public decimal imp_porcentaje { get; set; }
        public string imp_status { get; set; }
        public System.DateTime imp_fechacreacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_DETALLEIMPUESTOS> TBL_DETALLEIMPUESTOS { get; set; }
    }
}
