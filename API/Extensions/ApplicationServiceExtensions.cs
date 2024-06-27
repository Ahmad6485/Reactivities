using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Activities;
using Application.Core;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection Services, IConfiguration config)
        {
            Services.AddEndpointsApiExplorer();
            Services.AddSwaggerGen();
            Services.AddDbContext<DataContext>(option =>
            {
                option.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            Services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
                });
            });
            Services.AddMediatR(cft => cft.RegisterServicesFromAssemblies(typeof(List.Handler).Assembly));
            Services.AddAutoMapper(typeof(MappingProfile).Assembly);
            return Services;

        }
    }
}