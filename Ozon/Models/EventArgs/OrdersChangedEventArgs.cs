using Ozon.Models.TransferEntities;

namespace Ozon.Models.EventArgs
{
    public class OrdersChangedEventArgs
    {
        public OrdersChangedEventArgs(OrdersDiff diff)
        {
            OrdersDiff = diff ?? throw new System.ArgumentNullException($"Argument {nameof(diff)} can not be null");
        }

        public OrdersDiff OrdersDiff { get; }
    }
}