using AutoMapper;
using Data.Entities;
using Data.StoreProcedureModel;

namespace Services.Models.ApplicationMapper
{
    public class ProfileMapper : Profile
    {
        /// <summary>
        /// Maps the Model and ViewModels.
        /// </summary>
        public ProfileMapper()
        {
            CreateMap<ItemModel, Item>().ReverseMap();
            CreateMap<ItemDepartmentsModel, ItemDepartment>().ReverseMap();
            CreateMap<ItemReasonCodesModel, ItemReasoncode>().ReverseMap();
            CreateMap<GetItemCsvModel, SP_ItemListModel>().ReverseMap();
        }
    }
}
