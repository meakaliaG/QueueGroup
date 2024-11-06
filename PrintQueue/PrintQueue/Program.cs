using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    // Print Queue
    static Queue<string> printQueue = new Queue<string>();

    static void Main()
    {


        // Add documents to print queue
        printQueue.Enqueue("Document1");
        printQueue.Enqueue("Document2");
        printQueue.Enqueue("Document3");

        Console.WriteLine("Welcome to the Print Queue!");
        string userInput = "";

        while (userInput.ToLower() != "quit")
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("Options:\n- 'add' -Add a document to the print queue.\n- 'print' -Print the next document in the queue.\n- 'view' -View the current queue status.\n-'remove' -Remove a specific document from the queue.\n-'Quit' - End program.");
            Console.WriteLine("Please enter your choice: ");
            userInput = Console.ReadLine();

            userInput = userInput.ToLower();

            if (userInput == "add")
            {
                AddDoc();
            }
            else if (userInput == "print")
            {
                PrintDoc();   
            }
            else if (userInput == "view")
            {
                ViewQueue();
            }
            else if (userInput == "remove")
            {
                RemoveDoc();
            }
            else if (userInput == "quit")
            {
                Console.WriteLine("Exiting the program.");
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }

        }
        static void AddDoc()
        {
            Console.WriteLine("Enter the name of the document to add: ");
            string doc = Console.ReadLine();
            printQueue.Enqueue(doc);
            Console.WriteLine($"Document '{doc}' added to the queue.");
        }

        static void PrintDoc()
        {
            if (printQueue.Count > 0)
            {
                string printedDoc = printQueue.Dequeue();
                Console.WriteLine($"Printing: {printedDoc}");
            }
            else
            {
                Console.WriteLine("The print queue is empty.");
            }
        }

        static void ViewQueue()
        {
            Console.WriteLine("Current Print Queue:");
            if (printQueue.Count > 0)
            {
                foreach (string item in printQueue)
                {
                    Console.WriteLine($"- {item}");
                }
            }
            else
            {
                Console.WriteLine("The print queue is empty.");
            }
        }

        static void RemoveDoc()
        {
            if (printQueue.Count > 0)
            {
                Console.WriteLine("Enter the name of the document to remove: ");
                string docToRemove = Console.ReadLine();

                if (printQueue.Contains(docToRemove))
                {
                    Queue<string> tempQueue = new Queue<string>();
                    while (printQueue.Count > 0)
                    {
                        string doc = printQueue.Dequeue();
                        if (doc != docToRemove)
                        {
                            tempQueue.Enqueue(doc);
                        }
                    }
                    printQueue = tempQueue;
                    Console.WriteLine($"Document '{docToRemove}' removed.");
                }
                else
                {
                    Console.WriteLine($"Document '{docToRemove}' not found in print queue.");
                }
            }
            else
            {
                Console.WriteLine("The print queue is empty.");
            }
        } 

        Console.WriteLine("Print Queue:");
        while (printQueue.Count > 0)
        {
            Console.WriteLine($"Printing: {printQueue.Dequeue()}");
        }
    }
}
