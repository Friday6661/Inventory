using System.ComponentModel.DataAnnotations;

namespace Inventory.API.Services.Models.ItemCategory
{
    public abstract class BaseItemCategoryDTO
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}