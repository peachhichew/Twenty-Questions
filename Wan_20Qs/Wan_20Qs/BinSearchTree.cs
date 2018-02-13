using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// BinSearchTree class
// Description: Contains private fields and functions that use a preorder traversal to traverse through
// the 20 Questions tree and writes/reads the answers to/from a text file.

namespace Wan_20Qs {
    class BinSearchTree {
        // private field for the root Node, StreamReader, and StreamWriter
        private Node root;
        private StreamWriter writeTree = null;
        private StreamReader readTree = null;

        // getter for the root
        public Node Root {
            get { return root; }
        }

        // public constructor for the BinSearchTree class
        public BinSearchTree() {
            root = null;
        }

        // Name: Hardwire()
        // Params: none
        // Returns: none
        // Purpose: creates an interior node with two leaf nodes to test the Node class and prints out
        // their values
        public void Hardwire() {
            // testing the Node class
            root = new Node("living");
            root.YesPtr = new Node("Bill Gates");
            root.NoPtr = new Node("Chet Carlson");
            Console.WriteLine(root.Question);
            Console.WriteLine(root.YesPtr.Question);
            Console.WriteLine(root.NoPtr.Question);
        }

        // Name: SaveTheTree()
        // Params: none
        // Returns: none
        // Purpose: uses a Streamwriter to write the data from the nodes to a text file and also calls 
        // the WritePreOrder() function to check whether the node is an interior or leaf node.
        public void SaveTheTree() {
            try {
                writeTree = new StreamWriter("20QTree.txt");
                WritePreOrder(root);
            }

            catch (Exception e) {
                Console.WriteLine("Error: " + e.Message);
            }

            finally {
                writeTree.Close();
            }
        }

        // Name: WritePreOrder()
        // Params: a Node
        // Returns: none
        // Purpose: takes a node and checks whether or not it's an interior or leaf node. If it's an interior 
        // node, print out the node's value with an I in front and an L in front of a leaf node. 
        public void WritePreOrder(Node n) {
            // if n is an interior node, write L in front of the node's value
            if (n.YesPtr == null && n.NoPtr == null) {
                writeTree.WriteLine("L" + n.Question);
            }

            // else n must be an interior node and write I in front of the node's value
            else {
                writeTree.WriteLine("I" + n.Question);
                // recursively call this function again to check for the Y/N pointers for the node and print
                // "I" in front of the nodes' values
                WritePreOrder(n.YesPtr);
                WritePreOrder(n.NoPtr);
            }
        }

        // Name: ReadTheTree()
        // Params: none
        // Returns: none
        // Purpose: uses a StreamReader to read from a text file and sets the root node to be the node
        // returned from the ReadPreOrder() method
        public void ReadTheTree() {
            try {
                readTree = new StreamReader("20QTree.txt");
                root = ReadPreOrder();
            }

            catch (Exception e) {
                Console.WriteLine("Error: " + e.Message);
            }

            finally {
                if (readTree != null) {
                    readTree.Close();
                }
            }
        }

        // Name: ReadPreOrder()
        // Params: none
        // Returns: none
        // Purpose: reads each line from the text file and removes the first character from each line. Then, put the 
        // string as the value for a new node and recursively call the method again if the node is an interior node.
        public Node ReadPreOrder() {
            // read line from file
            string line = readTree.ReadLine();
            // create a new node and its value will be the line with the first character removed
            Node n = new Node(line.Substring(1));

            // if the line has an "i" in front of it, it's an interior node
            // the Y/N pointers will be the node that is returned from calling the method recursively
            if (line[0] == 'I') {
                n.YesPtr = ReadPreOrder();
                n.NoPtr = ReadPreOrder();
            }

            return n;
        }
    }
}
