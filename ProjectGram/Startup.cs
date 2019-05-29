using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectGram.Infraestructure;
using ProjectGram.Models;
using ProjectGram.Models.Data;
using ProjectGram.Services.Interfaces;
using ProjectGram.Services.Repositories;

namespace ProjectGram
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
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            services.AddSignalR();
            services.AddSession();

            services.AddDbContext<GramDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IFotoRepository, FotoRepositories>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ILikeRepository, LikeRepository>();
            services.AddTransient<IArchiveRepository, ArchiveRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICommentLikeRepository, CommentLikeRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<GramDbContext>()
                .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseFileServer();
            app.UseSignalR(routes =>
            {
                routes.MapHub<SignalRServer>("/Infraestructure/SignalRServer");
            });

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
