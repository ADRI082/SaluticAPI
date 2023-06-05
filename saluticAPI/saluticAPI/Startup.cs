using BusinessLogic.ProcessBL;
using BusinessLogic.RecruiterBL;
using Data.Context;
using Data.Repository.ProcessRepository;
using Data.Repository.RecruiterRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace saluticAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<SaluticContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<SaluticContext, SaluticContext>();

            services.AddScoped<IRecruiterBL, RecruiterBL>();
            services.AddScoped<IProcessBL, ProcessBL>();


            services.AddScoped<IRecruiterRepository, RecruiterRepository>();
            services.AddScoped<IProcessRepository, ProcessRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            if (env.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            app.UseHttpsRedirection();

            app.UseAuthorization();
        }
    }
}
