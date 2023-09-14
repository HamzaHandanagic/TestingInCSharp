
using CurrencyConverter.API.Database;
using CurrencyConverter.API.Services;
using CurrencyConverter.API.Repositories;

namespace CurrencyConverter.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var config = builder.Configuration;
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IDbConnectionFactory>(_ =>
            new NpgsqlConnectionFactory(config["Database:ConnectionString"]!));

            builder.Services.AddSingleton<DatabaseInitializer>();
            builder.Services.AddSingleton<IRatesRepository, RatesRepository>();
            builder.Services.AddSingleton<IQuoteService, QuoteService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            var databaseInitializer = app.Services.GetRequiredService<DatabaseInitializer>();
            await databaseInitializer.InitializeAsync();

            app.Run();
        }
    }
}