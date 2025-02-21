namespace WMS.APIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Đọc chuỗi kết nối từ appsettings.json
            var connectionString = builder.Configuration.GetConnectionString("PostgreSqlConnection");

            // Cấu hình DbContext sử dụng PostgreSQL
            builder.Services.AddDbContext<WMSDbContext>(options =>
                options.UseNpgsql(connectionString, b => b.MigrationsAssembly("WMS.APIs")));

            builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));


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
