using Demo_AuthServer.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Demo_AuthServer
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

            //services.AddIdentityServer()
            //    .AddDeveloperSigningCredential()
            //    .AddJwtBearerClientAuthentication()
            //    .AddInMemoryClients(InitConfig.GetClients())
            //    .AddInMemoryApiResources(InitConfig.GetApiResources())
            //    .AddInMemoryApiScopes(InitConfig.GetApiScopes())
            //    .AddInMemoryIdentityResources(InitConfig.IdentityResources);

            services.Configure<TokenManagement>(Configuration.GetSection("tokenManagement"));
            var token = Configuration.GetSection("tokenManagement").Get<TokenManagement>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           // app.UseIdentityServer();
            app.UseRouting();

           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {

                    //ÀΩ‘ø
                    //var token = Configuration.GetSection("tokenManagement").Get<TokenManagement>();

                    //var claims = new[]
                    //{
                    //    new Claim(ClaimTypes.Name,"xiaowu")
                    //};
                    //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token.Secret));
                    //var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    //var jwtToken = new JwtSecurityToken(token.Issuer, token.Audience, claims, expires: DateTime.Now.AddMinutes(token.AccessExpiration), signingCredentials: credentials);
                    //var result = new JwtSecurityTokenHandler().WriteToken(jwtToken);

                    //∑«∂‘≥∆º”√‹ https://www.bejson.com/enc/rsa/
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name,"xiaowu")
                    };
                    var rsa = RSA.Create();
                    byte[] publicKey = Convert.FromBase64String(@"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDk8isuf9uHmpz7h8fxU/g+xS47
PT837ep9JWtXXxKbMiUn415fcH7TF7MGppt3NIFzXJvMvCFl93HRc5rLcTgiavsQ
p8guo2Xfmi / CTFoCfXh0A7CNR + jJa0DBztNErkB7SCHlSN8K4TmoBmWxZ269bD1y
EKfw9r7ERv1JbWuUzwIDAQAB");

                    byte[] privateKey = Convert.FromBase64String(@"MIICdwIBADANBgkqhkiG9w0BAQEFAASCAmEwggJdAgEAAoGBAOTyKy5/24eanPuH
x / FT + D7FLjs9Pzft6n0la1dfEpsyJSfjXl9wftMXswamm3c0gXNcm8y8IWX3cdFz
mstxOCJq + xCnyC6jZd + aL8JMWgJ9eHQDsI1H6MlrQMHO00SuQHtIIeVI3wrhOagG
ZbFnbr1sPXIQp / D2vsRG / Ulta5TPAgMBAAECgYAA / 8WMeGZe2x / gQSFwPiuRKo8f
Fw9VkSY60ZT8Vp / gKYHcALQCupzzEuFnIAcBqCsAc + ECLbf / l + rZPSXpyV6zVaLR
8Hf6GHYgwSCgRugq7XQCiqx / cJEJv99R4553HJFD + qncEZKmAzXyBWrp1WlrU0O0
Sz4zPjkT86kwOye4IQJBAPv0nG4MAEmemB6VgdR2ePhZreI9hb0qTjhyDrAhWFb +
VQezTstosc190HZjsqE + 9vke50IVt57IqY7KWRn1 + ukCQQDonwB / oNKoWPz15C77
92CvPwCYdoIdHRRXcdKA1t0YQ3NLUUoE4Fdps5Qazr / TYwgTURA5iqDMCaPng5hM
V873AkEA2kI4EIyM4zljhXr2ENrgSCNHoiixZgDz6anEV4dLQ3Dmr9kAdOyoud43
a5dJ8qzcvUmsA29UtVQWrf9T2E1hoQJAAcc9ZLxg / +J2RJby + QAiIBTWN1QomHph
bm2zU0LRO99AIWJEs5bXdDpoNnBALSiDpkonWplBs22bcCikYGkHbwJBAO6cAAV7
vz691j8kX6Tj5TaDS1Fbe20lPrBCl1zNPuZiPyGGi0qDs0TbuxndR0IwyAKLKBdt
emceDNoSosNUc0c = ");

                    var tokenSetting = Configuration.GetSection("tokenManagement").Get<TokenManagement>();
                    rsa.ImportPkcs8PrivateKey(privateKey, out _);

                    var key = new RsaSecurityKey(rsa);
                    PrivateKeyStatus privateKeyStatus = key.PrivateKeyStatus;

                    //=====================================================================

                    var token = new JwtSecurityToken(
                        issuer: tokenSetting.Issuer,
                        audience: tokenSetting.Audience,
                        claims: claims,
                        notBefore: DateTime.Now,
                        expires: DateTime.Now.AddHours(2),
                        signingCredentials: new SigningCredentials(key, SecurityAlgorithms.RsaSha256)
                    //signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                    );


                    var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

                    await context.Response.WriteAsync(jwtToken);
                });
            });
        }
    }
}
