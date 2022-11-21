using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieAPI.Interfaces;
using MovieAPI.Persistance;

namespace APIMovieExample
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
            services.AddDbContext<MovieDatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(MovieDatabaseContext).Assembly.FullName)));
            services.AddControllers().AddNewtonsoftJson();

            //services.AddControllersWithViews().AddNewtonsoftJson();
            services.AddSwaggerGen();

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<IMovieGenreRepository, MovieGenreRepository>();
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
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
