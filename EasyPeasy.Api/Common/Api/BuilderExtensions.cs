using EasyPeasy.Api.Data;
using EasyPeasy.Api.Services.Interfaces;
using EasyPeasy.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace EasyPeasy.Api.Common.Api;

public static class BuilderExtensions
{
    public static void AddConfigurations(this WebApplicationBuilder builder)
    {
        Configuration.ConnectionString = 
            builder.
            Configuration.
            GetConnectionString("SqlConnection") ?? string.Empty;
    }

    public static void AddDataContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(
        options => options.UseNpgsql(Configuration.ConnectionString)
        );
    }

    public static void AddAutoMapper(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }

    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<IFinancialMovementService, FinancialMovementService>();
    }

    public static void AddDocumentation(this WebApplicationBuilder builder)
    {

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(x => { x.CustomSchemaIds(n => n.FullName); });
    }
}
