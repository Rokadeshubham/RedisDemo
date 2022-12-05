

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Caching.Distributed;
using RedisDemo.Interface;
using System;
using System.Threading.Tasks;

namespace RedisDemo.Components
{
    public partial class HomePage : ComponentBase
    {
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] IDistributedCache redisCache { get; set; }
        [Inject] IRedisCaching redisChaching { get; set; }

        string currentUrl { get; set; }

        protected override void OnInitialized()
        {
            currentUrl = NavigationManager.Uri;
            //var options = new DistributedCacheEntryOptions();
            //options.SetAbsoluteExpiration(DateTimeOffset.Now.AddMinutes(1));
            //redisCache.SetString("employees",currentUrl, options);
            //var a = redisCache.GetString("employees");
            redisChaching.SetRecordsInRedis("currentURL",currentUrl);
            var urlCheck = redisChaching.GetRecordsFromRedis("currentURL");

            
        }
        
    }
}