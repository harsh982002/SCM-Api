using Data.Context;
using Microsoft.EntityFrameworkCore;
using Services.Contract;
using Services.Implementation;

namespace SCM_Api
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterDependency(this IServiceCollection services)
        {
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IItemUomService, ItemUomService>();
            services.AddScoped<IItemAvailabilityService, ItemAvailabilityService>();
            services.AddScoped<IPurchaseCategoryService, PurchaseCategoryService>();
            services.AddScoped<IReasonCodeService, ReasonCodeService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IDepartmentMappingService, DepartmentMappingService>();
            services.AddScoped<IReasonCodeMappingService, ReasonCodeMappingService>();
            services.AddScoped<IStatusService, StatusService>();
        }

    }
}
