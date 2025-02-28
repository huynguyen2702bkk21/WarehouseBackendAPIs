namespace WMS.APIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Add the connection EmployeeType to the container
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Add the DbContext to the container with the connection EmployeeType
            builder.Services.AddDbContext<WMSDbContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("WMS.APIs")));

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

            builder.Services.AddScoped<IMaterialClassRepository, MaterialCLassRepository>();
            builder.Services.AddScoped<IMaterialClassPropertyRepository, MaterialClassPropertyRepository>();
            builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
            builder.Services.AddScoped<IMaterialPropertyRepository, MaterialPropertyRepository>();
            builder.Services.AddScoped<IMaterialLotRepository, MaterialLotRepository>();
            builder.Services.AddScoped<IMaterialLotPropertyRepository, MaterialLotPropertyRepository>();
            builder.Services.AddScoped<IMaterialSubLotRepository, MaterialSubLotRepository>();





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
