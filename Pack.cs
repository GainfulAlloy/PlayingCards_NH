namespace PlayingCards_NH
{
    internal class Pack
    {

        // create all the cards in this class using this method
        public List<Card> Deck = new List<Card>();


        // in this method, i represents a card in the Deck list, starting from zero
        // if statement is used to change the suit type for the cards in the list. J controls the enum in the Card class.
        public void createPack()
        {
            int j = 0;
            for (int i = 0; i < 52; i++)
            {
                if (i == 13 || i == 26 || i == 39)
                {
                    j++;
                }
                Card.suit suitType = (Card.suit)j;
                int value = i % 13 + 1;
                Deck.Add(new Card(value, suitType));

            }
            Console.WriteLine(Deck.Count + " Cards in the Deck");
        }


        // 3 shuffle types, 1 - Fisher-Yates shuffle, 2 - Riffle Shuffle, 3 - No Shuffle.
        // Fisher-Yates puts all elemnts in a hat and pulls them out till none remain
        // Riffle Shuffle where deck is split in half and the elemnts become interlaped.
        // No shuffle = dont shuffle
        public void shuffleCardPack(int typeOfShuffle)
        {
            if (typeOfShuffle == 1)
            {
                FisherYates();
            }
            if (typeOfShuffle == 2)
            {
                riffleShuffle();
            }
            if (typeOfShuffle == 3)
            {
                noShuffle();
            }
        }



        // Fisher-Yates (Random)
        public void FisherYates()
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
            }
        }

        // riffleShuffle (Here cards from the middle of the deck become interlaped with cards at the front of the deck)
        public void riffleShuffle()
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
        }

        // tells the user no shuffle was done
        public void noShuffle()
        {
            Console.WriteLine("No shuffle:");
        }

        // Method to deal a single card
        public void deal()
        {
            var toRemove = Deck[0];
            Console.WriteLine(toRemove.cardName);
            Deck.RemoveAt(0);
        }

        // calls the deal method multiple times, dealing multiple cards
        public void dealCard(int amount)
        {
            Console.WriteLine("Dealing Cards: ");
            for (int i = 0; i < amount; i++)
            {
                deal();
            }
            Console.WriteLine("Cards left in Deck " + Deck.Count);
        }
    }
}
