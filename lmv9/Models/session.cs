namespace lmv9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class session
    {
        [StringLength(40)]
        public string id { get; set; }

        [Required]
        [StringLength(45)]
        public string ip_address { get; set; }

        [Required]
        public byte[] data { get; set; }

        public int timestamp { get; set; }
    }
}
