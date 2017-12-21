using Library;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace EFTestSqlite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            

            services.AddMvc();
            services.AddDbContext<ValueDbContext>(options =>
            {
                options.UseSqlite(
                    "Data source=test.db", 
                    opts => opts.MigrationsAssembly("EFTestSqlite"));
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("api-v1", new Info { Title = "Example API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/api-v1/swagger.json", "Example API v1");
            });
            app.UseMvc();
        }
    }
}
