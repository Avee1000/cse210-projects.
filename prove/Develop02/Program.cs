using System;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        


        //call the prompt generator
        PromptGenerator promGen = new PromptGenerator();
       
                //call on the default prompts
        promGen.StorePrompt();

        Console.WriteLine($"Welcome to the Journal Program!");

        int userInput = -1;
        while  (!(userInput == 6))
        {
            Console.WriteLine($"\nPlease select one of the following choices:");
            Console.Write("1. Write \n2. Display \n3. Save \n4. Load \n5. Add personal prompt to prompt list\n6. Quit \nWhat would you like to do? ");
            string input = Console.ReadLine();
            int choice = int.Parse(input);
                
            if (choice == 1)
            {   
                Entry anEntry = new Entry();

                //use the  random prompt generator
                string newPrompt = promGen.GetRandomPrompt();
                Console.WriteLine(newPrompt);
                //use the _promptText member variable in the Entry class 
                //to add the "newPrompt" to the Entry class.
                anEntry._promptText = newPrompt;

                //Lets get the current date of entry using the datetime construct
                DateTime dt = DateTime.Now;
                string currentDate = dt.ToString();
                //use the _entryText member variable in the Entry class 
                //to change "currentDate" to an Entry.
                anEntry._date = currentDate;

                //ask for the user's entry in response to the above prompt
                Console.Write("\nWrite here: ");
                string userEntry = Console.ReadLine();

                //use the _entryText member variable in the Entry class 
                //to change "userEntry" to an Entry.
                anEntry._entryText = userEntry;
                //add the entry to list created in the journal class
                journal.AddEntry(anEntry);
            }
                
            else if (choice == 2)
            {
                journal.DisplayAll();
            }

            else if (choice == 3)
            {
                Console.Write("\nWhat will you like to name the file(ADD <.txt>): ");
                string userFileName = Console.ReadLine();   
                
                //use the user's entry as the parameter for the filename
                journal.SaveToFile(userFileName);
            }

            else if (choice == 4)
            {
                Console.Write("\nFile name (Please add the file type <.txt>): ");
                string loadFile = Console.ReadLine();

                //use the user's entry as the parameter for the file to be loaded
                journal.LoadFromFile(loadFile);
            }

            else if (choice == 5)
            {
                // promGen.printPrompt();
        
                Console.Write("Write a prompt here: ");
                string customPrompt = Console.ReadLine();

                //Let the user add extra prompts
                promGen.AddPrompt(customPrompt);
            }

            else if (choice == 6)
            {
                break;
            }
        }


     

  

        //use the  random prompt generator


        // Entry journalEntry = new Entry();
        // journalEntry._date = "2023-09-22";
        // journalEntry._promptText = newPrompt;

        // Console.Write("\nWrite here: ");
        // string userEntry = Console.ReadLine();
        // journalEntry._entryText = userEntry;
        // journalEntry.Display();
    }
}