using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OplataTruda
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("SotrudnikiEntities1")
        { }
        public DbSet<Sotrudnik> S { get; set; }
        public DbSet<PaymentHistory> P { get; set; }
        public DbSet<SotrHistory> SH { get; set; }
        public DbSet<TypeAction> T { get; set; }
    }

}
