using Ozon.Models.TransferEntities;
using System.Collections.Generic;

namespace Ozon.Services
{
    public class Storage : IStorage
    {
        public List<Order> Orders { get; } = new List<Order>();
    }
}
