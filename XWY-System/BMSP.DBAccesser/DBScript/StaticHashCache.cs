using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace BMSP.DBAccesser.DBScript
{
    public class StaticHashCache
    {

        private static int cacheSize = 2000;
        protected static Hashtable pool = new Hashtable(cacheSize);

        protected internal StaticHashCache() { }

        public object this[string Key]
        {
            get
            {
                var tv = (TimeValue)pool[Key];
                if (tv == null)
                {
                    return null;
                }
                if (DateTime.Now > tv.ExpiredOn)
                {
                    Remove(Key);
                    return null;
                }
                return tv.Value;
            }
            set
            {
                if (value == null)
                {
                    Remove(Key);
                }
                else
                {
                    TimeValue tv = TimeValue.CreateTimeValue(value);
                    lock (pool.SyncRoot)
                    {
                        if (pool.Count > cacheSize)
                        {
                            pool.Clear();
                        }

                        pool[Key] = tv;
                    }
                }
            }
        }

        public void Remove(string Key)
        {
            lock (pool.SyncRoot)
            {
                pool.Remove(Key);
            }
        }

        public void Clear()
        {
            lock (pool.SyncRoot)
            {
                pool.Clear();
            }
        }
    }
}
