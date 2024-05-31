﻿using Application.Activities;
using Application.Core;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config) 
        {

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAuthorization();
            services.AddDbContext<DataContext>(options => options.UseSqlServer(
                       config.GetConnectionString("DefaultConnection")));
            //builder.Services.AddDbContext<DataContext>(opt =>
            //{
            //    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
            //});
            //builder.Services.AddCors(opt=>
            //{
            //        opt.AddPolicy( "CorsPolicy", policy =>
            //        {
            //            policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
            //        });
            //});

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(List.Handler).Assembly));
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<Create>();
            return services;

        }


    }
}
