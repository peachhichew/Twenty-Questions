using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// Name: Sky Wan
// Date: 09/15/17
// Description: Simulates a game of 20Qs by reading and writing to a text file. The program wins if it correctly guesses the person 
// the user is thinking of. User wins if the program fails to correctly guess the person.

namespace Wan_20Qs {
    class Program {
        static void Main(string[] args) {
            BinSearchTree bst = new BinSearchTree();
            Play20Q play = new Play20Q();

            // testing the Hardwire function from the bst class
            //bst.Hardwire();

            // read the tree from a text file
            bst.ReadTheTree();

            // playing a single game of 20Qs
            string answer;
            Console.WriteLine("Welcome to 20 questions! I'll try to guess your person.");

            do {
                Console.WriteLine();
                play.PlayOneRound(bst);
            
                Console.Write("\nHow about another game? ");
                answer = Console.ReadLine();
            } while (answer.Equals("y")); // repeatedly checks if the user enters "y" and plays another round if he/she does

            // saves the names/characteristics to a text file
            bst.SaveTheTree();

            Console.WriteLine();
            Console.WriteLine("Thanks for playing!");
        }
    }
}
