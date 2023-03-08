namespace PlayingCards_NH
{
    internal class Pack
    {

        // this is the list of cards to be used for shuffles and dealing
        public static List<Card> Deck = new List<Card>();

        // additional method
        // creates all the cards in a pack in this method
        // in this method, i represents a card in the Deck list, starting from zero
        // if statement is used to change the suit type for the cards in the list. suitNum controls the enum in the Card class.
        public void createPack()
        {
            int suitNum = 0;
            for (int i = 0; i < 52; i++)
            {
                if (i == 13 || i == 26 || i == 39)
                {
                    suitNum++;
                }
                Card.suit suitType = (Card.suit)suitNum;
                int value = i % 13 + 1;
                Deck.Add(new Card(value, suitType));

            }
            Console.WriteLine(Deck.Count + " Cards in the Deck");
        }


        // 3 shuffle types, 1 - Fisher-Yates shuffle, 2 - Riffle Shuffle, 3 - No Shuffle.
        // Fisher-Yates puts all elemnts in a hat and pulls them out till none remain
        // Riffle Shuffle where deck is split in half and the elemnts become interlaped.
        // No shuffle = dont shuffle
        public static bool shuffleCardPack(int typeOfShuffle)
        {
            if (typeOfShuffle == 1)
            {
                return fisherYates();
            }
            if (typeOfShuffle == 2)
            {
                return riffleShuffle();
            }   
            // won't shuffle if number is out of range
            return noShuffle();
        }

        // I consider that these three shuffle methods are additional methods
        // Fisher-Yates (Random)
        public static bool fisherYates()
        {
            // create instance of random
            var rnd = new Random();
            {
                var randomlist = new List<Card>();
                // change order of deck so that cards (a) are randomly selected for the order.
                var random = Deck.OrderBy(a => rnd.Next());

                // fill the empty list with the cards, then save Deck as the new list order
                foreach (var card in random)
                {
                    randomlist.Add(card);
                }
                Deck = randomlist;
                return true;
            }
        }

        // riffleShuffle (Here cards from the middle of the deck become interlaped with cards at the front of the deck)
        public static bool riffleShuffle()
        {
            var mergedList = new List<Card>();
            int halfDeck = Deck.Count / 2;
            int i = 0;
            int firstHalf = 0;
            int secondHalf = Deck.Count / 2;
            for (int count = 0; count < halfDeck; count++)
            {
                // here i is the list position to insert into,
                // firstHalf and secondHalf are used to find the Deck's list position to take from.
                mergedList.Insert(i, Deck[firstHalf]);
                i++;
                firstHalf++;
                mergedList.Insert(i, Deck[secondHalf]);
                i++;
                secondHalf++;
            }
            // save the shuffle to the orignal deck 
            Deck = mergedList;
            return true;
        }

        // tells the user no shuffle was done
        public static bool noShuffle()
        {
            Console.WriteLine("No shuffle:");
            return true;
        }

        // Method to deal a single card
        public static Card deal()
        {
            var toRemove = Deck[0];
            Console.WriteLine(toRemove.cardName);
            Deck.RemoveAt(0);
            return toRemove;
        }

        // calls the deal method multiple times, dealing multiple cards
        // saves the dealt cards to a new list of dealt cards.
        public static List<Card> dealCard(int amount)
        {
            var dealtCards = new List<Card>();
            Console.WriteLine("Dealing Cards: ");
            for (int i = 0; i < amount; i++)
            {
                var toRemove = deal();
                dealtCards.Add(toRemove);
            }
            Console.WriteLine("Cards left in Deck " + Deck.Count);
            return dealtCards;
        }
    }
}
