using Confluent.Kafka;
using System;
using ZitchaPoC;

public static class KafkaConsumer
{
    public static void ConsumeMessages(Action<string> processMessage, int messageLimit = 10)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = KafkaConfig.BootstrapServers,
            GroupId = KafkaConfig.GroupId,
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        using (var consumer = new ConsumerBuilder<Null, string>(config).Build())
        {
            consumer.Subscribe(KafkaConfig.Topic);

            int messagesConsumed = 0;
            while (messagesConsumed < messageLimit)
            {
                var consumeResult = consumer.Consume();
                Console.WriteLine($"Consumed message: {consumeResult.Value}");
                processMessage(consumeResult.Value);
                messagesConsumed++;
            }

            Console.WriteLine("Reached message limit, stopping consumer...");
        }
    }
}
