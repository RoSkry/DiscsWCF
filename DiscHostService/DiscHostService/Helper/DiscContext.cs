using DiscHostService.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscHostService
{
    class DiscContext:DbContext
    {
        public DiscContext():base("Disc")
        {            
        }

        public DbSet<Band> Bands { get; set; }
        public DbSet<CD> CDs { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Format> Formats { get; set; }
        public DbSet<Selling> Sellings { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<CD>()
            //            .HasRequired(e => e.Selling)
            //            .WithMany(t => t.CDs)
            //            .HasForeignKey(e => e.SellingId)
            //            .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Seller>()
            //            .HasRequired(e => e.Selling)
            //            .WithMany(t => t.Sellers)
            //            .HasForeignKey(e => e.SellingId)
            //            .WillCascadeOnDelete(false);
        }
    }
}
