using System;
using System.Collections.Generic;

class Stock
{
    public string Name { get; set; }
    public int NumShares { get; set; }
    public double SharePrice { get; set; }

    public double GetValue()
    {
        return NumShares * SharePrice;
    }
}

class StockPortfolio
{
    public List<Stock> Stocks { get; set; }

    public StockPortfolio()
    {
        Stocks = new List<Stock>();
    }

    public void AddStock(Stock stock)
    {
        Stocks.Add(stock);
    }

    public double GetTotalValue()
    {
        double totalValue = 0;
        foreach (var stock in Stocks)
        {
            totalValue += stock.GetValue();
        }
        return totalValue;
    }

    public void PrintReport()
    {
        Console.WriteLine("Stock Report\n");
        Console.WriteLine("{0,-20} {1,-15} {2,-15} {3,-15}", "Name", "Num Shares", "Share Price", "Value");
        foreach (var stock in Stocks)
        {
            Console.WriteLine("{0,-20} {1,-15} {2,-15:C} {3,-15:C}", stock.Name, stock.NumShares, stock.SharePrice, stock.GetValue());
        }
        Console.WriteLine("\nTotal value of stocks: {0:C}", GetTotalValue());
    }
}

class Program
{
    static void Main()
    {
        StockPortfolio portfolio = new StockPortfolio();
        Console.Write("Enter number of stocks: ");
        int numStocks = int.Parse(Console.ReadLine());
        for (int i = 1; i <= numStocks; i++)
        {
            Console.WriteLine("\nEnter details for stock {0}:", i);
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Number of shares: ");
            int numShares = int.Parse(Console.ReadLine());
            Console.Write("Share price: ");
            double sharePrice = double.Parse(Console.ReadLine());
            Stock stock = new Stock { Name = name, NumShares = numShares, SharePrice = sharePrice };
            portfolio.AddStock(stock);
        }
        portfolio.PrintReport();
    }
}
