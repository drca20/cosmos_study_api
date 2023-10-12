using Cosmos_Study.Application.Interfaces;
using Cosmos_Study.Application.Interfaces.Repositories;
using Cosmos_Study.Infrastructure.Persistence.Contexts;
using Cosmos_Study.Infrastructure.Persistence.Repositories;
using Cosmos_Study.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmos_Study.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
               options.UseMySql(
                   configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 11)),
                   b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }
            #region Repositories
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IProductRepositoryAsync, ProductRepositoryAsync>();
            services.AddTransient<IStudyRepositoryAsync, StudyRepositoryAsync>();
            services.AddTransient<IStudyImageRepositoryAsync, StudyImageRepositoryAsync>();
            services.AddTransient<IStudyContactsRepositoryAsync, StudyContactsRepositoryAsync>();
            services.AddTransient<ISiteRepositoryAsync, SiteRepositoryAsync>();
            #endregion
        }
    }
}
