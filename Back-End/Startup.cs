//-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using Microsoft.EntityFrameworkCore;

using Back_End.Data;

//-------------------------------------------------------------------------------------------------

namespace Back_End
{
    //---------------------------------------------------------------------------------------------

    public class Startup
    {
        //-----------------------------------------------------------------------------------------

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //-----------------------------------------------------------------------------------------

        public void ConfigureServices(IServiceCollection services)
        {
            //-------------------------------------------------------------------------------------
            
            services.AddDbContext<DataContext>(options => {

                var connectionString = Configuration.GetConnectionString("Connection");

                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IRepository, Repository>();

            //-------------------------------------------------------------------------------------
            
            services.AddControllers();

            //-------------------------------------------------------------------------------------

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Back_End", Version = "v1" });
            });

            //-------------------------------------------------------------------------------------

            services.AddCors();

            //-------------------------------------------------------------------------------------
        }

        //-----------------------------------------------------------------------------------------
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //-------------------------------------------------------------------------------------

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Back_End v1"));
            }

            //-------------------------------------------------------------------------------------

            app.UseCors(cors => cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            //-------------------------------------------------------------------------------------
            
            app.UseRouting();

            //-------------------------------------------------------------------------------------
            
            app.UseAuthorization();

            //-------------------------------------------------------------------------------------
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        
            //-------------------------------------------------------------------------------------
        }
    
        //-----------------------------------------------------------------------------------------
    }

    //---------------------------------------------------------------------------------------------
}

//-------------------------------------------------------------------------------------------------