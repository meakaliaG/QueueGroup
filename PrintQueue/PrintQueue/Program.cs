/*
 * A queue structure makes the most sense for a printing simulation because it follows the "First in, First out" principle. This means that when a document is added to the queue, it will be placed at the back of the line. This ensures priority is followed. 
 * If a stack had been implemented in this program instead of a queue, the most recent document added would be printed before any documents that had been waiting. So if someone had to print multiple documents, it could take a very long time to print the first document they submitted.
 * Using a queue ensures that the document that was sent to print first, is the document that will print first and people can't skip in line to have their own documents printed first.
 */
/*
Meakalia: in charge of main structure
Olivia: in charge of error handling
Jacob: in charge of thought out commenting
lennon: in charge of maintaing brainstorm file
*/
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

        // Begin communication with the user
        Console.WriteLine("Welcome to the Print Queue!");
        // Stores user unput throughout the program
        string userInput = "";

        // Calls function that writes display options to console for user to view
        DisplayOptions();


        // While the user is working in the program and has not yet quit
        while (userInput.ToLower() != "quit")
        {
            // Read user input
            userInput = Console.ReadLine();

            // Make user input lowercase so that the user input doesn't need to be case sensitive
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
            else if (userInput == "options")
            {
                DisplayOptions();
            }
            else // Run when no input is recieved.
            {
                Console.WriteLine("Invalid option. Please try again.");
            }

        }

        // Add a document to the Queue using Enqueue()
        static void AddDoc()
        {
            Console.WriteLine("Enter the name of the document to add: ");
            string doc = Console.ReadLine();
            printQueue.Enqueue(doc);
            Console.WriteLine($"Document '{doc}' added to the queue.");
        }

        // Remove a document from the Queue using Dequeue()
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

        // View the elements in the Queue by printing them to the console
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

        // Remove a specific document from queue based on user input using Dequeue()
        static void RemoveDoc()
        {
            if (printQueue.Count > 0)
            {
                Console.WriteLine("Enter the name of the document to remove: ");
                string docToRemove = Console.ReadLine();

                //executed if name passed in by user exists in the queue
                if (printQueue.Contains(docToRemove))
                {
                    //creates a temporary queue - maintains order and is more efficient
                    Queue<string> tempQueue = new Queue<string>();
                    //while printQueue's length is greater than 0
                    while (printQueue.Count > 0)
                    {
                        //take the first element in printQueue
                        string doc = printQueue.Dequeue();
                        //if the current element (doc) does not equal the doc the user wants to remove, add it to the tempQueue
                        if (doc != docToRemove)
                        {
                            tempQueue.Enqueue(doc);
                        }
                    }
                    //assign tempQueue to printQueue
                    printQueue = tempQueue;
                    Console.WriteLine($"Document '{docToRemove}' removed.");
                }
                //executed if name passed in by user doesn't exist
                else
                {
                    Console.WriteLine($"Document '{docToRemove}' not found in print queue.");
                }
            }
            //executed if printQueue is 0
            else
            {
                Console.WriteLine("The print queue is empty.");
            }
        } 

        // Displays the user options to the user when requested
        static void DisplayOptions()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("Options:\n- 'add' - Add a document to the print queue.\n- 'print' - Print the next document in the queue.\n- 'view' - View the current queue status.\n- 'remove' - Remove a specific document from the queue.\n- 'quit' - End program. \n- 'options' - View these options again.");
            Console.WriteLine("Please enter your choice: ");
        }

        // After the program is quit, the print queue is displayed
        ViewQueue();
        // I added the line above and commented out the 4 lines below. Does this make sense or am I missing something?
        //Console.WriteLine("Print Queue:");
        //while (printQueue.Count > 0)
        //{
        //    Console.WriteLine($"Printing: {printQueue.Dequeue()}");
        //}
    }
}
