using System.Threading.Tasks;

namespace RedisDemo.Interface
{
    
    public interface IRedisCaching
    {
        public Task<string> GetRecordsFromRedis(string key);
        public void SetRecordsInRedis(string key,string content);
        
    }
}
