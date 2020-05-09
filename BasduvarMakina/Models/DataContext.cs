using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BasduvarMakina.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base("name=DataContext")
        {
        }

        public virtual DbSet<User> user { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DataContext>(null);
            base.OnModelCreating(modelBuilder);

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}