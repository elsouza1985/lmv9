namespace lmv9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vw_services
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(145)]
        public string name { get; set; }

        [Key]
        [Column(Order = 1)]
        public decimal cost_price { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal unit_price { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int service_id { get; set; }

        public int? company_id { get; set; }
    }
}
