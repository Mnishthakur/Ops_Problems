using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace InventoryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read in JSON file
            string json = File.ReadAllText("inventory.json");

            // Parse JSON into list of Inventory objects using InventoryFactory
            InventoryManager inventoryManager = new InventoryManager();
            inventoryManager.LoadInventory(json);

            // Calculate the value for every Inventory
            inventoryManager.CalculateInventoryPrice();

            // Output the JSON string for each Inventory object
            inventoryManager.PrintInventoryDetails();
        }
    }

    // Inventory Factory for creating Inventory objects from JSON
    class InventoryFactory
    {
        public static Inventory CreateInventory(string json)
        {
            return JsonConvert.DeserializeObject<Inventory>(json);
        }
    }

    // Inventory Manager for managing a list of Inventory objects
    class InventoryManager
    {
        private List<Inventory> inventories = new List<Inventory>();

        // Load Inventory objects from JSON string
        public void LoadInventory(string json)
        {
            // Parse JSON array into list of Inventory objects using InventoryFactory
            List<Inventory> inventoryList = JsonConvert.DeserializeObject<List<Inventory>>(json);

            // Add each Inventory object to the list of inventories
            foreach (Inventory inventory in inventoryList)
            {
                inventories.Add(inventory);
            }
        }

        // Calculate the value for every Inventory
        public void CalculateInventoryPrice()
        {
            foreach (Inventory inventory in inventories)
            {
                inventory.CalculatePrice();
            }
        }

        // Output the JSON string for each Inventory object
        public void PrintInventoryDetails()
        {
            foreach (Inventory inventory in inventories)
            {
                Console.WriteLine(inventory.ToJson());
            }
        }
    }

    // Inventory class for Rice, Pulses, and Wheats
    class Inventory
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double PricePerKg { get; set; }
        public double Price { get; set; }

        // Calculate the total price for the inventory
        public void CalculatePrice()
        {
            Price = Weight * PricePerKg;
        }

        // Return the JSON string for the Inventory object
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
