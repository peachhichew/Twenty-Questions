using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wan_20Qs {
    class Node {
        // private fields for the node's string, yes, and no pointers
        private string question = null;
        private Node yesPtr = null;
        private Node noPtr = null;

        // get and set properties for the private fields above
        public string Question {
            get { return question; }
            set { question = value; }
        }

        public Node YesPtr {
            get { return yesPtr; }
            set { yesPtr = value; }
        }

        public Node NoPtr {
            get { return noPtr; }
            set { noPtr = value; }
        }

        // public constructor for the Node class that takes one parameter, which is the Node's string
        public Node(string p_question) {
            question = p_question;
        }
    }
}
