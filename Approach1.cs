using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using ZitchaPoC;

public static class Approach1
{
    public static async Task<ApproachMetrics> Execute(List<Product> products)
    {
        var stopwatch = Stopwatch.StartNew();
        int totalProcessed = 0;
        int queueLoad = 0;

        // Produce all products to Kafka
        foreach (var product in products)
        {
            var message = JsonConvert.SerializeObject(product);
            await KafkaProducer.SendMessageAsync(message);
            queueLoad++;
        }

        // Consume and process messages
        KafkaConsumer.ConsumeMessages(message =>
        {
            totalProcessed++;
            var product = JsonConvert.DeserializeObject<Product>(message);
            if (product.IsSponsored)
            {
                Console.WriteLine($"Approach 1: Sent to Zitcha: {message}");
            }

            // Log resource usage every 100 messages
            if (totalProcessed % 100 == 0)
            {
                ResourceMonitor.LogResourceUsage();
            }
        }, messageLimit: 120000);


        stopwatch.Stop();

        return new ApproachMetrics
        {
            ApproachName = "Approach 1",
            TotalProcessingTimeMs = stopwatch.ElapsedMilliseconds,
            TotalProductsProcessed = totalProcessed,
            QueueLoad = queueLoad
        };
    }
}
