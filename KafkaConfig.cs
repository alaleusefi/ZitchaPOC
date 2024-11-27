using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZitchaPoC
{
    public static class KafkaConfig
    {
        public const string BootstrapServers = "localhost:9092";
        public const string Topic = "zitcha-products-topic";
        public const string GroupId = "zitcha-group";
    }

}
