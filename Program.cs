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

            // distribute cards to players
            string[,] players = new string[4, 9];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    players[i, j] = deck[i * 9 + j];
                }
            }

            // print the cards received by each player
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Player {i + 1} cards:");
                for (int j = 0; j < 9; j++)
                {
                    Console.WriteLine(players[i, j]);
                }
                Console.WriteLine();
            }
        }
    }

}
