using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using New3C_Service;
using New3C_Servicelmpl;
using New3C_DataService;
using New3C_DataServicelmpl;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace New3C_API
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.RequireHttpsMetadata = false;
                  options.SaveToken = true;

                  options.TokenValidationParameters = new TokenValidationParameters()
                  {
                      ValidIssuer = Configuration["Jwt:Issuser"],
                      ValidAudience = Configuration["Jwt:Issuser"],
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                  };
              });

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder.AllowAnyOrigin()
            //          .AllowAnyMethod()
            //          .AllowAnyHeader()
            //          .AllowCredentials()
            //    .Build());
            //});

            services.AddCors(options =>
            {
                options.AddPolicy("AllownSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:63831").AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            });
            services.AddSingleton<StudentService, StudentServicelmpl>();
            services.AddSingleton<StudentDataServices, StudentDataServicelmpl>();
            services.AddSingleton<FeatureItemDataService, FeatureItemDataServicelmpl>();
            services.AddSingleton<FeatureItemService, FeatureItemServicelmpl>();
            services.AddSingleton<LoginService, LoginServicelmpl>();
            services.AddSingleton<LoginDataService, LoginDataServicelmpl>();
            services.AddSingleton<ItemDetailDataService, ItemDetailDataServicelmpl>();
            services.AddSingleton<ItemDetailService, ItemDetailServicelmpl>();
            services.AddSingleton<ShoppingCartDataService, ShoppingCartDataServicelmpl>();
            services.AddSingleton<ShoppingCartService, ShoppingCartServicelmpl>();
            services.AddSingleton<ItemCategoryDataService, ItemCategoryDataServicelmpl>();
            services.AddSingleton<ItemCategoryService, ItemCategoryServicelmpl>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //启用身份认证
            app.UseAuthentication();
            app.UseCors("AllownSpecificOrigin");
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Files")),
                RequestPath = new PathString("/src")
            });

            app.UseMvc();
        }
    }
}
