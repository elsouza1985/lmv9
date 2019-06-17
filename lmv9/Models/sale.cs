namespace lmv9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sale()
        {
            sales_payments = new HashSet<sales_payments>();
            sales_items = new HashSet<sales_items>();
        }

        [Key]
        public int sale_id { get; set; }

        public int company_id { get; set; }

        public int customer_id { get; set; }

        public int employee_id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime sale_time { get; set; }

        public virtual company company { get; set; }

        public virtual customer customer { get; set; }

        public virtual employee employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sales_payments> sales_payments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sales_items> sales_items { get; set; }
    }
}
