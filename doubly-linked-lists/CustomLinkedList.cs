using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Matt Izzo, DoublyLinkedList, This is the class for the linkedList
namespace DoublyLinkedLists
{
    class CustomLinkedList<T>
    {
        int count; //The amount of data
        CustomLinkedNode<T> headNode; //The head node
        CustomLinkedNode<T> tailNode; //The tail node

        /// <summary>
        /// Gives the length of the list
        /// </summary>
        public int Count
        {
            get { return count; }
        }

        /// <summary>
        /// The indexer property
        /// </summary>
        /// <param name="index">The desired position</param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                CustomLinkedNode<T> desiredNode = headNode;
                if(index <0 || index > count)
                {
                    throw new IndexOutOfRangeException("This is an invalid index.");
                }
                else
                {
                    for(int i = 0; i < index; i++)
                    {
                        desiredNode = desiredNode.Next;
                    }
                    return desiredNode.Data;
                }
            }
            set
            {
                CustomLinkedNode<T> desiredNode = headNode;
                if (index < 0 || index > count)
                {
                    throw new IndexOutOfRangeException("This is an invalid index.");
                }
                else
                {
                    for (int i = 0; i < index; i++)
                    {
                        desiredNode = desiredNode.Next;
                    }
                    desiredNode.Data = value;
                }
            }
        }


        /// <summary>
        /// The default constructor
        /// </summary>
        public CustomLinkedList()
        {
            headNode = null;
            count = 0;
            tailNode = null;
        }


        /// <summary>
        /// Adds a new item to the list
        /// </summary>
        /// <param name="item">The item being added</param>
        public void Add(T item)
        {
            CustomLinkedNode<T> newNode = new CustomLinkedNode<T>(item);
            if(count > 0)
            {
                tailNode.Next = newNode;
                newNode.Previous = tailNode;
            }
            else
            {
                headNode = newNode;
            }
            tailNode = newNode;
            count++;
        }

        /// <summary>
        /// This inserts an item at a desire position
        /// </summary>
        /// <param name="item">The item beind inserted</param>
        /// <param name="index">The desired position</param>
        public void Insert(T item, int index)
        {
            //This will be the node BEFORE the inserted node
            CustomLinkedNode<T> currentnode = headNode;

            //This checks for an invalid index
            if (index < 0 || index > count +1)
            {
                throw new IndexOutOfRangeException("This is an invalid index.");
            }

            //This handles an empty list
            else if (count == 0)
            {
                CustomLinkedNode<T> newNode = new CustomLinkedNode<T>(item);
                headNode = newNode;
                tailNode = newNode;
            }

            //This handles a new head
            else if (index == 0)
            {
                CustomLinkedNode<T> newNode = new CustomLinkedNode<T>(item, headNode);
                headNode.Previous = newNode;
                headNode = newNode;
            }

            //This handles a new tail
            else if (index == count-1)
            {
                CustomLinkedNode<T> newNode = new CustomLinkedNode<T>(tailNode, item);
                tailNode.Next = newNode;
                tailNode = newNode;
            }

            //This handles an index just after the end of the list
            else if(index == count)
            {
                Add(item);
            }

            //This handles indecies in the middle of the list
            else
            {
                for (int i = 0; i < index; i++)
                {
                    currentnode = currentnode.Next;
                }
                CustomLinkedNode<T> newNode = new CustomLinkedNode<T>(currentnode, item, currentnode.Next);
                currentnode.Next = newNode;
                newNode.Next.Previous = newNode;
            }

            count++;
        }

        /// <summary>
        /// This removes an item from the list and returns the removed item
        /// </summary>
        /// <param name="index">Index of the item being removed</param>
        /// <returns>The removed index</returns>
        public T Remove(int index)
        {
            //This is used to index the list
            CustomLinkedNode<T> currentNode = headNode;
            //This is holds the removed node so it can be returned after it is removed
            CustomLinkedNode<T> returnedNode = null;

            
            //Checks for a valid index
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Sorry but the index " + index + " is out of range");
            }
            //Checks to see if the list has only 1 item
            else if(count == 1)
            {
                returnedNode = headNode;
                headNode = null;
                tailNode = null;
            }
            //Checks for the head
            else if (index == 0)
            {
                returnedNode = headNode;
                headNode = headNode.Next;
                headNode.Previous = null;
            }
            //Checks for the tail
            else if(index == count -1)
            {
                returnedNode = tailNode;
                tailNode = tailNode.Previous;
                tailNode.Next = null;
            }
            //Index is in the middle of the list
            else
            {
                //This handles an index in the first half of the list
                if(index < count / 2)
                {
                    for (int i = 0; i < index; i++)
                    {
                        currentNode = currentNode.Next;
                    }
                    returnedNode = currentNode;
                    currentNode.Next.Previous = currentNode.Previous;
                    currentNode.Previous.Next = currentNode.Next;
                }
                //This handles an index in the second half of the list
                else
                {
                    currentNode = tailNode;
                    for (int i = count; i > index+1; i--)
                    {
                        currentNode = currentNode.Previous;
                    }
                    returnedNode = currentNode;
                    currentNode.Next.Previous = currentNode.Previous;
                    currentNode.Previous.Next = currentNode.Next;
                }
            }

            count--;
            return returnedNode.Data;
        }

        /// <summary>
        /// Clears the list
        /// </summary>
        public void Clear()
        {
            count = 0;
            tailNode = null;
            headNode = null;
        }

        /// <summary>
        /// Prints the list in reverse order
        /// </summary>
        public void PrintReversed()
        {
            CustomLinkedNode<T> currentNode = tailNode;
            for(int i = count - 1; i >= 0; i++)
            {
                Console.WriteLine(currentNode.Data);
                currentNode = currentNode.Previous;
            }
        }

    }
}
