namespace lmv9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sales_payments
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int sale_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public decimal payment_amount { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string payment_type { get; set; }

        public virtual sale sale { get; set; }
    }
}
