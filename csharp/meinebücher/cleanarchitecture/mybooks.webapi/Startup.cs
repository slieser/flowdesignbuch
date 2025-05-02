using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using mybooks.contracts;
using mybooks.dbprovider;
using mybooks.integration;
using mybooks.logic;

namespace mybooks.webapi
{
    public class Startup()
    {
        public void ConfigureServices(IServiceCollection services) {
            services.AddTransient<Booklending>();
            services.AddSingleton<IBooksRepository>(_ => new BooksRepository("MyBooks"));
            services.AddSingleton<Interactors>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}