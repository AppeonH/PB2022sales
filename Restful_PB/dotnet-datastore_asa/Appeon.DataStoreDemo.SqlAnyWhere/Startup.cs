using SnapObjects.Data;
using SnapObjects.Data.AspNetCore;
using SnapObjects.Data.Odbc;
using Appeon.DataStoreDemo.SqlAnywhere.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO.Compression;
using Microsoft.Extensions.Hosting;
using DWNet.Data.AspNetCore;

namespace Appeon.DataStoreDemo.SqlAnywhere
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            /*
            services.AddMvc(m =>
            {
                m.UseCoreIntegrated();
                m.UsePowerBuilderIntegrated();
            });
            */
            services.AddControllers(m =>
            {
                m.UseCoreIntegrated();
                m.UsePowerBuilderIntegrated();
            });
            
            //Note: Change "OrderContext" if you have changed the default DataContext file name; change the "PBDemoDB" if you have changed the database connection name in appsettings.json
            IServiceCollection serviceCollection = services.AddDataContext<OrderContext>(m => m.UseSqlAnywhere(Configuration["ConnectionStrings:PBDemoDB"]));
            
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISalesOrderService, SalesOrderService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IOrderReportService, OrderReportService>();
            
            services.AddGzipCompression(CompressionLevel.Fastest);
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseHsts();
            }
            //app.UseHttpsRedirection();
            
            app.UseResponseCompression();
            
            //app.UseMvc();
            
            app.UseDataWindow();
            
            app.UseRouting();
            
            app.UseAuthentication();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

