using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Play20Q class
// Description: Plays a single game of 20Qs.

namespace Wan_20Qs {
    class Play20Q {
        // private field that contains the string for user input
        private string answer;

        // public constructor for the Play20Q class
        public Play20Q() {
            answer = null;
        }

        // Name: PlayOneRound()
        // Params: a BinSearchTree object
        // Returns: none
        // Purpose: plays one round of 20Qs by asking if the person the user is thinking of has a specific characteristic,
        // then tries to guess the person after narrowing down the characteristics using LearnsNew()
        public void PlayOneRound(BinSearchTree bst) {
            // start at the root
            Node temp = bst.Root;

            // while we're not at a leaf node
            while (temp.YesPtr != null && temp.NoPtr != null) {
                // ask the node's question and get the answer
                Console.Write("Is this person " + temp.Question + "? ");
                answer = Console.ReadLine();

                // based on the answer, follow either Y/N pointer
                if (answer.ToUpper() == "Y") {
                    temp = temp.YesPtr;
                }

                else {
                    temp = temp.NoPtr;
                }
            }

            // program tries to guess the person 
            Console.Write("Is it " +  temp.Question + "? ");
            answer = Console.ReadLine();

            // if the guess is correct, the program wins
            if (answer.ToUpper() == "Y") {
                Console.WriteLine("Hurray! I win!");
            }
            // else the program asks who it was and how to tell the difference
            else {
                LearnNew(temp);
            }
        }

        // Name: LearnNew()
        // Params: a node
        // Returns: none
        // Description: learns a new name by asking the use who it is and puts the new person and the differentiating 
        // characteristic as new nodes in the tree.
        public void LearnNew(Node temp) {
            Console.Write("I give up. Who is it? ");
            answer = Console.ReadLine();
        
            // add the person as a new leaf node
            Node newAnswer = new Node(answer); // bob dylan node
            // copies the data from the temp node to a new node
            Node originalAnswer = new Node(temp.Question); // node for NoPtr (bill gates)
        
            // ask for the difference between the two people
            Console.Write("What is " + newAnswer.Question + " that " + temp.Question + " isn't? ");
            string diff = Console.ReadLine();

            // sets the value of the temp node to be the characteristic that differentiates two people
            temp.Question = diff;
            // set the value of the yes pointer to be the new person and the no pointer to be the original answer/person
            temp.YesPtr = newAnswer;
            temp.NoPtr = originalAnswer;

            Console.WriteLine("I love to learn new people!");
        }
    }
}
