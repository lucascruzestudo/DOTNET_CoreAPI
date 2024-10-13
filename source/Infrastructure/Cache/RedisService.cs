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

    public async Task<string?> GetAsync<T>(string key)
    {
        return await _database.StringGetAsync(key);
    }

    public async Task DeleteAsync(string key)
    {
        await _database.KeyDeleteAsync(key);
    }
}

