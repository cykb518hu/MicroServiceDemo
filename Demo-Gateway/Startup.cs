using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_Gateway
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

         
            
            var key = "UserGatewayKey";
            services.AddAuthentication()
                .AddJwtBearer(key, options =>
                {
                    options.Authority = "http://localhost:5002";

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,

                    };
                    options.RequireHttpsMetadata = false;
                });

            services.AddOcelot()
                .AddConsul();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseOcelot();

            //app.UseAuthentication();
           // app.UseAuthorization();

        }
    }
}
