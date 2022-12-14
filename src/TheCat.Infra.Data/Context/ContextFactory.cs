using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCat.Infra.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<TheCatContext>
    {
        public TheCatContext CreateDbContext(string[] args)
        {
            //Usado para Criar as Migrações
            var connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=TheCat;User ID=rfcunha;Password=1234567";
            var optionsBuilder = new DbContextOptionsBuilder<TheCatContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new TheCatContext(optionsBuilder.Options);
        }
    }
}
