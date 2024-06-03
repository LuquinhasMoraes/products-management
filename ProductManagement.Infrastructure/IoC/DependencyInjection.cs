using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Application.Interfaces;
using ProductManagement.Application.Mapping;
using ProductManagement.Application.Services;
using ProductManagement.Domain.Repositories;
using ProductManagement.Infrastructure.Repositories;

namespace ProductManagement.Infrastructure.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var conn = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ProductManagementDbContext>(options =>
               options.UseSqlServer(conn,
               b => b.MigrationsAssembly(typeof(ProductManagementDbContext).Assembly.FullName)));

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<FornecedorService>();
            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddAutoMapper(typeof(MapperProfile));

            return services;
        }
    }
}
