using System;

namespace Glimpse.AspNet.Model
{
    public class CacheItemModel
    {
        public string Key { get; set; }

        public object Value { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ExpiresOn { get; set; }

        public TimeSpan SlidingExpiration { get; set; }
    }
}