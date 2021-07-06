using Demo_SendEmailService.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Demo_SendEmailService
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
            services.AddControllers();
            services.Configure<TokenManagement>(Configuration.GetSection("tokenManagement"));
            var token = Configuration.GetSection("tokenManagement").Get<TokenManagement>();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                // 对称加密
                //x.RequireHttpsMetadata = false;
                //x.SaveToken = true;
                //x.TokenValidationParameters = new TokenValidationParameters
                //{
                //    ValidateIssuerSigningKey = true,
                //    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token.Secret)),
                //    ValidIssuer = token.Issuer,
                //    ValidAudience = token.Audience,
                //    ValidateIssuer = false,
                //    ValidateAudience = false
                //};

                //非对称加密

                byte[] publicKey = Convert.FromBase64String(@"MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAsGMsazCB50tjSoj8z4lf
/InJTOxbSPwBaac8btxFKY5+Qg48oZTk4Q5jjKqDVfBrh2ywURm5E0/IytljasPI
cJbAOAZZF4Wu2623BUzLlcRopZAaHh/XzXcxfu4KkoD2nPNf15e58YgU+9GxVkEq
/6quWU31YLxgXfbc/L9XPaK/iaRdy4cpHD+e3r0sC7mZxL2w6rTp6AV2KdqBbYbg
v9+1DahRLw1XmZNvNP1sHuZNK9piIwlD4rFmVbxexvzsXNfIKZIvLhJahUF04+Ze
QEiIOEyA4hHwvj3d465UU8DbgNl6sVjceLD9u2C93mtcc26xuHkD2bnC8ZAxuUhW
kQIDAQAB");
                using RSA rsa = RSA.Create();
                rsa.ImportSubjectPublicKeyInfo(publicKey, out _);
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = token.Issuer,
                    ValidAudience = token.Audience,
                    ValidateIssuer = false,
                    ValidateAudience = false,

                    //rsa.ExportParameters(false)  最开始没有加这个exportParameters 这个方法，就不行。
                    IssuerSigningKey = new RsaSecurityKey(rsa.ExportParameters(false)),
                    CryptoProviderFactory = new CryptoProviderFactory()
                    {
                        CacheSignatureProviders = false
                    }
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            this.Configuration.ConsulRegist();
        }
    }
}
