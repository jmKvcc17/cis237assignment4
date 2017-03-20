using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    // Generic stack class, can be defined
    // to accept protocl, utility, astromech
    // or janitor
    class GenericStack<T>
    {
        protected class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
        }

        protected Node _firstNode;
        protected Node _lastNode;
        protected int _nodeSize;

        // Used to determine if node is empty
        public bool IsEmpty
        {
            get
            {
                return _firstNode == null;
            }

        }

        // Returns the size of the stack
        public int Size
        {
            get { return _nodeSize; }
        }

        // Adds a droid to the front of the stack
        public void AddToFront(T data)
        {
            Node oldHead = _firstNode;

            _firstNode = new Node();
            _firstNode.Data = data;
            _firstNode.Next = oldHead;
            _nodeSize++;

            if (_nodeSize == 1)
                _lastNode = _firstNode;
        }

        // Removes a droid from the front of
        // the stack
        public T RemoveFromFront()
        {
            if (IsEmpty)
            {
                throw new Exception("List is empty.");
            }

            T returnData = _firstNode.Data;

            _firstNode = _firstNode.Next;

            _nodeSize--;

            if (IsEmpty)
                _lastNode = null;

            return returnData;
        }
        

    }
}
