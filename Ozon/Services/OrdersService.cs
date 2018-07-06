using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Ozon.Extensions;
using Ozon.Hubs;
using Ozon.Models.EventArgs;
using Ozon.Models.TransferEntities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Ozon.Services
{
    public class OrdersService : BackgroundService
    {
        private readonly System.Timers.Timer _timer = new System.Timers.Timer();
        private readonly IHubContext<OrdersHub> _ordersHub;
        private readonly IOrdersRandomizer _randomizer;
        private readonly IStorage _Storage;
        private readonly Random _radnom = new Random();

        public List<Order> Orders => _Storage.Orders;

        public event EventHandler<OrdersChangedEventArgs> OrdersChanged;

        public OrdersService(IHubContext<OrdersHub> ordersHub, IOrdersRandomizer randomizer, IStorage storage)
        {
            _ordersHub = ordersHub;
            _randomizer = randomizer;
            _Storage = storage;
            
        }

        #region BackgroundService implementation

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            RunTimer();
        }

        #endregion

        private void RunTimer()
        {
            _timer.Stop();
            _timer.Interval = 500;
            _timer.Elapsed += OnTimerElapsed;
            _timer.Start();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            OrdersDiff diff = new OrdersDiff();

            if (_radnom.Probability(5))
            {
                Order addedOrder = _randomizer.AddRandomOrder(Orders);
                diff.AddedOrders.Add(addedOrder);
            }

            if (_radnom.Probability(1))
            {
                Order deletedorder = _randomizer.DeleteRandomOrder(Orders);
                diff.DeletedOrdersIds.Add(deletedorder.Id);
            }

            if (Orders.Count > 50)
            {
                while (Orders.Count > 25)
                {
                    Order deletedOrder = _randomizer.DeleteRandomOrder(Orders);
                    diff.DeletedOrdersIds.Add(deletedOrder.Id);
                }   
            }

            Order updatedOrder = _randomizer.UpdateRandomOrder(Orders);
            diff.UpdatedOrders.Add(updatedOrder);

            OrdersChanged?.Invoke(this, new OrdersChangedEventArgs(diff));

            _ordersHub.SendDiffAsync(diff);
            _ordersHub.SendMessageAsync("Diff object was sent to you with love");
        }
    }
}
