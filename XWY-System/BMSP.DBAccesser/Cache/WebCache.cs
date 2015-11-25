using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace BMSP.DBAccesser.DBScript
{
    public class WebCache<T>
    {
        private T data;
        /// <summary>
        /// 獲取或设置緩存值(對象實例化後如果存在緩存則會為此屬性設值)
        /// </summary>
        public T Data
        {
            get { return data; }
            set
            {
                Set(value);
            }
        }

        private bool isExist;
        /// <summary>
        /// 是否存在這個緩存
        /// </summary>
        public bool IsExist
        {
            get { return isExist; }
            set { isExist = value; }
        }

        private string key;

        /// <summary>
        /// 構造函數
        /// </summary>
        /// <param name="webCacheKey">緩存Key的主要部分</param>
        /// <param name="arg">緩存Key的其它部分，可以為空，與webCacheKey共同決定唯一的數據緩存</param>
        public WebCache(WebCacheKey cacheKey, object cacheArg)
        {
            key = GetKey(cacheKey, cacheArg);

            if (HttpRuntime.Cache[key] == null)
                isExist = false;
            else
            {
                isExist = true;
                data = (T)HttpRuntime.Cache[key];
            }
        }

        /// <summary>
        /// 設置緩存，如果不存在則新加，如果存在則更新
        /// </summary>        
        /// <param name="value">緩存值</param>
        /// <param name="overDate">指定過期絕對時間</param>
        public T Set(T value, DateTime overDate)
        {
            //if (Config.App.EnableCaching)
            //{
                if (value != null)
                {
                    data = value;
                    if (isExist)
                        HttpRuntime.Cache.Remove(key);
                    HttpRuntime.Cache.Add(key, value, null, overDate, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
                }
            //}
            return value;
        }
        /// <summary>
        /// 使用默認緩存時間(Web.config中設置)設置緩存，如果不存在則新加，如果存在則更新
        /// </summary>        
        /// <param name="value">緩存值</param>
        public T Set(T value)
        {
            return Set(value, DateTime.Now.AddSeconds(5000));
        }
        /// <summary>
        /// 移除缓存
        /// </summary>
        public void Remove()
        {
            if (isExist)
                HttpRuntime.Cache.Remove(key);
        }
        /// <summary>
        /// 获取缓存关键字
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="cacheArg"></param>
        /// <returns></returns>
        public static string GetKey(WebCacheKey cacheKey, object cacheArg)
        {
            string key = "CKEY" + cacheKey.ToString();
            if (cacheArg != null && cacheArg.ToString().Length > 0)
                key += "_" + cacheArg.ToString();
            return key;
        }
        /// <summary>
        /// 移除缓存的static方法
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="cacheArg"></param>
        public static void Remove(WebCacheKey cacheKey, object cacheArg)
        {
            HttpRuntime.Cache.Remove(GetKey(cacheKey, cacheArg));
        }
    }
}
