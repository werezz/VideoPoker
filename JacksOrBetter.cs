using System.Collections.Generic;


namespace CardGame
{

    class JacksOrBetter
    {
        public JacksOrBetter() { }

        //Constants for calculating logic
        private const int FlushPair = 10;
        private const int StraightPair = 4;
        private const int FourPair = 6;
        private const int ThreeAndTwoPair = 4;
        private const int ThreePair = 3;
        private const int TwoPairConst = 2;
        private const int OnePair = 1;

        public int RoyalFlush( List<Card> playersHand)
        {
            int winnings = 0;
            bool sameSuit = false;
            bool highValue = false;

            List<string> suits = new List<string>();
            List<int> values = new List<int>();

            suits = CardSuits(playersHand);
            values = CardValues(playersHand);
            values.Sort();
            values.Reverse();
            suits.Sort();
            suits.Reverse();


            sameSuit = CheckFlush(suits);
            highValue = CheckStraight(values);

            if (sameSuit == true && highValue == true && values[0]== 14) winnings += 800;

            return winnings;
        }

        public int StraightFlush (List<Card> playersHand)
        {
            int winnings = 0;
            bool sameSuit = false;
            bool highValue = false;

            List<string> suits = new List<string>();
            List<int> values = new List<int>();

            suits = CardSuits(playersHand);
            values = CardValues(playersHand);
            values.Sort();
            values.Reverse();
            suits.Sort();
            suits.Reverse();


            sameSuit = CheckFlush(suits);
            highValue = CheckStraight(values);

            if (sameSuit == true && highValue == true) winnings += 50;

            return winnings;
        }

        public int FourOfAKind (List<Card> playersHand)
        {
            int winnings = 0;
            bool fourPairValue = false;

            List<int> values = new List<int>();

            values = CardValues(playersHand);
            values.Sort();
            values.Reverse();

            fourPairValue = CheckValuePairs(values,FourPair);

            if (fourPairValue == true) winnings += 40;

            return winnings;
        }

        public int FullHouse (List<Card> playersHand)
        {
            int winnings = 0;
            bool threeAndTwoPairValue = false;

            List<int> values = new List<int>();

            values = CardValues(playersHand);
            values.Sort();
            values.Reverse();

            threeAndTwoPairValue = CheckValuePairs(values, ThreeAndTwoPair);

            if (threeAndTwoPairValue == true) winnings += 10;

            return winnings;
        }

        public int Flush(List<Card> playersHand)
        {
            int winnings = 0;
            bool flush = false;

            List<string> suits = new List<string>();

            suits = CardSuits(playersHand);
            suits.Sort();
            suits.Reverse();

            flush = CheckFlush(suits);

            if (flush == true) winnings += 7;

            return winnings;
        }

        public int Straight(List<Card> playersHand)
        {
            int winnings = 0;
            bool straight = false;

            List<int> values = new List<int>();

            values = CardValues(playersHand);
            values.Sort();
            values.Reverse();

            straight = CheckStraight(values);

            if (straight == true) winnings += 5;

            return winnings;
        }

        public int ThreeOfAKind(List<Card> playersHand)
        {
            int winnings = 0;
            bool threeValue = false;

            List<int> values = new List<int>();

            values = CardValues(playersHand);
            values.Sort();
            values.Reverse();

            threeValue = CheckValuePairs(values, ThreePair);

            if (threeValue == true) winnings += 3;

            return winnings;
        }

        public int TwoPair(List<Card> playersHand)
        {
            int winnings = 0;
            bool twoValue = false;

            List<int> values = new List<int>();

            values = CardValues(playersHand);
            values.Sort();
            values.Reverse();

            twoValue = CheckValuePairs(values, TwoPairConst);

            if (twoValue == true) winnings += 2;

            return winnings;
        }

        public int OnePairOfJacksOrBetter(List<Card> playersHand)
        {
            int winnings = 0;
            bool oneValue = false;

            List<int> values = new List<int>();

            values = CardValues(playersHand);
            values.Sort();
            values.Reverse();

            oneValue = CheckJackOrBetter(values, OnePair);

            if (oneValue == true) winnings += 1;

            return winnings;
        }

        private bool CheckJackOrBetter (List <int> cardValues, int cardPairs)
        {
            bool pair = false;
            int counter = 0;

            for (int i = 0; i < cardValues.Count - 1; i++)
            {
                for (int b = i; b < cardValues.Count - 1; b++)
                {
                    if ((cardValues[i] == cardValues[b + 1])  && (cardValues[i] >= 11)) counter += 1;
                }
            }

            if (counter >= cardPairs) pair = true;
            return pair;
        }

        private bool CheckValuePairs (List<int> cardValues, int cardPairs)
        {
            bool pair = false;
            int counter = 0;

            for (int i = 0; i < cardValues.Count - 1; i++)
            {
                for (int b = i; b < cardValues.Count - 1; b++)
                {
                    if (cardValues[i] == cardValues[b + 1]) counter += 1;
                }
            }

            if (counter == cardPairs) pair = true;
            return pair;
        }

        private bool CheckFlush(List<string> cardSuits)
        {
            bool flush = false;
            int counter = 0;

            for (int i = 0; i < cardSuits.Count - 1; i++)
            {
                for (int b = i; b < cardSuits.Count - 1; b++)
                {
                    if (cardSuits[i] == cardSuits[b + 1]) counter += 1;
                }
            }

            if (counter == FlushPair) flush = true;
            return flush;
        }

        private bool CheckStraight(List<int> cardValues)
        {
            bool straight = false;
            int counter = 0;

            for(int i=0; i< cardValues.Count-1; i++)
            {
                if (cardValues[i] == cardValues[i + 1] + 1) counter += 1;
            }

            if (counter == StraightPair) straight = true;
            return straight;
        }

        //Check players hand card suits
        private List<string> CardSuits (List<Card> playersCards)
        {
            List<string> suits = new List<string>();

            for(int i=0; i<playersCards.Count; i++)
            {
                if(playersCards[i].DisplayName.Length == 2)
                {
                    suits.Add(playersCards[i].DisplayName.Substring(1, 1));
                }
                else
                {
                    suits.Add(playersCards[i].DisplayName.Substring(2, 1));
                }
            }

            return suits;
        }
        
        //Check players hand card values
        private List<int> CardValues(List<Card> playersCards)
        {
            List<int> values = new List<int>();

            for (int i = 0; i < playersCards.Count; i++)
            {
                values.Add(playersCards[i].Value);
            }

            return values;
        }
    }
}
