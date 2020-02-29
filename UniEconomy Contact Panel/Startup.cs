using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UniEconomy_Contact_Panel
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
            services.AddRazorPages();
            services.AddServerSideBlazor();            
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
            
            //Dictionary<string, string> auth()
            //{
            //    Dictionary<string, string> tempAuth = new Dictionary<string, string>();
            //    tempAuth.Add("Authorization", "bearer eyJhbGciOiJSUzI1NiIsImtpZCI6ImVhMDNjMTI1MWMzYjE4ODE3ZDcyZjUzYjU0YmJlZTU3IiwidHlwIjoiSldUIn0.eyJuYmYiOjE1Nzk2MDk3NzcsImV4cCI6MTU3OTY5NjE3NywiaXNzIjoiaHR0cHM6Ly90ZXN0LWxvZ2luLnVuaWVjb25vbXkubm8iLCJhdWQiOlsiaHR0cHM6Ly90ZXN0LWxvZ2luLnVuaWVjb25vbXkubm8vcmVzb3VyY2VzIiwiQXBwRnJhbWV3b3JrIl0sImNsaWVudF9pZCI6IkFwcEZyYW1ld29ya0NsaWVudCIsInN1YiI6IjBjYTIzZDExLTE5MjMtNDZiYi05YzYwLTQ5NDA0YmUwYjQyOCIsImF1dGhfdGltZSI6MTU3OTYwOTc3NywiaWRwIjoibG9jYWwiLCJlbWFpbCI6ImFuZHJlYXNAZWtlbGFuZC5jb20iLCJzY29wZSI6WyJBcHBGcmFtZXdvcmsiXSwiYW1yIjpbInB3ZCJdfQ.Pq-NzLFEYvWACu9NeUdOumPMpZrjSSG29N7P0wHA-MNVw-1fqDhMgRf_dYZ9bnl5_7jx9xSGU6ST8DR4J3vaATILPmtTaUMuD2TMp3H_eJ3FhKirHQYIzPeyRobazNuSImisfc_Mk2JEhUaughYLNBoKR2yx1Ut5XTR9txyNpg7dVjhIm2ICdHv7Y192b_6BIU2s2rAHjVYpH5YNaHqR56iRMs2x_dKa-w3FjFLAEa64szK809EjJhtk_ZRSDOi69uW9fusjnPh132vRc-hhR4aLIertcbzk7do3iE9ehp5iQDPU1dan946LuGSiikY2csXIf6dWvuMM9xz16A1UVA");
            //    tempAuth.Add("CompanyKey", "5d17caae-87cb-417e-b0f9-98a021e2f345");
            //    return tempAuth;
            //}
            //Session.AccessTokens = auth();
        }
    }
}
