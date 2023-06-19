using System;

class CompanyShares
{
    public string symbol;
    public int shares;
    public DateTime dateTime;

    public CompanyShares(string symbol, int shares, DateTime dateTime)
    {
        this.symbol = symbol;
        this.shares = shares;
        this.dateTime = dateTime;
    }
}

class LinkedListNode
{
    public CompanyShares data;
    public LinkedListNode next;

    public LinkedListNode(CompanyShares data)
    {
        this.data = data;
        this.next = null;
    }
}

class StockAccount
{
    private LinkedListNode head;

    public StockAccount()
    {
        head = null;
    }

    public void buy(int amount, string symbol)
    {
        CompanyShares companyShares = new CompanyShares(symbol, amount, DateTime.Now);
        if (head == null)
        {
            head = new LinkedListNode(companyShares);
        }
        else
        {
            LinkedListNode currentNode = head;
            while (currentNode.next != null)
            {
                if (currentNode.data.symbol == symbol)
                {
                    currentNode.data.shares += amount;
                    return;
                }
                currentNode = currentNode.next;
            }
            if (currentNode.data.symbol == symbol)
            {
                currentNode.data.shares += amount;
            }
            else
            {
                currentNode.next = new LinkedListNode(companyShares);
            }
        }
    }

    public void sell(int amount, string symbol)
    {
        if (head == null)
        {
            Console.WriteLine("No shares available to sell.");
            return;
        }

        LinkedListNode currentNode = head;
        while (currentNode != null)
        {
            if (currentNode.data.symbol == symbol)
            {
                if (currentNode.data.shares < amount)
                {
                    Console.WriteLine("Not enough shares to sell.");
                }
                else if (currentNode.data.shares == amount)
                {
                    if (currentNode == head)
                    {
                        head = currentNode.next;
                    }
                    else
                    {
                        LinkedListNode previousNode = head;
                        while (previousNode.next != currentNode)
                        {
                            previousNode = previousNode.next;
                        }
                        previousNode.next = currentNode.next;
                    }
                }
                else
                {
                    currentNode.data.shares -= amount;
                }
                return;
            }
            currentNode = currentNode.next;
        }

        Console.WriteLine("Shares not found.");
    }

    public double valueOf()
    {
        double value = 0.0;
        LinkedListNode currentNode = head;
        while (currentNode != null)
        {
            switch (currentNode.data.symbol)
            {
                case "AAPL":
                    value += currentNode.data.shares * 148.48;
                    break;
                case "GOOG":
                    value += currentNode.data.shares * 2761.53;
                    break;
                case "TSLA":
                    value += currentNode.data.shares * 675.50;
                    break;
            }
            currentNode = currentNode.next;
        }
        return value;
    }

    public void printReport()
    {
        Console.WriteLine("Stocks in account:");
        LinkedListNode currentNode = head;
        while (currentNode != null)
        {
            Console.WriteLine(currentNode.data.symbol + " - " + currentNode.data.shares + " shares - " + currentNode.data.dateTime.ToString("yyyy/MM/dd HH:mm:ss"));
            currentNode = currentNode.next;
        }
        Console.WriteLine("Total value of account: " + valueOf().ToString("C2"));
    }

    public void save(string filename)
    {
        // implementation for saving to file
    }
}

class Program
{
    static void Main(string[] args)
    {
        StockAccount account = new StockAccount();
        Console.WriteLine("Total value of account: " + account.valueOf());

        account.buy(10, "AAPL");
        account.buy(20, "GOOGL");

        Console.WriteLine("Total value of account: " + account.valueOf());

        account.sell(5, "AAPL");

        Console.WriteLine("Total value of account: " + account.valueOf());

        account.printReport();

        account.save("data.txt");
    }
}
