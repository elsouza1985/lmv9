namespace lmv9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class grant
    {
        [Key]
        public int grant_id { get; set; }

        public int? permission_id { get; set; }

        public int? people_id { get; set; }

        public virtual person person { get; set; }

        public virtual permission permission { get; set; }
    }
}
