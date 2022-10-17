using Azure;
using Azure.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TbleStorageSamples
{
    public class MyEntity : ITableEntity, ITest
    {
        public string Product { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
        public string BlaBla { get ; set ; }
        //ETag ITableEntity.ETag { get ; set ; }
    }

    public interface ITest
    {
        public string BlaBla { get; set; }
    }
}
