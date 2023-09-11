using System.ComponentModel.DataAnnotations;

namespace Inventory.API.Services.Models.ItemCategory
{
    public abstract class BaseItemCategoryDTO
    {
        [Required(ErrorMessage = "Name is Required")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        public required string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}