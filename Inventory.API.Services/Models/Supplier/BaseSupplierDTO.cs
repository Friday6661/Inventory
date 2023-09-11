namespace Inventory.API.Services.Models.Supplier
{
    public abstract class BaseSupplierDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

    }
}