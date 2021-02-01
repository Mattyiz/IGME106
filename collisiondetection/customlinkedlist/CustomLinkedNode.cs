using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Matt Izzo, CustomLinkedList, This class is the nodes that the linkedList will hold
namespace CustomLinkedList
{
    class CustomLinkedNode<T>
    {

        T data; //This is the data it will hold
        CustomLinkedNode<T> linkedNode; //This is the link to the next node, I think

        /// <summary>
        /// This allows access to the data
        /// </summary>
        public T Data
        {
            get { return data; }
        }

        /// <summary>
        /// This allows access to the linkedNode, also it allows the linkedNode to be altered
        /// </summary>
        public CustomLinkedNode<T> LinkedNode
        {
            get { return linkedNode; }
            set { linkedNode = value; }
        }

        /// <summary>
        /// Creates a linked node with a null linkedNode
        /// </summary>
        /// <param name="data">The data of the node</param>
        public CustomLinkedNode(T data)
        {
            this.data = data;
            this.linkedNode = null;
        }

        /// <summary>
        /// This creates the linked node
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="linkedNode">The node it linkes to</param>
        public CustomLinkedNode(T data, CustomLinkedNode<T> linkedNode)
        {
            this.data = data;
            this.linkedNode = linkedNode;
        }

    }
}
