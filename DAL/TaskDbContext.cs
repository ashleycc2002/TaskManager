using Domainn1;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class TaskDbContext : DbContext
    {
        //public const string conectionString = @"Data Source=DESKTOP-S1KPBO3;Initial Catalog=Evaluacion;Integrated Security=SSPI; User ID=sa;Password=rossy2233;";

        public TaskDbContext() : base("DBCS")
        {
            Database.SetInitializer<TaskDbContext>(null);
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Tasks> tasks { get; set; }
      
    }
}
