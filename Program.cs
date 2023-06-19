using System;
using System.IO;
using System.Xml;
using Newtonsoft.Json;

namespace JSONInventoryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonFilePath = "inventory.json";
            Inventory inventory = ReadInventoryFromJsonFile(jsonFilePath);
            Console.WriteLine("Inventory Details:");
            Console.WriteLine("-------------------");
            Console.WriteLine(inventory);
            Console.WriteLine("Inventory Value:");
            Console.WriteLine("-----------------");
            Console.WriteLine($"Total value of rice inventory: {inventory.CalculateInventoryValue("rice")}");
            Console.WriteLine($"Total value of pulses inventory: {inventory.CalculateInventoryValue("pulses")}");
            Console.WriteLine($"Total value of wheat inventory: {inventory.CalculateInventoryValue("wheat")}");
            WriteInventoryToJsonFile("inventory_output.json", inventory);
            Console.WriteLine("JSON file created with Inventory Details.");
        }

        static Inventory ReadInventoryFromJsonFile(string filePath)
        {
            string jsonText = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Inventory>(jsonText);
        }

        static void WriteInventoryToJsonFile(string filePath, Inventory inventory)
        {
            string jsonText = JsonConvert.SerializeObject(inventory, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, jsonText);
        }
    }

    class Inventory
    {
        public Rice[] Rice { get; set; }
        public Pulses[] Pulses { get; set; }
        public Wheat[] Wheat { get; set; }

        public double CalculateInventoryValue(string itemType)
        {
            double totalValue = 0.0;
            switch (itemType.ToLower())
            {
                case "rice":
                    foreach (var rice in Rice)
                    {
                        totalValue += rice.WeightInKg * rice.PricePerKg;
                    }
                    break;
                case "pulses":
                    foreach (var pulses in Pulses)
                    {
                        totalValue += pulses.WeightInKg * pulses.PricePerKg;
                    }
                    break;
                case "wheat":
                    foreach (var wheat in Wheat)
                    {
                        totalValue += wheat.WeightInKg * wheat.PricePerKg;
                    }
                    break;
                default:
                    throw new ArgumentException($"Invalid item type: {itemType}");
            }
            return totalValue;
        }

        public override string ToString()
        {
            return $"Rice: {JsonConvert.SerializeObject(Rice, Newtonsoft.Json.Formatting.Indented)}" +
                   $"\nPulses: {JsonConvert.SerializeObject(Pulses, Newtonsoft.Json.Formatting.Indented)}" +
                   $"\nWheat: {JsonConvert.SerializeObject(Wheat, Newtonsoft.Json.Formatting.Indented)}";
        }
    }

    class Rice
    {
        public string Name { get; set; }
        public double WeightInKg { get; set; }
        public double PricePerKg { get; set; }
    }

    class Pulses
    {
        public string Name { get; set; }
        public double WeightInKg { get; set; }
        public double PricePerKg { get; set; }
    }

    class Wheat
    {
        public string Name { get; set; }
        public double WeightInKg { get; set; }
        public double PricePerKg { get; set; }
    }
}
