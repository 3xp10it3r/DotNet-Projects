using Newtonsoft.Json;

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public List<string> Tags { get; set; }
}

public class Program
{
    public static void Main()
    {
        string json = "{\"Name\": \"Laptop\", \"Price\": 999.99, \"Tags\": [\"Electronics\", \"Computers\"]}";
        Product product = JsonConvert.DeserializeObject<Product>(json);
        Console.WriteLine($"Product Name: {product.Name}");
        Console.WriteLine($"Product Price: {product.Price}");
        Console.WriteLine("Product Tags: " + string.Join(", ", product.Tags));

        // Serialize the product object back to JSON
        string serializedJson = JsonConvert.SerializeObject(product, Formatting.Indented);
        Console.WriteLine("Serialized JSON:\n" + serializedJson);
    }
}