using Ozon.Models.TransferEntities;
using System.Collections.Generic;

namespace Ozon.Services
{
    public interface IStorage
    {
        List<Order> Orders { get; }
    }
}
