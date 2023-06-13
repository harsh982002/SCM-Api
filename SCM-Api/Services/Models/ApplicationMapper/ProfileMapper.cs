using AutoMapper;
using Data.Entities;

namespace Services.Models.ApplicationMapper
{
    public class ProfileMapper : Profile
    {
        /// <summary>
        /// Maps the Model and ViewModels.
        /// </summary>
        public ProfileMapper()
        {
            CreateMap<CompanyModel, Company>().ReverseMap();
            CreateMap<DepartmentModel, Department>().ReverseMap();
            CreateMap<ItemUomModel, ItemUom>().ReverseMap();
            CreateMap<ItemAvailabilityModel, ItemAvailability>().ReverseMap();
            CreateMap<PurchaseCategoryModel, PurchaseCategory>().ReverseMap();
            CreateMap<ItemModel, Item>().ReverseMap();
            CreateMap<ItemUpdateModel, Item>().ReverseMap();
            CreateMap<ItemDepartmentMappingModel, ItemDepartmentMapping>().ReverseMap();
            CreateMap<ItemReasonCodeMappingModel, ItemReasoncodesMapping>().ReverseMap();
            CreateMap<StatusModel, Status>().ReverseMap();
        }
    }
}
