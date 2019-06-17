namespace lmv9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sales_items
    {
        [Key]
        public int sale_item_id { get; set; }

        public int sale_id { get; set; }

        public int item_id { get; set; }

        public int line { get; set; }

        public decimal quantity_purchased { get; set; }

        public decimal item_cost_price { get; set; }

        public decimal item_unit_price { get; set; }

        public virtual item item { get; set; }

        public virtual sale sale { get; set; }
    }
}
