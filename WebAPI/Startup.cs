using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Core.Utilities.Security.Jwt;
using Core.Utilities.Security.Encyption;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.DependencyResolver;


namespace WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        // Constructor
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Servisleri eklediğimiz yer
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowOrigin",
                    configurePolicy: builder => builder.WithOrigins("http://localhost:3000"));
            });

            var tokenOptions = Configuration.GetSection(key: "TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });

            // Core katmanındaki bağımlılıkları ekler  
            services.AddDependecyResolvers(new ICoreModule[]
            {
                new CoreModule() 
            });
            
        }


        // HTTP pipeline’ı yapılandırdığımız yer
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Geliştirme ortamı için hata detayları
            }

            app.ConfigureCustomExceptionMiddleware(); // Özel hata middleware'i
            app.UseCors(builder => builder.WithOrigins("https://localhost:3000").AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();// bu da eve girmekse

            app.UseAuthorization(); //bu mutfaga girmektir. Eve girmeden mutfaga giremezsin.Önce authentication yazılmalıdır.

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // API endpoint'lerini eşle
            });
        }
    }
}
