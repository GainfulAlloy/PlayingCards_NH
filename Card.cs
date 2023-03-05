using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCards_NH
{
    internal class Card
    {
        // playing card info:
        // 13 of each Suit (4x13)
        // Suits: 1 - Diamonds (Red), 2 - clubs (black), 3 - hearts (red), 4 - spades (black)
        // Values: (assceniding order): ace, 2, 3, 4, 5, 6, 7, 8, 9, 10, joker, queen, king


        // for this there should be the actual values of the card and the strings are used to change the name of how it looks when printed
        public int value;
        

        // enum is used to assign strings to integers 
        public enum suit
        {
            Diamonds = 0,
            Clubs,
            Hearts,
            Spades
        }
        public suit suitType
        {
            get; 
            set;
        }


        public Card(int aValue, suit suitType)
        {
            value = aValue;
            this.suitType = suitType;
        }

        public string valueType
        {
            get
            {
                string type = string.Empty;
                switch(value)
                {
                    case (1):
                        type = "Ace";
                        break;
                    case (11):
                        type = "Jack";
                        break;
                    case (12):
                        type = "Queen";
                        break;
                    case (13):
                        type = "King";
                        break;
                    default:
                        type = value.ToString(); 
                        break;
                        
                }
                return type;
            }
        }
        public string cardName
        {
            get
            {
                return valueType + " of " + suitType.ToString();
            }
        }

        // try using gets and sets as well as a switch.
        // use a swtich in a method to assign suits or higher values to the cards
    }
}
