using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Generate mock data for 120,000 products
        var products = ProductGenerator.GenerateMockData(120000);

        // Execute Approach 1
        Console.WriteLine("Running Approach 1 (Process All Products)...");
        var approach1Metrics = await Approach1.Execute(products);

        // Log final resource usage after Approach 1
        Console.WriteLine("\nFinal Resource Usage after Approach 1:");
        ResourceMonitor.LogResourceUsage();

        // Execute Approach 2
        Console.WriteLine("\nRunning Approach 2 (Filter Sponsored in Producer)...");
        var approach2Metrics = await Approach2.Execute(products);

        // Log final resource usage after Approach 2
        Console.WriteLine("\nFinal Resource Usage after Approach 2:");
        ResourceMonitor.LogResourceUsage();

        // Print final metrics for both approaches
        Console.WriteLine("\nFinal Metrics:");
        approach1Metrics.PrintMetrics();
        approach2Metrics.PrintMetrics();
    }
}
