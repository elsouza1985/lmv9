namespace lmv9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class serviceitem
    {
        [Key]
        public int serviceitem_id { get; set; }

        public int? service_id { get; set; }

        public int? item_id { get; set; }

        public int? portions { get; set; }
    }
}
