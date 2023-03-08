namespace PlayingCards_NH
{
    internal class Pack
    {

        // create all the cards in this class using this method
        public List<Card> Deck = new List<Card>();


        // in this method, i represents an item in a list, starting from zero
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
        // Riffle Shuffle where deck is split in half and the elemnts become interleved.
        // No shuffle = dont shuffle
        public void shuffleCardPack(int typeOfShuffle)
        {
            var rnd = new Random();
            // Fisher-Yates (Random)
            if (typeOfShuffle == 1)
            {
                var randomList = new List<Card>();
                var random = Deck.OrderBy(a => rnd.Next());
                foreach (var card in random) 
                { 
                    randomList.Add(card);
                }
                Deck = randomList;
            }
            // Riffle         
            if (typeOfShuffle == 2)
            {
                var firstHalf = new List<Card>();
                var secondHalf = new List<Card>();
                var mergedList = new List<Card>();
                int deckSize = Deck.Count;
                int count = 0;
                int i = 0;
                int j = 0;
                // splits deck in half into two lists
                foreach (Card card in this.Deck)
                {
                    if (count < deckSize / 2)
                    {
                        firstHalf.Add(card);
                    }
                    else
                    {
                        secondHalf.Add(card);
                    }
                    count++;
                }
                // create a new list by inserting one element from each of the split lists at a time
                foreach (Card card in firstHalf)
                {
                    mergedList.Insert(i, card);
                    i++;
                    mergedList.Insert(i, secondHalf[j]);
                    i++;
                    j++;
                }
                // save the shuffle to the orignal list (Deck) 
                Deck = mergedList;

                // Doesn't shuffle.
                if (typeOfShuffle == 3)
                {
                    Console.WriteLine("no shuffle");
                }
            }
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
