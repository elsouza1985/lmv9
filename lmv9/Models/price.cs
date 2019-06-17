namespace lmv9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class price
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int price_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int item_id { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal cost_price { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal unit_price { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "datetime2")]
        public DateTime date { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short active { get; set; }

        public virtual item item { get; set; }
    }
}
