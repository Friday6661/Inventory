using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.Services.Models.Item
{
    public class GetItemDTO : BaseItemDTO
    {
        public int Id { get; set; }
    }
}