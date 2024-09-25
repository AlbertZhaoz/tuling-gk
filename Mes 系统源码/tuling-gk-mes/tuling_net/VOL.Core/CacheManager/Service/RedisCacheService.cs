using CSRedis;
using HslCommunication.Enthernet.Redis;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using VOL.Core.Configuration;
using VOL.Core.Const;

namespace VOL.Core.CacheManager
{
    public class RedisCacheService : ICacheService
    {
        private CSRedisClient _redisClient;
        
        public RedisCacheService()
        {
            _redisClient = new CSRedisClient(AppSetting.RedisConnectionString);
            RedisHelper.Initialization(_redisClient);
        }

        public CSRedisClient GetInstance()
        {
            return _redisClient;
        }
        
        /// <summary>
        /// 验证缓存项是否存在
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return RedisHelper.Exists(key);
        }

        public void LPush(string key, string val)
        {
            RedisHelper.LPush(key, val);
        }

        public void RPush(string key, string val)
        {
            RedisHelper.RPush(key, val);
        }

        public T ListDequeue<T>(string key) where T : class
        {
            string value = RedisHelper.RPop(key);
            if (string.IsNullOrEmpty(value))
                return null;
            return JsonConvert.DeserializeObject<T>(value);
        }

        public object ListDequeue(string key)
        {
            string value = RedisHelper.RPop(key);
            if (string.IsNullOrEmpty(value))
                return null;
            return value;
        }

        /// <summary>
        /// 移除list中的数据，keepIndex为保留的位置到最后一个元素如list 元素为1.2.3.....100
        /// 需要移除前3个数，keepindex应该为4
        /// </summary>
        /// <param name="key"></param>
        /// <param name="keepIndex"></param>
        public void ListRemove(string key, int keepIndex)
        {
            RedisHelper.LTrim(key, keepIndex, -1);
        }

        public bool Add(string key, string value, int expireSeconds = -1, bool isSliding = false)
        {
            return RedisHelper.Set(key, value, expireSeconds);
        }

        public bool AddObject(string key, object value, int expireSeconds = -1, bool isSliding = false)
        {
            return RedisHelper.Set(key, value, expireSeconds);
        }

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public bool Remove(string key)
        {
            RedisHelper.Del(key);
            return true;
        }

        /// <summary>
        /// 批量删除缓存
        /// </summary>
        /// <param name="key">缓存Key集合</param>
        /// <returns></returns>
        public void RemoveAll(IEnumerable<string> keys)
        {
            RedisHelper.Del(keys.ToArray());
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public T Get<T>(string key) where T : class
        {
            return RedisHelper.Get<T>(key);
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public string Get(string key)
        {
            return RedisHelper.Get(key);
        }

        public string[] GetList(string key)
        {
            var values = RedisHelper.LRange(key, 0, -1);

            //var test = RedisHelper.GetRange(key, 0, -1);

            return values;
        }

        public string[] GetKeys(string pattern)
        {
            var values = RedisHelper.Keys(pattern);

            return values;
        }
        
        // 实现 XREADGROUP GROUP g1 c1 COUNT 1 [BLOCK 2000] STREAMS MESSAGE_STREAM_KEY >

        public void Dispose()
        {
        }
    }
}
