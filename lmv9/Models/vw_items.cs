namespace lmv9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vw_items
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string name { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string category { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal cost_price { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal unit_price { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int item_id { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int company_id { get; set; }
    }
}
