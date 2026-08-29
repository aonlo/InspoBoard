using InspoBoard.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace InspoBoard.Api.Data
{
    public static class DataExtensions
    {
        public static void MigrateDb(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<InspoBoardContext>();
            dbContext.Database.Migrate();
        }

        public static void AddInspoBoardDb(this WebApplicationBuilder builder)
        {
            var connString = builder.Configuration.GetConnectionString("InspoBoard");
            builder.Services.AddSqlite<InspoBoardContext>(
                connectionString: connString,
                optionsAction: options => options.UseSeeding((context, _) =>
                {
                    //// If no items in db => add these
                    //if (!context.Set<Item>().Any())
                    //{
                    //    var item = new Item {  };
                    //    context.Set<Item>().Add(item);
                    //    context.SaveChanges();
                    //}
                })
            );
        }
    }
}