using ABC.Core.Interfaces.Repositories;
using ABC.Core.Interfaces.Services;
using ABC.Infrastructure;
using ABC.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API
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
            services.AddControllers();
            services.AddSwaggerGen();
            
            services.AddTransient<IAmortizationScheduleRepository, AmortizationScheduleRepository>();
            services.AddTransient<IBuyerInfoRepository, BuyerInfoRepository>();
            services.AddTransient<IAmortizationScheduleService, AmortizationScheduleService>();
            services.AddTransient<IBuyerInfoService, BuyerInfoService>();

            services.Configure<ConnectionOptions>(Configuration.GetSection(ConnectionOptions.ConnectionStrings));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("v1/swagger.json", "ABC API V1");
                });
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
