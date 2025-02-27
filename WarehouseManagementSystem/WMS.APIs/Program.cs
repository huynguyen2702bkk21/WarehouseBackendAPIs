using WMS.Domain.InterfaceRepositories.IStorage;
using WMS.Infrastructure.Repositories.PartyRepositories;
using WMS.Infrastructure.Repositories.StogareRepositories;

namespace WMS.APIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Add the connection EmployeeType to the container
            var connectionString = builder.Configuration.GetConnectionString("PostgreSqlConnection");

            // Add the DbContext to the container with the connection EmployeeType
            builder.Services.AddDbContext<WMSDbContext>(options =>
                options.UseNpgsql(connectionString, b => b.MigrationsAssembly("WMS.APIs")));

            // Register the AutoMapper services with the assembly
            builder.Services.AddAutoMapper(typeof(ModelToViewModelProfile).Assembly);
            // Register the MediatR services with the assembly
            builder.Services.AddMediatR(config =>
                config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));


            // Register the repositories with scoped lifetime
            builder.Services.AddScoped<IPersonRepository, PersonRepository>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
            builder.Services.AddScoped<ILocationRepository, LocationRepository>();
            builder.Services.AddScoped<IWarehouseRepository, WarehouseRepository>();




            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
