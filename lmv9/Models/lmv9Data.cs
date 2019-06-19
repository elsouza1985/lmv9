namespace lmv9.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class lmv9Data : DbContext
    {
        public lmv9Data()
            : base("name=lmv9Data")
        {
        }

        public virtual DbSet<appointment> appointments { get; set; }
        public virtual DbSet<company> companies { get; set; }
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<grant> grants { get; set; }
        public virtual DbSet<inventory> inventories { get; set; }
        public virtual DbSet<item> items { get; set; }
        public virtual DbSet<module> modules { get; set; }
        public virtual DbSet<person> people { get; set; }
        public virtual DbSet<permission> permissions { get; set; }
        public virtual DbSet<phone> phones { get; set; }
        public virtual DbSet<sale> sales { get; set; }
        public virtual DbSet<sales_items> sales_items { get; set; }
        public virtual DbSet<serviceitem> serviceitems { get; set; }
        public virtual DbSet<service> services { get; set; }
        public virtual DbSet<services_prices> services_prices { get; set; }
        public virtual DbSet<session> sessions { get; set; }
        public virtual DbSet<app_config> app_config { get; set; }
        public virtual DbSet<price> prices { get; set; }
        public virtual DbSet<sales_payments> sales_payments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<appointment>()
                .Property(e => e.appointment_date_in)
                .HasPrecision(0);

            modelBuilder.Entity<appointment>()
                .Property(e => e.appointment_date_out)
                .HasPrecision(0);

            modelBuilder.Entity<company>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<company>()
                .HasMany(e => e.appointments)
                .WithRequired(e => e.company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<company>()
                .HasMany(e => e.employees)
                .WithRequired(e => e.company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<company>()
                .HasMany(e => e.items)
                .WithRequired(e => e.company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<company>()
                .HasMany(e => e.sales)
                .WithRequired(e => e.company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.gender)
                .IsFixedLength();

            modelBuilder.Entity<customer>()
                .HasMany(e => e.appointments)
                .WithRequired(e => e.customer)
                .HasForeignKey(e => e.customer_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<customer>()
                .HasMany(e => e.sales)
                .WithRequired(e => e.customer)
                .HasForeignKey(e => e.customer_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.sales)
                .WithRequired(e => e.employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<inventory>()
                .Property(e => e.quantity)
                .HasPrecision(10, 0);

            modelBuilder.Entity<inventory>()
                .Property(e => e.trans_date)
                .HasPrecision(0);

            modelBuilder.Entity<item>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<item>()
                .Property(e => e.category)
                .IsUnicode(false);

            modelBuilder.Entity<item>()
                .HasMany(e => e.prices)
                .WithRequired(e => e.item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<item>()
                .HasMany(e => e.sales_items)
                .WithRequired(e => e.item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<module>()
                .Property(e => e.module_name)
                .IsUnicode(false);

            modelBuilder.Entity<module>()
                .Property(e => e.module_class_icon)
                .IsUnicode(false);

            modelBuilder.Entity<module>()
                .HasMany(e => e.permissions)
                .WithRequired(e => e.module)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<person>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .HasMany(e => e.companies)
                .WithRequired(e => e.person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<person>()
                .HasMany(e => e.customers)
                .WithRequired(e => e.person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<person>()
                .HasMany(e => e.employees)
                .WithRequired(e => e.person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<person>()
                .HasMany(e => e.phones)
                .WithRequired(e => e.person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<permission>()
                .Property(e => e.permission_desc)
                .IsUnicode(false);

            modelBuilder.Entity<phone>()
                .Property(e => e.phone1)
                .IsUnicode(false);

            modelBuilder.Entity<sale>()
                .Property(e => e.sale_time)
                .HasPrecision(0);

            modelBuilder.Entity<sale>()
                .HasMany(e => e.sales_payments)
                .WithRequired(e => e.sale)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sale>()
                .HasMany(e => e.sales_items)
                .WithRequired(e => e.sale)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sales_items>()
                .Property(e => e.quantity_purchased)
                .HasPrecision(10, 0);

            modelBuilder.Entity<sales_items>()
                .Property(e => e.item_cost_price)
                .HasPrecision(10, 0);

            modelBuilder.Entity<sales_items>()
                .Property(e => e.item_unit_price)
                .HasPrecision(10, 0);

            modelBuilder.Entity<service>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<service>()
                .HasMany(e => e.services_prices)
                .WithRequired(e => e.service)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<services_prices>()
                .Property(e => e.cost_price)
                .HasPrecision(10, 0);

            modelBuilder.Entity<services_prices>()
                .Property(e => e.unit_price)
                .HasPrecision(10, 0);

            modelBuilder.Entity<services_prices>()
                .Property(e => e.date)
                .HasPrecision(0);

            modelBuilder.Entity<session>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<session>()
                .Property(e => e.ip_address)
                .IsUnicode(false);

            modelBuilder.Entity<app_config>()
                .Property(e => e.key)
                .IsUnicode(false);

            modelBuilder.Entity<app_config>()
                .Property(e => e.value)
                .IsUnicode(false);

            modelBuilder.Entity<price>()
                .Property(e => e.cost_price)
                .HasPrecision(10, 0);

            modelBuilder.Entity<price>()
                .Property(e => e.unit_price)
                .HasPrecision(10, 0);

            modelBuilder.Entity<price>()
                .Property(e => e.date)
                .HasPrecision(0);

            modelBuilder.Entity<sales_payments>()
                .Property(e => e.payment_amount)
                .HasPrecision(10, 0);

            modelBuilder.Entity<sales_payments>()
                .Property(e => e.payment_type)
                .IsUnicode(false);
        }
    }
}
