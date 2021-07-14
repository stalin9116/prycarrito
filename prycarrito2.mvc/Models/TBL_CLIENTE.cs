//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace prycarrito2.mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class TBL_CLIENTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_CLIENTE()
        {
            this.TBL_DIRECCIONES = new HashSet<TBL_DIRECCIONES>();
            this.TBL_PEDIDO = new HashSet<TBL_PEDIDO>();
        }
    
        [DisplayName("Codigo")]
        public long cli_id { get; set; }
        [DisplayName("Identificación")]
        [Required(ErrorMessage ="Identificación es requerido")]
        public string cli_identificacion { get; set; }

        [DisplayName("Tipo")]
        [StringLength(2)]
        [Required]
        public string cli_tipoidentificacion { get; set; }
        [DisplayName("Apellidos")]
        public string cli_apellidos { get; set; }
        [DisplayName("Nombres")]
        public string cli_nombres { get; set; }
        [DisplayName("Genero")]
        public string cli_genero { get; set; }
        [DisplayName("Fecha Nac.")]
        public System.DateTime cli_fechanacimiento { get; set; }
        [DisplayName("Telefono")]
        public string cli_telefono { get; set; }
        [DisplayName("Celular")]
        public string cli_celurar { get; set; }
        [DisplayName("Correo")]

        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Correo Inválido")]
        public string cli_email { get; set; }
        [DisplayName("Estado")]
        public string cli_status { get; set; } = "A";
        [DisplayName("Fecha Add")]
        public System.DateTime cli_fechacreacion { get; set; } = DateTime.Now;
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_DIRECCIONES> TBL_DIRECCIONES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_PEDIDO> TBL_PEDIDO { get; set; }
    }
}
