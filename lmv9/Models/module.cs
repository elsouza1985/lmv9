namespace lmv9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class module
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public module()
        {
            permissions = new HashSet<permission>();
        }

        [Key]
        public int module_id { get; set; }

        [Required]
        [StringLength(15)]
        public string module_name { get; set; }

        public short module_active { get; set; }

        public int sort { get; set; }

        [Required]
        [StringLength(500)]
        public string module_class_icon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<permission> permissions { get; set; }
    }
}
