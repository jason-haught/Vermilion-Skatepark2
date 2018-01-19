using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VermillionSkate2.Models;

namespace VermillionSkate2
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
            services.AddMvc();

            //services.AddDbContext<PagesDataModel>(options => options.use)
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //["appConfig.ApplicationTitle"];
            //var applicationTitle = Configuration.GetSection("App").Get<AppSettings>().ApplicationTitle; 
            AppSettings.Instance.ApplicationTitle = Configuration["App:Title"];
            AppSettings.Instance.ApplicationFooter = Configuration["App:Footer"];
            AppSettings.Instance.ContactInfo = new Contact()
            {
                Title = Configuration["App:Contact:Title"],
                Message = Configuration["App:Contact:Message"]
            };

            AppSettings.Instance.HomeInfo = new Home()
            {
                Title = Configuration["App:Home:Title"],
                Message = Configuration["App:Home:Message"]
            };

            AppSettings.Instance.AboutInfo = new About()
            {
                Title = Configuration["App:About:Title"],
                Message = Configuration["App:About:Message"]
            };

            AppSettings.Instance.ConnectionStrings = new Dictionary<ConnectionStringNames, string>();

            AppSettings.Instance.ConnectionStrings
                .Add(ConnectionStringNames.PagesDataContextSQL, Configuration["ConnectionStrings:PagesDataContextSQL"]);

            AppSettings.Instance.ConnectionStrings
                .Add(ConnectionStringNames.PagesDataContextSQLLite, Configuration["ConnectionStrings:PagesDataContextSQLLite"]);

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
