using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTemplate.Infrastructure.Test.EntityFramework
{
    public class WebTemplateDbContextTest
    {
        //private SqliteConnection _sqliteConnection;
        //public WebTemplateDbContextTest(IServiceCollection services)
        //{
        //    ConfigureInMemorySqlite(services);
        //}

        //private void ConfigureInMemorySqlite(IServiceCollection services)
        //{
        //    _sqliteConnection = CreateDatabaseAndGetConnection();

        //    services.AddDbContext<WebTemplateDbContext>(options =>
        //    {
        //        options.UseSqlite(_sqliteConnection);
                
        //    });
        //}

        //private static SqliteConnection CreateDatabaseAndGetConnection()
        //{
        //    var connection = new SqliteConnection("Data Source=:memory:");
        //    connection.Open();

        //    var options = new DbContextOptionsBuilder<WebTemplateDbContext>()
        //        .UseSqlite(connection)
        //        .Options;

        //    using (var context = new WebTemplateDbContext(options))
        //    {
        //        context.GetService<IRelationalDatabaseCreator>().CreateTables();
        //    }

        //    return connection;
        //}
    }
}
