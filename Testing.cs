using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCards_NH
{
    internal class Testing
    {
        public Testing() 
        {
      
        }
        // used to test the program
        public void testing() 
        { 
            try 
            { 
                // allows user input to test different features
                Pack newPack  = new Pack();
                newPack.createPack();
                Console.WriteLine("Select a shuffle method:");
                Console.WriteLine(" 1 = Fisher-Yates Shuffle");
                Console.WriteLine(" 2 = Riffle Shuffle");
                Console.WriteLine(" 3 = No shuffle");
                int shuffleType = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("How many cards do you want to deal?");
                int dealCount = Convert.ToInt32(Console.ReadLine());

                // performs the users selection
                var shuffleSelect = Pack.shuffleCardPack(shuffleType);               
                var cardsDealt = Pack.dealCard(dealCount);
            } 
            
            // error catches
            // catch wrong data type errors
            catch (System.FormatException) 
            {
                Console.WriteLine("Please type in an integer");                      
            }
            // catch errors for the number of cards to deal being larger then the list
            catch (System.ArgumentOutOfRangeException)
            {
                Console.WriteLine("Number entered was higher then cards left in the deck, all remaining cards were dealt");
            }   
            // catch errors when too many numbers are typed in one input box
            catch (System.OverflowException) 
            {
                Console.WriteLine("Value too large, please use a smaller number");
            }
        }               
    }
}
