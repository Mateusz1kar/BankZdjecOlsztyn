using BankZdjecOlsztyn.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;

namespace BankZdjecOlsztyn
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));//��czenie z baz�
            services.AddTransient<IMiejscaRepozytory, MiejscaRepozytory>();

            services.AddTransient<IMiejscaRepozytory, MiejscaRepozytory>();
            services.AddTransient<IZdjecieRepozytory, ZdjenciaRepozytory>();
            services.AddTransient<ITagRepozytory, TagRepozytory>();
            services.AddTransient<IMiejsceTagRepozytory, MiejsceTagRepozytory>();

            services.AddTransient<ITrasaRepozytory, TrasaRepozytory>();
            services.AddTransient<ITrasaMiejsceRepozytory, TrasaMiejsceRepozytory>();
            services.AddTransient<ITrasaTagRepozytory, TrasaTagRepozytory>();
            //services.AddMvc();
            services.AddControllersWithViews();
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

            //autoryzacja urzytkownika


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
           
            app.UseAuthentication(); //autoryzacia urzytkownika

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //z 2.1
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            //

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
