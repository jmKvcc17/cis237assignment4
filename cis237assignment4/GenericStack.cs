using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
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

        public bool IsEmpty
        {
            get
            {
                return _firstNode == null;
            }

        }

        public int Size
        {
            get { return _nodeSize; }
        }

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

        public void AddToBack(T data)
        {
            Node oldTail = _lastNode;
            _lastNode = new Node();

            _lastNode.Data = data;
            _lastNode.Next = null;

            if (IsEmpty)
                _firstNode = _lastNode;
            else
                oldTail.Next = _lastNode;

            _nodeSize++;
        }

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

        public T RemoveFromBack()
        {
            if (IsEmpty)
                throw new Exception("List is empty");

            T returnData = _lastNode.Data;

            if (_firstNode == _lastNode)
            {
                _firstNode = null;
                _lastNode = null;
            }
            else
            {
                Node current = _firstNode;

                while (current.Next != _lastNode)
                {
                    current = current.Next;
                }

                _lastNode = current;

                _lastNode.Next = null;
            }

            return returnData;
        }

        public void Display()
        {
            Console.WriteLine("The list is: ");

            Node currentNode = _firstNode;

            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Data);
                currentNode = currentNode.Next;
            }

            Console.WriteLine();
        }

    }
}
