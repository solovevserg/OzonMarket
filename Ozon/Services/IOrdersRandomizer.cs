using Ozon.Models.TransferEntities;
using System.Collections.Generic;

namespace Ozon.Services
{
    public interface IOrdersRandomizer
    {
        /// <summary>
        /// Creates a random order with all fields filled.
        /// </summary>
        /// <returns>Random Order.</returns>
        Order GetRandomOrder();

        /// <summary>
        /// Creates a list of random orders.
        /// </summary>
        /// <param name="count">Number of randoms orders in the list.</param>
        /// <returns>List of random orders.</returns>
        List<Order> GetRandomOrders(int count);

        /// <summary>
        /// Updates random number of fields of given order randomly.
        /// </summary>  
        /// <param name="order">Order to be updated.</param>
        /// <returns>Given order updated.</returns>
        Order UpdateOrderRandomly(Order order);

        /// <summary>
        /// Randomly deletes an order from the list.
        /// </summary>
        /// <param name="orders">An existing list of orders where an order has to be deleted.</param>
        /// <returns>Deleted order.</returns>
        Order DeleteRandomOrder(List<Order> orders);

        /// <summary>
        /// Adds a random order to the orders list.
        /// </summary>
        /// <param name="orders">An existing orders list where an order has to be added to.</param>
        /// <returns>Added order.</returns>
        Order AddRandomOrder(List<Order> orders);

        /// <summary>
        /// Updates a random order in the list.
        /// </summary>
        /// <param name="orders">An existing orders list where an order has to be updated randomly.</param>
        /// <returns>Updated order.</returns>
        Order UpdateRandomOrder(List<Order> orders);
    }
}