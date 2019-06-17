namespace lmv9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class services_prices
    {
        [Key]
        public int price_id { get; set; }

        public int service_id { get; set; }

        public decimal cost_price { get; set; }

        public decimal unit_price { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime date { get; set; }

        public short active { get; set; }

        public virtual service service { get; set; }
    }
}
