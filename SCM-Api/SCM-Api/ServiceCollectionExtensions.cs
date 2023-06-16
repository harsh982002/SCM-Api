﻿namespace SCM_Api
{
    using Services.Contract;
    using Services.Implementation;

    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the dependency.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void RegisterDependency(this IServiceCollection services)
        {
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IItemUomService, ItemUomService>();
            services.AddScoped<IItemAvailabilityService, ItemAvailabilityService>();
            services.AddScoped<IPurchaseCategoryService, PurchaseCategoryService>();
            services.AddScoped<IReasonCodeService, ReasonCodeService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IItemDepartmentsService, ItemDepartmentsService>();
            services.AddScoped<IItemReasonCodesService, ItemReasonCodesService>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<IEvaluationMethodService, EvaluationMethodService>();
        }

    }
}
