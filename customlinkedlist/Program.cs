using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Matt Izzo, CustomLinkedList, This will create the linked list and add stuff to it
namespace CustomLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            //This is the initial peice of data, it creates the class
            Console.Write("Enter a piece of data >> ");
            string data = Console.ReadLine();

            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(new CustomLinkedNode<string>(data));


            //This adds the other 5 inputs to the LinkedList
            while (linkedList.Count < 6)
            {
                Console.Write("Enter a piece of data >> ");
                data = Console.ReadLine();

                linkedList.Add(data);
            }

            //Spacing stuff
            Console.WriteLine("");
            Console.WriteLine("Here is your list:");


            //This will go through and print the LinkedList
            for(int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList.GetData(i));
            }

            //Spacing
            Console.WriteLine("");
            Console.WriteLine("These are the indecies that will be removed: -7, 5, 0, and 2");

            //Checking to see the error message works
            try{
                linkedList.Remove(-7);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Removing the head, tail, and then a random one
            linkedList.Remove(linkedList.Count - 1);
            linkedList.Remove(0);
            linkedList.Remove(2);

            //Spacing
            Console.WriteLine("");
            Console.WriteLine("Here is what is left of the list:");

            //Reprinting the list
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList.GetData(i));
            }

            Console.ReadLine();
        }
    }
}
