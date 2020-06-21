using System;
using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MusicApp.Application.Albums;
using MusicApp.Application.Artists;
using MusicApp.Application.Infrastructure;
using MusicApp.Application.Songs;
using MusicApp.Infrastructure;

namespace musicApp
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
            services.AddAutoMapper(c => c.AddProfile<AutofacProfile>(), typeof(Startup));

            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "API" }); });

            services.AddDbContext<MusicAppContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MusicAppDatabase")));
            //options.UseSqlite("Data Source=musicapp.db"));

            services.AddScoped<IContext>(s => s.GetService<MusicAppContext>());

        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<MusicAppContext>()
                .As<IContext>()
                .InstancePerLifetimeScope();
            builder.RegisterType<SongService>()
                .As<ISongService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ArtistService>()
                .As<IArtistService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<AlbumService>()
                .As<IAlbumService>()
                .InstancePerLifetimeScope();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<MusicAppContext>();
                context.Database.Migrate();
            }
        }
    }

}