using System;
namespace OOPS_Problems
{
    class Transaction
    {
        public string StockSymbol;
        public DateTime TransactionTime;

        public Transaction(string stockSymbol, DateTime transactionTime)
        {
            StockSymbol = stockSymbol;
            TransactionTime = transactionTime;
        }
    }

    class Node
    {
        public Transaction data;
        public Node next;

        public Node(Transaction value)
        {
            data = value;
            next = null;
        }
    }

    class Queue
    {
        private Node front;
        private Node rear;

        public Queue()
        {
            front = null;
            rear = null;
        }

        public void Enqueue(Transaction value)
        {
            Node newNode = new Node(value);

            if (rear == null)
            {
                front = newNode;
                rear = newNode;
            }
            else
            {
                rear.next = newNode;
                rear = newNode;
            }
        }

        public Transaction Dequeue()
        {
            if (front == null)
            {
                throw new Exception("Queue is empty");
            }

            Transaction value = front.data;
            front = front.next;

            if (front == null)
            {
                rear = null;
            }

            return value;
        }

        public Transaction Peek()
        {
            if (front == null)
            {
                throw new Exception("Queue is empty");
            }

            return front.data;
        }

        public bool IsEmpty()
        {
            return front == null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Queue transactionQueue = new Queue();

            // simulate buying and selling stocks
            transactionQueue.Enqueue(new Transaction("AAPL", DateTime.Now));
            transactionQueue.Enqueue(new Transaction("GOOG", DateTime.Now));
            transactionQueue.Enqueue(new Transaction("TSLA", DateTime.Now));
            transactionQueue.Dequeue();
            transactionQueue.Enqueue(new Transaction("AMZN", DateTime.Now));
            transactionQueue.Enqueue(new Transaction("MSFT", DateTime.Now));
            transactionQueue.Dequeue();
            transactionQueue.Dequeue();

            // print out the transactions in order
            while (!transactionQueue.IsEmpty())
            {
                Transaction transaction = transactionQueue.Dequeue();
                Console.WriteLine($"{transaction.StockSymbol} - {transaction.TransactionTime}");
            }
        }
    }

}
