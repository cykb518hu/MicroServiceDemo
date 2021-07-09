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

            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryClients(InitConfig.GetClients())
                //.AddInMemoryApiResources(InitConfig.GetApiResources())
                .AddInMemoryApiScopes(InitConfig.GetApiScopes())
                .AddInMemoryIdentityResources(InitConfig.GetIdentityResources()); // 针对ocelot 必须要加这一行 https://stackoverflow.com/questions/62645604/asp-net-core-3-0-identity-server-4-4-0-0-securitytokeninvalidaudienceexception

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();
            app.UseRouting();

           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("hello world!");

                    // JWT 生成token

                    //对称加密  要16 长度的秘钥
                    //var token = Configuration.GetSection("tokenManagement").Get<TokenManagement>();

                    //var claims = new[]
                    //{
                    //    new Claim(ClaimTypes.Name,"xiaowu")
                    //};
                    //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token.Secret));
                    //var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    //var jwtToken = new JwtSecurityToken(token.Issuer, token.Audience, claims, expires: DateTime.Now.AddMinutes(token.AccessExpiration), signingCredentials: credentials);
                    //var result = new JwtSecurityTokenHandler().WriteToken(jwtToken);

                    //非对称加密 https://www.bejson.com/enc/rsa/
                    //rsa 生成网址 https://travistidwell.com/jsencrypt/demo/  要用2048 的长度

                    //rsa 使用方法详解  https://vcsjones.dev/key-formats-dotnet-3/

                    //                    var claims = new[]
                    //                    {
                    //                        new Claim(ClaimTypes.Name,"xiaowu")
                    //                    };
                    //                    using var rsa = RSA.Create();
                    //                    byte[] publicKey = Convert.FromBase64String(@"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCG//jEl+ZxhDm+NNgkK3ID9KTDlC+wuMTR+ZR8byl2vHuAgWDzr+868gZuoKHzEMXmr9S1NQm8FmdJn+pMRXtcr6r0co1qpB+zSta08B4OK6SWaViLaULn3W7LeIJRvwXMXlHG3ye5HGMCiuc/cch1r6iQFiprZbWz/Kxo7jgwOQIDAQAB");

                    //                    byte[] privateKey = Convert.FromBase64String(@"MIIEowIBAAKCAQEAsGMsazCB50tjSoj8z4lf/InJTOxbSPwBaac8btxFKY5+Qg48
                    //oZTk4Q5jjKqDVfBrh2ywURm5E0/IytljasPIcJbAOAZZF4Wu2623BUzLlcRopZAa
                    //Hh/XzXcxfu4KkoD2nPNf15e58YgU+9GxVkEq/6quWU31YLxgXfbc/L9XPaK/iaRd
                    //y4cpHD+e3r0sC7mZxL2w6rTp6AV2KdqBbYbgv9+1DahRLw1XmZNvNP1sHuZNK9pi
                    //IwlD4rFmVbxexvzsXNfIKZIvLhJahUF04+ZeQEiIOEyA4hHwvj3d465UU8DbgNl6
                    //sVjceLD9u2C93mtcc26xuHkD2bnC8ZAxuUhWkQIDAQABAoIBAEEBe8hRSz7L2N8K
                    //V2nBLj/rI+YWoZnnTjn66VnOEis7maqMhqniLuwGmoen+9k7TtXNJ7nr6fqFB/JC
                    //ZdJeL0vXMyYyqLjzirrpba8lW05p4UtLLWT2xViy2en2nqzZnInBZAwXne63AUzB
                    //PkMUp10sMS82fP1Wz4kxxsXbWrKa4KSkbg1CNS8H3vjcbG2TdvsQS88JgrNvw1cQ
                    //DXVEI0zPfGPeDBLFmhGLd8wuNsf7ymlraCIL2B9i26ZXHmzkb5ZT5MweYW4fUMME
                    //WtcXCSIuLFigKOYhwuJ9Htgx/lssZX1LXTLmNeLnK/e9sf2+qVP4nwM/tKd9F4vs
                    //cSj2wpUCgYEA2N/UkA5MHCF1DAHlUTbblu8tjKOTgPc2yiYicTDFEix0iMc6Dixn
                    //pC6bAHSF2hLPeCLVGiuF52MNpfrgdf/m+C5efGaKeKcWH9e+ybZprKKEjaBnUOc1
                    //vRkC1bjKch7Gv8rR3wZVxaUOpNs6J9uEYHribPGojAVR5/I9Ad845OMCgYEA0DV8
                    //YaRtECreREtdyuP2I6olbmz0jqyLUSkxeHcpkOvkPotR+TCGCwSRHp2jaKUiU/fB
                    //sgb3g9nA3eHETAcKzGqOFFbKTn3nj+w8EdCLf5YT9D8iECXSaHKOZp+TzTVXCLs5
                    //jnADXfS+wQ4XPcegDeiQpXEXgRdc5UdAI7NwJPsCgYB4eJXGU/rZYYh4XBE7dQK0
                    //LDacOj101V69GkPlppbCSqmNVUYdm3MTE8SMky3Lfsl6zbac6/JdH3v0aJEJW1a9
                    //JFzeM8PV09MJazoTKN44xKpnVeQuX9FNMriNajIjBI+Y+JxujEFXIiIpV5JNk7ZM
                    //NdbTd8YNyeK+uqRDBvG+ywKBgAwPTQkK0RZipUUnaGNcGOGv9UMUJIYvEFK/JBJq
                    //NIokX7APucvJN7pjpVQ0pUZmajqa2ylIpgWJE1bGwOv2bHWyplAfRtCNEmCPulr9
                    //zVayhq1bCsoMpsdN+1mOXK1CLaxfy9GoQ0mp53KfMlFtwqOLmPU8O7RKeiL9oYVv
                    //20sJAoGBAM+BXiC+oERBCwepFqEmTOo//O/dqu/McHepPMX5k3HZDlLaId/ercWh
                    //tK3jHrh2u//F758pWGabAM6xhe1KnjjnzBkvtbLj7Pmi9c9j1rmgWIQTVW9/fqrF
                    //xTnypAjdwsNO2bq0adrPEN/1WUcJrSvS5hU38GIOzX9EPrNYpsz+");
                    //                    var tokenSetting = Configuration.GetSection("tokenManagement").Get<TokenManagement>();
                    //                    rsa.ImportRSAPrivateKey(privateKey, out _);

                    //                    var signingCredentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256)
                    //                    {
                    //                        CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false }
                    //                    }; 

                    //                    var now = DateTime.Now;
                    //                    var unixTimeSeconds = new DateTimeOffset(now).ToUnixTimeSeconds();

                    //                    var jwt = new JwtSecurityToken(
                    //                        audience: tokenSetting.Audience,
                    //                        issuer: tokenSetting.Issuer,
                    //                        claims: new Claim[] {
                    //                            new Claim(JwtRegisteredClaimNames.Iat, unixTimeSeconds.ToString(), ClaimValueTypes.Integer64),
                    //                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    //                            new Claim(ClaimTypes.Name, "xiaowu")
                    //                        },
                    //                        notBefore: now,
                    //                        expires: now.AddMinutes(30),
                    //                        signingCredentials: signingCredentials
                    //                    );

                    //                    var jwtToken = new JwtSecurityTokenHandler().WriteToken(jwt);


                });
            });
        }
    }
}
