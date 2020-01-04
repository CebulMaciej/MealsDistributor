using Data.DatabaseInfrastructure.ProvidingSqlConnection.Concrete;
using Data.Infrastructure.ProvidingSqlConnection.Abstract;
using Data.Infrastructure.StoredProceduresExecution.Abstract;
using Data.Infrastructure.StoredProceduresExecution.Concrete;
using Domain.Creators.Meals.Abstract;
using Domain.Creators.Meals.Concrete;
using Domain.Creators.Restaurants.Abstract;
using Domain.Creators.Restaurants.Concrete;
using Domain.Creators.Users.Abstract;
using Domain.Creators.Users.Concrete;
using Domain.Infrastructure.DataRowToObjectMapping.Abstract;
using Domain.Infrastructure.DataRowToObjectMapping.Concrete;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Infrastructure.Logging.Concrete;
using Domain.Providers.Meals.Abstract;
using Domain.Providers.Meals.Concrete;
using Domain.Providers.Orders.Abstract;
using Domain.Providers.Orders.Concrete;
using Domain.Providers.OrdersPositions.Abstract;
using Domain.Providers.OrdersPositions.Concrete;
using Domain.Providers.Restaurants.Abstract;
using Domain.Providers.Restaurants.Concrete;
using Domain.Providers.Users.Abstract;
using Domain.Providers.Users.Concrete;
using Domain.Remover.Meals.Abstract;
using Domain.Remover.Meals.Concrete;
using Domain.Remover.Restaurants.Abstract;
using Domain.Remover.Restaurants.Concrete;
using Domain.Repositories.Abstract;
using Domain.Repositories.Concrete;
using Domain.Updater.Configurations.Abstract;
using Domain.Updater.Configurations.Concrete;
using Domain.Updater.Meals.Abstract;
using Domain.Updater.Meals.Concrete;
using Domain.Updater.Restaurants.Abstract;
using Domain.Updater.Restaurants.Concrete;
using Domain.Updater.Users.Abstract;
using Domain.Updater.Users.Concrete;
using MealsDistributor.Infrastructure.IdFromClaimsExpanding.Abstract;
using MealsDistributor.Infrastructure.IdFromClaimsExpanding.Concrete;
using MealsDistributor.Infrastructure.ObjectsToModelConverting.Abstract;
using MealsDistributor.Infrastructure.ObjectsToModelConverting.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MealsDistributor
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

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                
            });

            services.AddTransient<ILogger, Logger>();
            services.AddTransient<ISqlConnectionProvider, SqlConnectionProvider>();
            services.AddTransient<IStoredProceduresExecutor, StoredProceduresExecutor>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserProvider, UserProvider>();
            services.AddTransient<IUserCreator, UserCreator>();
            services.AddTransient<IUserUpdater, UserUpdater>();
            services.AddTransient<IObjectToApiModelConverter, ObjectToApiModelConverter>();
            services.AddTransient<IConfigurationRepository, ConfigurationRepository>();
            services.AddTransient<Domain.Providers.Configuration.Abstract.IConfigurationProvider, Domain.Providers.Configuration.Concrete.ConfigurationProvider>();
            services.AddTransient<IConfigurationUpdater, ConfigurationUpdater>();
            services.AddTransient<IDataRowToObjectMapper, DataRowToObjectMapper>();
            services.AddTransient<IMealRepository, MealRepository>();
            services.AddTransient<IMealProvider, MealProvider>();
            services.AddTransient<IMealCreator, MealCreator>();
            services.AddTransient<IMealUpdater, MealUpdater>();
            services.AddTransient<IMealsRemover, MealsRemover>();


            services.AddTransient<IUserIdFromClaimsExpander, UserIdFromClaimsExpander>();



            services.AddTransient<IRestaurantRepository, RestaurantRepository>();
            services.AddTransient<IRestaurantProvider, RestaurantProvider>();
            services.AddTransient<IRestaurantCreator, RestaurantCreator>();
            services.AddTransient<IRestaurantUpdater, RestaurantUpdater>();
            services.AddTransient<IRestaurantRemover, RestaurantRemover>();


            services.AddTransient<IOrderProvider, OrderProvider>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddTransient<IOrderPositionsProvider, OrderPositionsProvider>();
            services.AddTransient<IOrderPositionsRepository, OrderPositionsRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "My API", Version = "v2" });
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

            app.UseAuthentication();
            app.UseAuthorization();

            
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
