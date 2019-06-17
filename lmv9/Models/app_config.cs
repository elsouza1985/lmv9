namespace lmv9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class app_config
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(255)]
        public string key { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string value { get; set; }

        public int? company_id { get; set; }
    }
}
