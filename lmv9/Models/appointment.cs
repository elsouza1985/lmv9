namespace lmv9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class appointment
    {
        [Key]
        public int appointment_id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime appointment_date_in { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime appointment_date_out { get; set; }

        public int customer_id { get; set; }

        public int company_id { get; set; }

        public virtual company company { get; set; }

        public virtual customer customer { get; set; }
    }
}
