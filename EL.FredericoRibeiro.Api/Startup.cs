using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using EL.FredericoRibeiro.Api.Filters;
using EL.FredericoRibeiro.Api.Logging;
using EL.FredericoRibeiro.CrossCutting.Assemblies;
using EL.FredericoRibeiro.CrossCutting.IoC;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using EL.FredericoRibeiro.Application;
using EL.FredericoRibeiro.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace EL.FredericoRibeiro.Api
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddControllers();

            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(a =>
            {
                a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(b => 
            {
                b.RequireHttpsMetadata = false;
                b.SaveToken = true;
                b.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddMvc(options => options.Filters.Add(new DefaultExceptionFilterAttribute()));

            services.AddLoggingSerilog();

            services.AddAutoMapper(AssemblyUtil.GetCurrentAssemblies());

            services.AddDependencyResolver();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddHealthChecks();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "EL.FredericoRibeiro",
                    Description = "API - EL.FredericoRibeiro",
                    Version = "v1"
                });

                var apiPath = Path.Combine(AppContext.BaseDirectory, "EL.FredericoRibeiro.Api.xml");
                var applicationPath = Path.Combine(AppContext.BaseDirectory, "EL.FredericoRibeiro.Application.xml");

                c.IncludeXmlComments(apiPath);
                c.IncludeXmlComments(applicationPath);
                c.AddSecurityDefinition(
                    "Bearer",
                    new OpenApiSecurityScheme()
                    {
                        In = ParameterLocation.Header,
                        Description = "Digite: 'Bearer {token}', onde token é o token gerado na rota usuarios/login",
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey
                    });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });

            services.AddDbContext<DataContext>(options =>
                options.UseInMemoryDatabase("InMemoryDatabase"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UsePathBase("/EL.FredericoRibeiro");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/EL.FredericoRibeiro/swagger/v1/swagger.json", "API EL.FredericoRibeiro");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
