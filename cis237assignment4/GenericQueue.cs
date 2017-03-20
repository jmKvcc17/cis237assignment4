using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    // Generic queue class, takes in all droids as data
    class GenericQueue<T>
    {
        protected class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
        }

        protected Node _firstNode;
        protected Node _lastNode;
        protected int _nodeSize;

        // checks if queue is empty
        public bool IsEmpty
        {
            get
            {
                return _firstNode == null;
            }

        }

        // returns the size of the queue
        public int Size
        {
            get { return _nodeSize; }
        }

        // Adds the droid to the front of the 
        // queue
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

        // Removes droid from the front of the
        // queue
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
