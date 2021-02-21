//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Utility.Es;

//namespace Utility.Zipkin
//{
//    /// <summary>
//    /// 日志格式 是 怎样 的 了 ILogger   zipkin 服务器 支持 内存 或 es (异常有问题 不需要实现 ) 下载 版本 不对
//    /// </summary>
//    public class EsLogger : zipkin4net.ILogger
//    {
//        public class Message
//        {
//            public string Msg { get; set; }
//            public string Level { get; set; } = "info";
//            public DateTime Date { get; set; } = DateTime.Now;
//        }
//        public readonly ElasticsearchHelper ElasticsearchHelper;

//        public EsLogger(ElasticsearchHelper elasticsearchHelper)
//        {
//            ElasticsearchHelper = elasticsearchHelper;
//        }

//        public void LogError(string message)
//        {
//            ElasticsearchHelper.InsertByIndex($"zipkin_{DateTime.Now.ToString("yyyy-MM-dd-HH")}", Guid.NewGuid().ToString(),new Message() { Msg=message,Level="error"});
//        }

//        public void LogInformation(string message)
//        {
//            ElasticsearchHelper.InsertByIndex($"zipkin_{DateTime.Now.ToString("yyyy-MM-dd-HH")}", Guid.NewGuid().ToString(), new Message() { Msg = message, Level = "info" });
//        }

//        public void LogWarning(string message)
//        {
//            ElasticsearchHelper.InsertByIndex($"zipkin_{DateTime.Now.ToString("yyyy-MM-dd-HH")}", Guid.NewGuid().ToString(), new Message() { Msg = message, Level = "warn" });
//        }
//    }
//}
