using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using UtilsNET;

namespace _8.Models
{
    public class Dict_Entity : DbContext
    {
        // Your context has been configured to use a 'Dict_Entity' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // '_3.Models.Dict_Entity' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Dict_Entity' 
        // connection string in the application configuration file.
        public DbSet<Data> Dicts { get; set; }

        public Dict_Entity()
            : base(@"name=Dict_Entity")
        {
        }

        public Dict_Entity(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }
}
