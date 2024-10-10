using StackExchange.Redis;
using System.Text.Json;
using Project.Domain.Interfaces.Services;

namespace Project.Infrastructure.Cache;

public class RedisService(IConnectionMultiplexer redis) : IRedisService
{
    private readonly IDatabase _database = redis.GetDatabase();

    public async Task SetAsync<T>(string key, T value, TimeSpan expirationTime)
    {
        var jsonValue = JsonSerializer.Serialize(value);
        await _database.StringSetAsync(key, jsonValue, expirationTime);
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        var jsonValue = await _database.StringGetAsync(key);
        if (jsonValue.IsNullOrEmpty)
        {
            return default;
        }

        return JsonSerializer.Deserialize<T>(jsonValue!);
    }

    public async Task DeleteAsync(string key)
    {
        await _database.KeyDeleteAsync(key);
    }
}

