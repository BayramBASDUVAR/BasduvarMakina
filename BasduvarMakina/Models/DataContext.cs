using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BasduvarMakina.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base("name=DataContext")
        {}
        public DbSet<User> user { get; set; }
    }
}