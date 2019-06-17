namespace lmv9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("inventory")]
    public partial class inventory
    {
        [Key]
        public int inventory_id { get; set; }

        public int item_id { get; set; }

        public decimal quantity { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime trans_date { get; set; }
    }
}
