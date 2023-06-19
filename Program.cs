using System;
namespace OOPS_Problems
{
    class DeckOfCards
    {
        static void Main(string[] args)
        {
            // initialize deck of cards
            string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
            string[] deck = new string[52];

            for (int i = 0; i < ranks.Length; i++)
            {
                for (int j = 0; j < suits.Length; j++)
                {
                    deck[suits.Length * i + j] = ranks[i] + " of " + suits[j];
                }
            }

            // shuffle the deck
            Random rand = new Random();
            for (int i = deck.Length - 1; i >= 0; i--)
            {
                int j = rand.Next(i + 1);
                string temp = deck[j];
                deck[j] = deck[i];
                deck[i] = temp;
            }

            // create player objects and assign cards
            Player[] players = new Player[4];
            for (int i = 0; i < 4; i++)
            {
                players[i] = new Player();
                for (int j = 0; j < 9; j++)
                {
                    players[i].AddCard(deck[i * 9 + j]);
                }
                players[i].SortCards();
            }

            // print the players and their cards
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Player {i + 1} cards:");
                players[i].PrintCards();
                Console.WriteLine();
            }
        }
    }

    class Player
    {
        private class Node
        {
            public string data;
            public Node next;

            public Node(string data)
            {
                this.data = data;
                next = null;
            }
        }

        private Node head;
        private int count;

        public Player()
        {
            head = null;
            count = 0;
        }

        public void AddCard(string card)
        {
            Node newNode = new Node(card);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = newNode;
            }
            count++;
        }

        public void SortCards()
        {
            for (Node i = head; i != null; i = i.next)
            {
                Node min = i;
                for (Node j = i.next; j != null; j = j.next)
                {
                    //if (CompareCards(j.data, min.data) < 0)
                    {
                        min = j;
                    }
                }
                string temp = i.data;
                i.data = min.data;
                min.data = temp;
            }
        }

        public void PrintCards()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }
        }
    }
}
