using Basduvar.API.Filters;
using Basduvar.Core.Repositories;
using Basduvar.Core.Services;
using Basduvar.Core.UnitOfWorks;
using Basduvar.Data;
using Basduvar.Data.Repositories;
using Basduvar.Data.UnitOfWorks;
using Basduvar.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Basduvar.API
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
            services.AddAutoMapper(typeof(Startup));//Tüm objeler için map leme yapacak
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));//Generic
            services.AddScoped<NotFoundFilter>();
            services.AddScoped(typeof(IService<>),typeof(Service<>));////Generic
            services.AddScoped<ICategoryService,CategoryService>();//Not Generic
            services.AddScoped<IProductService, ProductService>();//Not Generic
            services.AddScoped<IUnitOfWork, UnitOfWork>();



            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString(),o=>
                {
                    o.MigrationsAssembly("Basduvar.Data");//Hangi projede
                });
            });


            services.AddControllers(o=>
            {
                o.Filters.Add(new ValidationFilter());//Tüm Controller larda ValidationFilter tanýmlamak istersek Startup ta bu þekilde tanýmlyabiliriz
            }
            );

            //Burdaki amaç; validationfilter hata mesajlarýný kendim vermek istiyorum demek için yazýldý
            services.Configure<ApiBehaviorOptions>(options=>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
