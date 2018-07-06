using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozon.Models.TransferEntities
{
    public class OrdersDiff
    {
        public List<int> DeletedOrdersIds { get; set; } = new List<int>();

        public List<Order> AddedOrders { get; set; } = new List<Order>();

        public List<Order> UpdatedOrders { get; set; } = new List<Order>();
    }
}
