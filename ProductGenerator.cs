using System;
using System.Collections.Generic;
using ZitchaPoC;

public static class ProductGenerator
{
    public static List<Product> GenerateMockData(int count)
    {
        var random = new Random();
        var products = new List<Product>();

        for (int i = 0; i < count; i++)
        {
            products.Add(new Product
            {
                Id = Guid.NewGuid().ToString(),
                Category = "Category" + random.Next(1, 5),
                IsSponsored = random.Next(0, 10) < 2 // 20% chance
            });
        }

        return products;
    }
}
