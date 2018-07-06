using Microsoft.AspNetCore.SignalR;
using Ozon.Hubs;
using Ozon.Models.TransferEntities;
using System.Threading.Tasks;

namespace Ozon.Extensions
{
    public static class OrdersHubExtensions
    {
        public static Task SendDiffAsync(this IHubContext<OrdersHub> hub, OrdersDiff diff)
        {
            return hub.Clients.All.SendAsync("recieveDiff", diff);
        }

        public static Task SendMessageAsync(this IHubContext<OrdersHub> hub, string message)
        {
            return hub.Clients.All.SendAsync("recieveMessage", message);
        }
    }
}
