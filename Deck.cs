using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    public enum Suit
    {
        Clubs,
        Diamonds,
        Spades,
        Hearts
    }

    class Deck
    {
        public List<Card> Cards;
        int cardCount = 52;

        //Creates a deck
        public Deck()
        {
            Cards = new List<Card>();

            for (int i = 2; i <= 14; i++)
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    Cards.Add(new Card()
                    {
                        Suit = suit,
                        Value = i,
                        DisplayName = GetShortName(i, suit)
                    });
                }
            }
        }

        private static string GetShortName(int value, Suit suit)
        {
            string valueDisplay = "";

            if (value >= 2 && value <= 10)
            {
                valueDisplay = value.ToString();
            }
            else if (value == 11)
            {
                valueDisplay = "J";
            }
            else if (value == 12)
            {
                valueDisplay = "Q";
            }
            else if (value == 13)
            {
                valueDisplay = "K";
            }
            else if (value == 14)
            {
                valueDisplay = "A";
            }

            return valueDisplay + Enum.GetName(typeof(Suit), suit)[0];
        }

        //TODO make random order for Cards
        public void Shuffle()
        {
            //Shuffle the existing cards using Fisher-Yates Modern
            List<Card> transformedCards = Cards;
            Random r = new Random(DateTime.Now.Millisecond);
            for (int n = transformedCards.Count - 1; n > 0; --n)
            {
                //Step 2: Randomly pick a card which has not been shuffled
                int k = r.Next(n + 1);

                //Step 3: Swap the selected item with the last "unselected" card in the collection
                Card temp = transformedCards[n];
                transformedCards[n] = transformedCards[k];
                transformedCards[k] = temp;
            }

            List<Card> shuffledCards = new List<Card>();
            foreach (var card in transformedCards)
            {
                shuffledCards.Add(card);
            }

        }

        //TODO get last card and remove it from deck
        public Card GetCard()
        {
            var lastCard = Cards.Last();

            Cards.RemoveAt(Cards.Count - 1);

            return lastCard;
        }

        public void PutCard(Card card)
        {
            Cards.Add(card);
        }

        public int CardsInDeckCount()
        {
            return Cards.Count;
        }

        public int CardsOutDeckCount()
        {
            return cardCount - Cards.Count;
        }

        public string MaxCardValueInDeck()
        {
            string biggestCards = "";

            for (int i = 14; i > 2; i--)
            {
                var maxCards = (from a in Cards where a.Value == i select a).ToList();

                if (maxCards != null)
                {
                    for (int j = maxCards.Count - 1; j >= 0; j--)
                    {
                        biggestCards = biggestCards + " " + maxCards[j].DisplayName;
                    }
                    return biggestCards;
                }
            }

            return "Empty";
        }
    }
}
