namespace Ozon.Services
{
    public class StorageSeeder : IStorageSeeder
    {
        private readonly IOrdersRandomizer _randomizer;

        public StorageSeeder(IOrdersRandomizer randomizer)
        {
            _randomizer = randomizer;
        }

        public void Seed(IStorage storage)
        {
            storage.Orders.AddRange(_randomizer.GetRandomOrders(10));
        }
    }
}
