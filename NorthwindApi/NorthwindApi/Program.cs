
using AutoMapper;
using Northwind.Application.DTOs;
using Northwind.Application.Interfaces;
using Northwind.Application.Services;
using Northwind.Domain.Interfaces;
using Northwind.Infrastructure.Data;
using Northwind.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace NorthwindApi
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

            // AutoMapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryDto, Northwind.Domain.Entities.Category>().ReverseMap();
            });
            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            // Dependency Injection
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            // DB Context
            builder.Services.AddDbContext<NorthwindContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
