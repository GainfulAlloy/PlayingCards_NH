using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCards_NH
{
    internal class Testing
    {

        bool codeExecuting = true;
        public Testing() 
        {
      
        }
        public void testing() 
        { 
            try 
            { 
                Pack newPack  = new Pack();
                newPack.createPack();
                Console.WriteLine("Select a shuffle method:");
                Console.WriteLine(" 1 = Fisher-Yates Shuffle");
                Console.WriteLine(" 2 = Riffle Shuffle");
                Console.WriteLine(" 3 = No shuffle");
                int shuffleType = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("How many cards do you want to deal?");
                int dealCount = Convert.ToInt32(Console.ReadLine());
                newPack.shuffleCardPack(shuffleType);
                newPack.dealCard(dealCount);


            } 
            catch (System.FormatException) 
            {
                Console.WriteLine("Please type in an integer");
                       
            }
            catch (System.ArgumentOutOfRangeException)
            {
                Console.WriteLine("Number entered was higher then cards left in the deck");
            }
            // in case of any non accounted for errors
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        
        }
        
        
    }
}
