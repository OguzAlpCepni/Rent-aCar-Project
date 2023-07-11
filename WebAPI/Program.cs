using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.concrete.EntityFramework;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();
            // bana arka planda bir referans oluþtur birisi  senden IproductServices isterse  ona bir productManager oluþtur ve onu ver 
            //builder.Services.AddSingleton<ICarService,CarManager>();
            // eðer bir baðýmlýlýk varsa ona bu referansý ver 
            //builder.Services.AddSingleton<ICarDal,EfCarDal>();
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new AutofacBusinessModule());
            });
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