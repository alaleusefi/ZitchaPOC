using System;
using System.Diagnostics;

public static class ResourceMonitor
{
    private static readonly PerformanceCounter CpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
    private static readonly PerformanceCounter MemoryCounter = new PerformanceCounter("Memory", "Available MBytes");

    public static void LogResourceUsage()
    {
        // Get CPU and memory usage
        float cpuUsage = CpuCounter.NextValue();
        float availableMemory = MemoryCounter.NextValue();
        float totalMemory = GC.GetGCMemoryInfo().TotalAvailableMemoryBytes / (1024 * 1024); // Convert to MB
        float usedMemory = totalMemory - availableMemory;

        // Write to console
        Console.WriteLine($"[Resource Monitor] CPU Usage: {cpuUsage:F2}% | Memory Used: {usedMemory:F2} MB | Available Memory: {availableMemory:F2} MB");
    }
}
