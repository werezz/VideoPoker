using System;
using System.Collections.Generic;

namespace CardGame
{

    class VideoPoker
    {
        static void Main(string[] args)
        {
            string input ="";
            char[] delimiterChars = {' ',',','.',':','\t'};
            int points = 0;
            int pointDifference = 0;
            int cardCounter = -1;
            bool gameIsOn = true;
            bool won = false;
            bool winMessage = false;
            string playerDesicion;

            var deck = new Deck();
            deck.Shuffle();
            List<Card> playerCards = new List<Card>();

            JacksOrBetter VideoPokerGame = new JacksOrBetter();

            while (gameIsOn)
            {
                pointDifference = points;

                Console.WriteLine("The players hand:\n");
                for (int i = 0; i < 5; i++)
                {
                    playerCards.Add(deck.GetCard());
                    Console.WriteLine($"{i + 1}:Card {playerCards[i].DisplayName}, {playerCards[i].Suit}, {playerCards[i].Value}");
                }

                Console.WriteLine("\nChoose which cards to discards: \nexample 1,5 (discards first and fifth cards from hand)\n");
                input = Console.ReadLine();
                Console.WriteLine();
                string[] discardCards = input.Split(delimiterChars);

                //put discarded cards back to deck
                foreach (var card in discardCards)
                {
                    deck.PutCard(playerCards[Int32.Parse(card) + cardCounter]);
                    playerCards.RemoveAt(Int32.Parse(card) + cardCounter);
                    cardCounter += -1;
                }               

                //draw new cards
                for (int i = 0; discardCards.Length > i; i++)
                {
                    deck.Shuffle();
                    playerCards.Add(deck.GetCard());
                }

                Console.WriteLine("\nPlayers new hand:\n");

                for (int i = 0; i < playerCards.Count; i++)
                {
                    Console.WriteLine($"{i + 1}:Card {playerCards[i].DisplayName}, {playerCards[i].Suit}, {playerCards[i].Value}");
                }

                //Checking winning conditions
                points += VideoPokerGame.RoyalFlush(playerCards);
                won = CheckPointDifference(pointDifference, points);
                if (won)
                {
                    winMessage = true;
                    Console.WriteLine("You won a RoyalFlush !!!");
                }

                if (!won)
                {
                    points += VideoPokerGame.StraightFlush(playerCards);
                    won = CheckPointDifference(pointDifference, points);
                }
                if (won && !winMessage)
                {
                    winMessage = true;
                    Console.WriteLine("You won a StraightFlush !!!");
                }

                if (!won)
                {
                    points += VideoPokerGame.FourOfAKind(playerCards);
                    won = CheckPointDifference(pointDifference, points);
                }
                if (won && !winMessage)
                {
                    winMessage = true;
                    Console.WriteLine("You won a Four Of A Kind !!!");
                }

                if (!won)
                {
                    points += VideoPokerGame.FullHouse(playerCards);
                    won = CheckPointDifference(pointDifference, points);
                }
                if (won && !winMessage)
                {
                    winMessage = true;
                    Console.WriteLine("You won a FullHouse !!!");
                }

                if (!won)
                {
                    points += VideoPokerGame.Flush(playerCards);
                    won = CheckPointDifference(pointDifference, points);
                }
                if (won && !winMessage)
                {
                    winMessage = true;
                    Console.WriteLine("You won a Flush !!!");
                }

                if (!won)
                {
                    points += VideoPokerGame.Straight(playerCards);
                    won = CheckPointDifference(pointDifference, points);
                }
                if (won && !winMessage)
                {
                    winMessage = true;
                    Console.WriteLine("You won a Straight !!!");
                }

                if (!won)
                {
                    points += VideoPokerGame.ThreeOfAKind(playerCards);
                    won = CheckPointDifference(pointDifference, points);
                }
                if (won && !winMessage)
                {
                    winMessage = true;
                    Console.WriteLine("You won a Three Of A Kind !!!");
                }

                if (!won)
                {
                    points += VideoPokerGame.TwoPair(playerCards);
                    won = CheckPointDifference(pointDifference, points);
                }
                if (won && !winMessage)
                {
                    winMessage = true;
                    Console.WriteLine("You won a Two Pair !!!");
                }

                if (!won)
                {
                    points += VideoPokerGame.OnePairOfJacksOrBetter(playerCards);
                    won = CheckPointDifference(pointDifference, points);
                }
                if (won && !winMessage)
                {
                    winMessage = true;
                    Console.WriteLine("You won a One Pair Of Jacks Or Better !!!");
                }

                Console.WriteLine($"\nCurrent player points: {points}");
                Console.WriteLine("Want to play the game again y/n");
                playerDesicion = Console.ReadLine();

                if (playerDesicion == "n") gameIsOn = false;
                else {
                    //put discarded cards back to deck for a new game
                    for (int i=0; i < playerCards.Count; i++)
                    {
                        deck.PutCard(playerCards[i]);
                    }
                    deck.Shuffle();
                    playerCards.Clear();
                    cardCounter = -1;
                }

                Console.Clear();
            }          
        }

        static bool CheckPointDifference (int currentPoints, int pointsAfterWinningCheck)
        {
            bool difference = false;

            if (pointsAfterWinningCheck - currentPoints > 0) difference = true;

            return difference;
        }

    }
}
