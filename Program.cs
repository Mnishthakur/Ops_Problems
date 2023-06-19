using System;
namespace OOPS_Problems
{
    class Node
    {
        public string data;
        public Node next;

        public Node(string value)
        {
            data = value;
            next = null;
        }
    }

    class Stack
    {
        private Node top;

        public Stack()
        {
            top = null;
        }

        public void Push(string value)
        {
            Node newNode = new Node(value);
            newNode.next = top;
            top = newNode;
        }

        public string Pop()
        {
            if (top == null)
            {
                throw new Exception("Stack is empty");
            }

            string value = top.data;
            top = top.next;
            return value;
        }

        public string Peek()
        {
            if (top == null)
            {
                throw new Exception("Stack is empty");
            }

            return top.data;
        }

        public bool IsEmpty()
        {
            return top == null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Stack transactionStack = new Stack();

            // simulate buying and selling stocks
            transactionStack.Push("AAPL");
            transactionStack.Push("GOOG");
            transactionStack.Push("TSLA");
            transactionStack.Pop();
            transactionStack.Push("AMZN");
            transactionStack.Push("MSFT");
            transactionStack.Pop();
            transactionStack.Pop();

            // print out the transactions in reverse order
            while (!transactionStack.IsEmpty())
            {
                Console.WriteLine(transactionStack.Pop());
            }
        }
    }

}
