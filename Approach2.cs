using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using ZitchaPoC;

public static class Approach2
{
    public static async Task<ApproachMetrics> Execute(List<Product> products)
    {
        var stopwatch = Stopwatch.StartNew();
        int totalProcessed = 0;
        int queueLoad = 0;

        // Produce only sponsored products to Kafka
        foreach (var product in products)
        {
            if (product.IsSponsored)
            {
                var message = JsonConvert.SerializeObject(product);
                await KafkaProducer.SendMessageAsync(message);
                queueLoad++;
            }
        }

        // Consume and process messages
        KafkaConsumer.ConsumeMessages(message =>
        {
            totalProcessed++;
            Console.WriteLine($"Approach 2: Sent to Zitcha: {message}");

            // Log resource usage every 100 messages
            if (totalProcessed % 100 == 0)
            {
                ResourceMonitor.LogResourceUsage();
            }
        }, messageLimit: 120000);
        // Set message limit for testing

        stopwatch.Stop();

        return new ApproachMetrics
        {
            ApproachName = "Approach 2",
            TotalProcessingTimeMs = stopwatch.ElapsedMilliseconds,
            TotalProductsProcessed = totalProcessed,
            QueueLoad = queueLoad
        };
    }
}
