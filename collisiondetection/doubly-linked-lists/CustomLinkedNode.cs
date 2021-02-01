using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Matt Izzo, DoublyLinkedList, This class is the nodes that the linkedList will hold
namespace DoublyLinkedLists
{
    class CustomLinkedNode<T>
    {

        CustomLinkedNode<T> previous; //This is the link to the previous node
        T data; //This is the data it will hold
        CustomLinkedNode<T> next; //This is the link to the next node


        /// <summary>
        /// This allows access to the previous node
        /// </summary>
        public CustomLinkedNode<T> Previous
        {
            get { return previous; }
            set { previous = value; }
        }

        /// <summary>
        /// This allows access to the data
        /// </summary>
        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        /// <summary>
        /// This allows access to the next node
        /// </summary>
        public CustomLinkedNode<T> Next
        {
            get { return next; }
            set { next = value; }
        }

        /// <summary>
        /// Creates a node with just the data
        /// </summary>
        /// <param name="data">The data in the node</param>
        public CustomLinkedNode(T data)
        {
            this.previous = null;
            this.data = data;
            this.next = null;
        }

        /// <summary>
        /// Creates a linked node that only links to the previous node (Only used for tail nodes)
        /// </summary>
        /// <param name="data">The data of the node</param>
        public CustomLinkedNode(CustomLinkedNode<T> previous, T data)
        {
            this.previous = previous;
            this.data = data;
            this.next = null;
        }

        /// <summary>
        /// This creates a linked node with two links
        /// </summary>
        /// <param name="previous">Links to the node before it</param>
        /// <param name="data">The data being held</param>
        /// <param name="next">Links to the node next to it</param>
        public CustomLinkedNode(CustomLinkedNode<T> previous, T data, CustomLinkedNode<T> next)
        {
            this.previous = previous;
            this.data = data;
            this.next = next;
        }

        /// <summary>
        /// This creates a linked node that only links to the next node (Only used for head nodes)
        /// </summary>
        /// <param name="data">The data being held by the node</param>
        /// <param name="next">Links to the next node</param>
        public CustomLinkedNode(T data, CustomLinkedNode<T> next)
        {
            this.previous = null;
            this.data = data;
            this.next = next;
        }

    }
}