using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using Messenger.Services;
using Microsoft.Framework.ConfigurationModel;

namespace Messenger
{
    public class Startup
    {
        public Startup()
        {
            Configuration = new Configuration()
                .AddJsonFile("config.json")
                .AddEnvironmentVariables(); 
                 
                
        } 

        public IConfiguration Configuration { get; set; }

        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
         {
            services.AddMvc();
            services.AddTransient<IGreetingService>( 
                p => new GreetingService(Configuration));
         } 

        public void Configure(IApplicationBuilder app)
         {
            app.UseMvc();
            //app.UseMvc(route => route.MapRoute("default", 
            //  "{controller=Home}/{action=Default}")); 
            
            /* app.Run(async (context) =>
             {
                 await context.Response.WriteAsync("Hello World!");
             });  
             */
            //app.UseWelcomePage();    

     }         
    }
}
