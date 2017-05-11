using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventApplication.Helper
{
    public static class Extension
    {
        public static DbContextOptionsBuilder UseInMemoryDatabase(
    this DbContextOptionsBuilder optionsBuilder,
    string databaseName)
        {
            var extension = optionsBuilder.Options.FindExtension<InMemoryOptionsExtension>();

            extension = extension != null
                ? new InMemoryOptionsExtension(extension)
                : new InMemoryOptionsExtension();

            extension.StoreName = databaseName;

            ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(extension);

            return optionsBuilder;
        }
        public static DbContextOptionsBuilder UseSqlServer(
    this DbContextOptionsBuilder optionsBuilder,
    string connectionString,
    Action<SqlServerDbContextOptionsBuilder> sqlServerOptionsAction = null)
        {
            // Usual options extension stuff...

            sqlServerOptionsAction?.Invoke(new SqlServerDbContextOptionsBuilder(optionsBuilder));

            return optionsBuilder;
        }
    }
}
