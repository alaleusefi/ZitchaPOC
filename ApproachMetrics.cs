public class ApproachMetrics
{
    public string ApproachName { get; set; }
    public long TotalProcessingTimeMs { get; set; }
    public int TotalProductsProcessed { get; set; }
    public int QueueLoad { get; set; }

    public void PrintMetrics()
    {
        Console.WriteLine($"{ApproachName} Metrics:");
        Console.WriteLine($"- Total Processing Time: {TotalProcessingTimeMs} ms");
        Console.WriteLine($"- Total Products Processed: {TotalProductsProcessed}");
        Console.WriteLine($"- Queue Load: {QueueLoad}");
    }
}
