using ntu.xzmcwjzs.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntu.xzmcwjzs.Model.DataBaseContext
{
    public partial class XZMCWJZSContext : DbContext
    {
        public XZMCWJZSContext() : base("name=XZMCWJZSContext") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Test> Test { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<SearchDetail> SearchDetail { get; set; }
        public DbSet<SearchTotal> SearchTotal { get; set; }
        public DbSet<SysModule> SysModule { get; set; }
    }
}
