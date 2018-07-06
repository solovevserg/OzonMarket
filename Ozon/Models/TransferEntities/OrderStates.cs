public enum OrderStates
{
    /// <summary>
    /// Order is waiting before start of executing.
    /// </summary>
    Waiting,

    /// <summary>
    /// Execution of an order is started.
    /// </summary>
    Started,

    /// <summary>
    /// An order is assembled by workers.
    /// </summary>
    Assembling,

    /// <summary>
    /// Order is on the way to the point of delivery.
    /// </summary>
    Transportation,

    /// <summary>
    /// An order is delivered to the point.
    /// </summary>
    Delivered,

    /// <summary>
    /// An order is got by the client.
    /// </summary>
    Recieved,
}