using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.Services.Models
{
    public class QueryParameters
    {
        private int _pagesize = 15;
        public int StartIndex { get; set; }
        public int PageNumber { get; set; }
        public int PageSize
        {
            get { return _pagesize; }
            set { _pagesize = value; }
        }
    }
}