using Lab.ProdutoReview.Api.Data;
using Lab.ProdutoReview.Api.Data.Repositories;
using Lab.ProdutoReview.Api.Profiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.ProdutoReview.Api
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
            var connectionString = Configuration.GetConnectionString("ProdutoReviewDb");
            //"Server=localhost\\SQLEXPRESS;Database=ProdutoDb;Trusted_Connection=true"
            //var connectionString = @"Server=(LocalDb)\MSSQLLocalDB;Database=ProdutoReview;Trusted_Connection=True";
            //connectionString = "Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=aspnet-MvcMovie;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\Movies.mdf"
            
            services.AddDbContext<ProdutoReviewDbContext>(x => x.UseSqlServer(connectionString));
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            
            services.AddAutoMapper(typeof(ProdutoProfile));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", 
                    new OpenApiInfo 
                        { 
                            Title = "Lab.ProdutoReview.Api", 
                            Version = "v1",
                            Contact = new OpenApiContact
                            {
                                Name = "Rodrigo Dias",
                                Email = "rodrigo00737@gmail.com"
                            }
                        });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lab.ProdutoReview.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
