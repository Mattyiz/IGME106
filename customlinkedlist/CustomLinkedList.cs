using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Matt Izzo, CustomLinkedList, This is the class for the linkedList
namespace CustomLinkedList
{
    class CustomLinkedList <T>
    {

        int count; //The amount of data
        CustomLinkedNode<T> headNode; //The head node
        CustomLinkedNode<T> tailNode; //The tail node

        /// <summary>
        /// This allows access to the count
        /// </summary>
        public int Count
        {
            get { return count; }
        }

        /// <summary>
        /// This creates the linked list
        /// </summary>
        /// <param name="headNode">The first node</param>
        public CustomLinkedList(CustomLinkedNode<T> headNode)
        {
            this.headNode = headNode;
            count = 1;
            tailNode = headNode;
        }

        /// <summary>
        /// This adds to the linked list
        /// </summary>
        /// <param name="data">The data that is added</param>
        public void Add(T data)
        {
            CustomLinkedNode<T> linkedNode = new CustomLinkedNode<T>(data, null);
            tailNode.LinkedNode = linkedNode;
            tailNode = linkedNode;
            count++;
        }

        /// <summary>
        /// This returns the data of a node
        /// </summary>
        /// <param name="index">The index in the list where the node is</param>
        /// <returns></returns>
        public T GetData(int index)
        {
            CustomLinkedNode<T> currentNode = headNode;

            //Checks for head
            if(index == 0)
            {
                return currentNode.Data;
            }
            //Checks for invalid index
            else if(index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Sorry but this is out of the range of the list");
            }

            //Getting data from the middle
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.LinkedNode;
            }
            return currentNode.Data;
        }


        /// <summary>
        /// Removes values from the list
        /// </summary>
        /// <param name="index">The index of the removed value</param>
        /// <returns></returns>
        public T Remove(int index)
        {
            CustomLinkedNode<T> currentNode = headNode;
            CustomLinkedNode<T> returnedNode = null;

            //Checks for the head
            if (index == 0)
            {
                returnedNode = headNode;
                headNode = currentNode.LinkedNode;
                count--;
                return returnedNode.Data;
            }
            //Checks for a valid index
            else if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Sorry but the index " + index + " is out of range");
            }

            for (int i = 0; i < index -1; i++)
            {
                currentNode = currentNode.LinkedNode;
            }

            //Checks for the tail
            if (index == count - 1)
            {
                returnedNode = tailNode;
                currentNode.LinkedNode = null;
                tailNode = currentNode;
                count--;
                return returnedNode.Data;
            }

            returnedNode = currentNode;
            currentNode.LinkedNode = currentNode.LinkedNode.LinkedNode;
            count--;

            return returnedNode.Data;
        }

    }
}
