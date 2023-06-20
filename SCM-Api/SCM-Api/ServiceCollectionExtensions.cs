namespace SCM_Api
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
            services.AddScoped<IBidSbdDocumentService, BidSbdDocumentService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IEvaluationMethodService, EvaluationMethodService>();
            services.AddScoped<IItemAvailabilityService, ItemAvailabilityService>();
            services.AddScoped<IItemDepartmentsService, ItemDepartmentsService>();
            services.AddScoped<IItemReasonCodesService, ItemReasonCodesService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IItemUomService, ItemUomService>();
            services.AddScoped<IPurchaseCategoryService, PurchaseCategoryService>();
            services.AddScoped<IReasonCodeService, ReasonCodeService>();
            services.AddScoped<ISbdDocumentService, SbdDocumentService>();
            services.AddScoped<IStatusService, StatusService>();
        }

    }
}
