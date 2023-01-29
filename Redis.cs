using StackExchange.Redis;

namespace NetCore.Redis.Demo;

public class Redis
{
    private readonly IConnectionMultiplexer _redis;

    public Redis(IConnectionMultiplexer redis)
    {
        _redis = redis;
    }

    public async Task<string> GetOrSetString(string key, string value= null)
    {
        var database = _redis.GetDatabase();
        var retrievedValue = await database.StringGetAsync(key);

        if (retrievedValue is not { IsNull: true }) return retrievedValue;

        if(value is not null)await database.StringSetAsync(key, value);
        return "No value was originally available so a new one was set";
    }
}