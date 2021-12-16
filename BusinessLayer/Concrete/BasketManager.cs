using BusinessLayer.Abstract;
using EntityLayer.Concrete.BasketEntity;
using StackExchange.Redis;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
  public class BasketManager: IBasketService
    {
        private readonly StackExchange.Redis.IDatabase database;
        public BasketManager(IConnectionMultiplexer connectionMultiplexer)
        {
            database = connectionMultiplexer.GetDatabase();
        }
        public async Task<bool> DeleteBasketAsync(string basktetId)
        {
            return await database.KeyDeleteAsync(basktetId);
        }

        public async Task<Basket> GetBasketAsync(string basketId)
        {
            var basket = await database.StringGetAsync(basketId);
            return basket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<Basket>(basket);
        }

        public async Task<Basket> UpdateBasketAsync(Basket basket)
        {
            var created = await database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(3));
            if (!created)

                return null;

            return await GetBasketAsync(basket.Id);
        }
    }
}
