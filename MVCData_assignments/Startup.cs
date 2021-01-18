using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCData_assignments.Models;
using MVCData_assignments.Models.Data;
using MVCData_assignments.Models.Database;
using MVCData_assignments.Models.Services;

namespace MVCData_assignments
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {            
            //services.AddScoped<IPersonRepo, InMemoryPersonRepo>(); 
            services.AddDbContext<PersonDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))); 
            services.AddScoped<IPersonRepo, DatabasePersonRepo>();
            services.AddScoped<IPersonService, PersonService > ();
            services.AddScoped<ICountryRepo, DatabaseCountryRepo>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddMvc(); //add MVC so we can use it


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();   //default opens up the wwwroot folder to be accessed
            //app.UseSession();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "Person",              //name to route rule
                    pattern: "person", //url to match
                    defaults: new { controller = "Person", action = "Index" }  //what controller & action to call
                );
                // custom/special routes should be added before default
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
