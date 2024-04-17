
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.Extensions.Options;
using Talabat.core.Repositories;
using Talabat.Repository;
using Talabat.Repository.Data;

namespace Route.Talabat.APIs
{
    public class Program
    {
        public static  async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region Services Configuration
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreContext>(Options =>
              Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
             
            #endregion
            var app = builder.Build();
            #region Update-Database
            //StoreContext dbContext = new StoreContext();
            //await dbContext.Database.MigrateAsync();
            using var Scope=app.Services.CreateScope();
            //group of services life Time Scoped
            var Services=Scope.ServiceProvider;
            // Server itSelf
            var _dbContext=Services.GetRequiredService<StoreContext>();
            // Ask clr to create object from dbcontext explicity
            var LoggerFactory= Services.GetRequiredService<ILoggerFactory>();

            try
            {
                await _dbContext.Database.MigrateAsync();// Update-Database
                await StoreContextSeed.SeedAsync(_dbContext);
            }
            catch (Exception ex)
            {

                var logger=LoggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An Error Occured during Apply the Migration");
            }
            #endregion
            #region Configure the http request pipline
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            #endregion
            app.Run();
        }
    }
}
