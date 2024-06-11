
using API_ASP.Net_authentication_.Container;
using API_ASP.Net_authentication_.Helper;
using API_ASP.Net_authentication_.Repos;
using API_ASP.Net_authentication_.Service;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace API_ASP.Net_authentication_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddTransient<ICustomerservice, CustomerService>();
            builder.Services.AddDbContext<APIContext>(o => o.UseSqlServer(builder.Configuration.
                GetConnectionString("DefaultConnection")));

            var automapper = new MapperConfiguration(item => item.AddProfile(new AutoMapperHandler()));

            IMapper mapper = automapper.CreateMapper();
            builder.Services.AddSingleton(mapper);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            string logpath = builder.Configuration.GetSection("Logging:Logpath").Value;
            var _logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("microsoft", Serilog.Events.LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.File(logpath)
                .CreateLogger();    
            builder.Logging.AddSerilog(_logger);

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
