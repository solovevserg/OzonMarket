using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozon.Extensions
{
    public static class OrderStateExtensions
    {
        /// <summary>
        /// Returns the next state after the currnet one. If the current state is <see cref="OrderStates.Recieved"/> returns the current state.
        /// </summary>
        /// <param name="currentState">The current state to get next.</param>
        /// <returns>Next state after the currnet one.</returns>
        public static OrderStates NextOrRecieved(this OrderStates currentState)
        {
            return currentState == OrderStates.Recieved ? currentState : currentState + 1;
        }

        /// <summary>
        /// Returns the previous state before the current one. If the current state is <see cref="OrderStates.Waiting"/> returns the currnet state.
        /// </summary>
        /// <param name="currentState">The current state to get previous one.</param>
        /// <returns>The previous state before the current one.</returns>
        public static OrderStates PreviousOrWaiting(this OrderStates currentState)
        {
            return currentState == OrderStates.Waiting ? currentState : currentState - 1;
        }
    }
}
