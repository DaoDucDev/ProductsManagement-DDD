using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Application.Commands.ProductCommands;
using Application.Queries.ProductQueries;
using Domain.AggregateModels.ProductAggregate;
using Domain.SeedWork;
using Infrastructure;
using Infrastructure.Database;
using Infrastructure.Domain.Products;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Npgsql;
using Shared.UnitOfWorkInterceptor.Extensions;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var sqlConnectionString = Configuration["DefaultConnection"];
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            services.AddDbContext<ProductContext>(options => options.UseNpgsql(sqlConnectionString))
            .AddScoped<IDbConnection>(sp =>
             {
                 var config = sp.GetRequiredService<IConfiguration>();
                 var sqlConnectionString = Configuration["DefaultConnection"];
                 var connection = new NpgsqlConnection(sqlConnectionString);
                 connection.Open();
                 return connection;
             });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Products Managerment API", Version = "v1" });
            });

            

            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));

            services.AddMediatR(typeof(CreateProductCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetAllProductsQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetProductByNameQuery).GetTypeInfo().Assembly);

            services.AddUnitOfWorkInterceptors(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API cua thay Duc dep trai v1");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
