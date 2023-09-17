using AutoMapper;
using Inventory.API.Data;
using Inventory.API.Services.Models.Item;
using Inventory.API.Services.Models.ItemCategory;
using Inventory.API.Services.Models.Supplier;
using Inventory.API.Services.Models.Users;
using Inventory.API.Services.Models.Warehouse;

namespace Inventory.API.Services.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            // ItemCategory
            CreateMap<ItemCategory, GetItemCategoryDTO>().ReverseMap();
            CreateMap<ItemCategory, ItemCategoryDTO>().ReverseMap();
            CreateMap<ItemCategory, UpdateItemCategoryDTO>().ReverseMap();
            CreateMap<ItemCategory, CreateItemCategoryDTO>().ReverseMap();

            // Item
            CreateMap<Item, ItemDTO>().ReverseMap();
            CreateMap<Item, CreateItemDTO>().ReverseMap();
            CreateMap<Item, GetItemDTO>().ReverseMap();
            CreateMap<Item, UpdateItemDTO>().ReverseMap();

            // Supplier
            CreateMap<Supplier, CreateSupplierDTO>().ReverseMap();
            CreateMap<Supplier, GetSupplierDTO>().ReverseMap();
            CreateMap<Supplier, SupplierDTO>().ReverseMap();
            CreateMap<Supplier, UpdateSupplierDTO>().ReverseMap();

            // Warehouse
            CreateMap<Warehouse, CreateWarehouseDTO>().ReverseMap();
            CreateMap<Warehouse, GetWarehouseDTO>().ReverseMap();
            CreateMap<Warehouse, UpdateWarehouseDTO>().ReverseMap();
            CreateMap<Warehouse, WarehouseDTO>().ReverseMap();

            // Users
            CreateMap<ApiUserDTO, ApiUser>().ReverseMap();
        }
    }
}