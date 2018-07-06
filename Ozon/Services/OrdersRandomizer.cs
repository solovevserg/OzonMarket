using Ozon.Extensions;
using Ozon.Models.TransferEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ozon.Services
{
    public class OrdersRandomizer : IOrdersRandomizer
    {
        private readonly Random _radnom = new Random();

        public Order DeleteRandomOrder(List<Order> orders)
        {
            if (orders.Count == 0)
                return null;

            Order orderToBeDeleted = orders[_radnom.Next(orders.Count)];
            orders.Remove(orderToBeDeleted);
            return orderToBeDeleted;
        }

        public Order GetRandomOrder()
        {
            return new Order()
            {
                Id = _radnom.Next(),
                Client = GetRandomClient(),
                State = OrderStates.Waiting,
                Time = DateTime.Now,
                Goods = GetRandomGoods(1 + _radnom.Next(4))
            };
        }

        private Good GetRandomGood()
        {
            return new Good { Id = _radnom.Next(), Name = _radnom.NextGoodName(), Price = _radnom.NextPrice() };
        }

        private List<Good> GetRandomGoods(int count)
        {
            List<Good> goods = new List<Good>();
            for (int i = 0; i < count; i++)
            {
                goods.Add(GetRandomGood());
            }
            return goods;
        }

        private Client GetRandomClient()
        {
            string name = _radnom.NextName();
            return new Client()
            {
                Id = _radnom.Next(),
                Name = name,
                Email = _radnom.NextEmail(name),
                Phone = _radnom.NextPhone()
            };
        }

        public List<Order> GetRandomOrders(int count)
        {
            return new object[count].Select(fake => GetRandomOrder()).ToList();
        }

        // TODO: swap conditions in if-brackets.
        public Order UpdateOrderRandomly(Order order)
        {
            if (_radnom.Probability(5))
                order.Client = GetRandomClient();

            if (_radnom.Probability(20) && order.State != OrderStates.Recieved)
                order.State = order.State.NextOrRecieved();

            if (_radnom.Probability(10) && order.State <= OrderStates.Assembling)
                order.Goods.Add(GetRandomGood());

            if (_radnom.Probability(5) && order.Goods.Count > 1)
                DeleteRandomGood(order.Goods);

            return order;
        }

        private Good DeleteRandomGood(List<Good> goods)
        {
            if (goods.Count == 0)
                return null;

            Good goodToBeDeleted = goods[_radnom.Next(goods.Count)];
            goods.Remove(goodToBeDeleted);
            return goodToBeDeleted;
        }

        public Order AddRandomOrder(List<Order> orders)
        {
            Order orderToBeAdded = GetRandomOrder();
            orders.Add(orderToBeAdded);
            return orderToBeAdded;
        }

        public Order UpdateRandomOrder(List<Order> orders)
        {
            if (orders.Count == 0)
                return null;

            Order orderToBeUpdated = orders[_radnom.Next(orders.Count)];
            UpdateOrderRandomly(orderToBeUpdated);
            return orderToBeUpdated;
        }
    }
}
