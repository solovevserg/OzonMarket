using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace Ozon.Models.TransferEntities
{
    public class Order
    {
        public int Id { get; set; }

        public Client Client { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public OrderStates State { get; set; }

        public DateTime Time { get; set; }

        public List<Good> Goods { get; set; }
    }
}
