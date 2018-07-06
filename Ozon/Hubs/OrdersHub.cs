using Microsoft.AspNetCore.SignalR;
using Ozon.Models.TransferEntities;
using Ozon.Services;
using System.Threading.Tasks;

namespace Ozon.Hubs
{
    public class OrdersHub : Hub
    {
        private readonly IStorage _Storage;

        public OrdersHub(IStorage storage)
        {
            _Storage = storage;
        }

        public override Task OnConnectedAsync()
        {
            Clients.All.SendAsync("recieveDiff", new OrdersDiff() { AddedOrders = _Storage.Orders });
            Clients.All.SendAsync("recieveMessage", "One new client is connected");
            return base.OnConnectedAsync();
        }
    }
}
