using Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context {
    public class DatabaseContext : DbContext {

        public DbSet<Amigo> Amigos {
            get; set;
        }

        public DatabaseContext(string connectionString) 
            : base(connectionString) {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        public static DatabaseContext Create(string connectionString) {
            return new DatabaseContext(connectionString);
        }
    }
}
