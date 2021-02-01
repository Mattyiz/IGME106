using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Matt Izzo, CustomLinkedList, This will create the linked list and allow the used to use it
namespace DoublyLinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter one of these specific keywords: Q/Quit, Print, Count, Clear, Remove, Reverse, Scramble");
            Console.WriteLine("Anything that does not match a keyword will be added to the list.");

            CustomLinkedList<string> linkedList = new CustomLinkedList<string>();
            string command = "";
            Random ran = new Random();

            while (true)
            {
                Console.Write(">> ");
                command = Console.ReadLine().ToLower();

                Console.WriteLine("");

                //Handles exiting the loop
                if (command.Equals("q") || command.Equals("quit"))
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                //Handles the print command
                else if (command.Equals("print"))
                {
                    for (int i = 0; i < linkedList.Count; i++)
                    {
                        Console.WriteLine(linkedList[i]);
                    }
                }
                //Handles the count command
                else if (command.Equals("count"))
                {
                    Console.WriteLine("There are " + linkedList.Count + " items in the list");
                }
                //Handles the clear command
                else if (command.Equals("clear"))
                {
                    linkedList.Clear();
                    Console.WriteLine("The list has been cleared");
                }
                //Handles the remove command
                else if (command.Equals("remove"))
                {
                    int removedIndex = ran.Next(0, linkedList.Count-1);
                    Console.WriteLine(linkedList.Remove(removedIndex) +  " has been removed from position " + removedIndex);
                }
                //Handles the reverse command
                else if (command.Equals("reverse"))
                {
                    linkedList.PrintReversed();
                }
                else if (command.Equals("scramble"))
                {
                    int removedIndex = ran.Next(0, linkedList.Count -1);
                    int addedIndex = ran.Next(0, linkedList.Count -1);
                    string removedValue = linkedList.Remove(removedIndex);
                    linkedList.Insert(removedValue, addedIndex);
                    Console.WriteLine(removedValue + " has been removed from position " + removedIndex + " and added to position " + (addedIndex + 1));
                }
                //Handles adding to the list
                else
                {
                    linkedList.Add(command);
                }



                Console.WriteLine("");

            }

            Console.ReadLine();
        }
    }
}
