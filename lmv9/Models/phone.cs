namespace lmv9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class phone
    {
        [Key]
        public int phone_id { get; set; }

        public int people_id { get; set; }

        [Column("phone")]
        [Required]
        [StringLength(13)]
        public string phone1 { get; set; }

        public virtual person person { get; set; }
    }
}
