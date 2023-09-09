using AutoMapper;
using Inventory.API.Data;
using Inventory.API.Services.Models.Item;
using Inventory.API.Services.Models.ItemCategory;
using Inventory.API.Services.Models.ItemCategoryDTO;

namespace Inventory.API.Services.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<ItemCategory, GetItemCategoryDTO>().ReverseMap();
            CreateMap<ItemCategory, ItemCategoryDTO>().ReverseMap();
            CreateMap<ItemCategory, UpdateItemCategoryDTO>().ReverseMap();
            CreateMap<ItemCategory, CreateItemCategoryDTO>().ReverseMap();

            CreateMap<Item, ItemDTO>().ReverseMap();
        }
    }
}