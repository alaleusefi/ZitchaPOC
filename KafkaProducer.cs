using Confluent.Kafka;
using System;
using System.Threading.Tasks;
using ZitchaPoC;

public static class KafkaProducer
{
    public static async Task SendMessageAsync(string message)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = KafkaConfig.BootstrapServers
        };

        using (var producer = new ProducerBuilder<Null, string>(config).Build())
        {
            await producer.ProduceAsync(KafkaConfig.Topic, new Message<Null, string> { Value = message });
            Console.WriteLine($"Produced message: {message}");
        }
    }
}
