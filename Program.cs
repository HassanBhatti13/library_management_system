﻿// Library Management System //

using Library_Management_System;

Library library = new Library(); // Created a Library instance
library.LoadBooksFromFile();     // Load books from file
library.LoadMembersFromFile();   // Load members from file

MainMenu(library);               

void MainMenu(Library library)
{
    Console.WriteLine("\nWelcome to Library!");
    Console.WriteLine("1. Librarian");
    Console.WriteLine("2. Member Login / Register");
    Console.WriteLine("3. Exit");

    Console.Write("\nYour choice: ");
    string input = Console.ReadLine();

    switch (input)
    {
        case "1":
            LibrarianMenu(library);         // passed Library instance to the Librarian
            break;

        case "2":
            MemberLogin(library);
            break;

        case "3":
            Console.Write("\nExiting the program...\n");
            break;

        default:
            break;
    }
}

void LibrarianMenu(Library library)

{
    Librarian librarian = new Librarian("Hassan", 101, library);
    bool KeepRunning = true;
    while (KeepRunning)
    {
        Console.Clear();
        Console.WriteLine("\nWelcome Librarian!");
        Console.WriteLine("1. Add a book");
        Console.WriteLine("2. Remove a book");
        Console.WriteLine("3. View all books in the library");
        Console.WriteLine("4. Go back to Main Menu");

        Console.Write("\nYour choice: ");
        string LibrarianMenuInput = Console.ReadLine();


        Book newBook = new Book(); //Created a Book instance

        switch (LibrarianMenuInput)
        {
            case "1":
                librarian.AddBook(newBook);
                Console.Write("\nPress enter to continue...");
                Console.ReadLine();
                break;

            case "2":
                librarian.RemoveBook();
                Console.Write("\nPress enter to continue...");
                Console.ReadLine();
                break;

            case "3":
                librarian.ViewBookCatalogue();
                Console.Write("\nPress enter to continue...");
                Console.ReadLine();
                break;

            case "4":
                KeepRunning = false;
                Console.Clear();
                MainMenu(library);
                break;

            default:
                Console.WriteLine("\nInvalid choice selection!");
                break;
        }
    }
}

void MemberLogin(Library library)
{
    Console.Clear();
    Console.WriteLine("\n=== Welcome to Library ===\n");
    Console.WriteLine("1. Login");
    Console.WriteLine("2. Register yourself as new member");

    Console.Write("\nYour choice: ");
    string MemberLoginInput = Console.ReadLine();
    
        switch (MemberLoginInput)
        {
            case "1":
            //Login logic here
            Console.Clear();
            Console.WriteLine("\n=== Choose login method ===\n");
            Console.WriteLine("1. By Name");
            Console.WriteLine("2. By ID");

            Console.Write("\nYour choice: ");   
            string choice = Console.ReadLine();

                Member loggedInMember = null;
                if (choice == "1")
                {
                    Console.Write("\nEnter your name: ");
                    string name = Console.ReadLine();
                    loggedInMember = library.FindMemberByName(name);
                }
                else if (choice == "2")
                {
                    Console.Write("Enter your ID: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        loggedInMember = library.FindMemberById(id);
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID format.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }

                if (loggedInMember != null)
                {
                    Console.Clear();
                    Console.WriteLine($"\n=== Welcome {loggedInMember.Name}! ===\n");
                }
                else
                {
                    Console.WriteLine("Incorrect Credentials!");
                }


            Console.Write("\nPress enter to continue...");
            Console.ReadLine();
            MemberMenu(library);

            break;

        case "2":
            //Register logic here, then once again show MemberLogin page so they can login by new credentials 

            Member tempMember = new Member("temp", 0, library); //Dummy values
            tempMember.AddMember();
            Console.Write("\nPress enter to continue...");
            Console.ReadLine();
            MemberLogin(library);
            // MemberMenu(library);
            break;

        default:
            Console.WriteLine("\nInvalid choice selection!");
            break;
    }
}

void MemberMenu(Library library)
{
    Member member = new Member("Ali", 102, library);

    bool KeepRunning = true;
    while (KeepRunning)
    {
        Console.Clear();
        Console.WriteLine($"\nWelcome Member!");
        Console.WriteLine("1. View available books");
        Console.WriteLine("2. Borrow a book");
        Console.WriteLine("3. Return a book");
        Console.WriteLine("4. View list of your borrowed books");
        Console.WriteLine("5. Return to the Main Menu");

        Console.Write("\nYour choice: ");
        string MemberMenuInput = Console.ReadLine();

        switch (MemberMenuInput)
        {
            case "1":
                member.ViewBookCatalogue();
                Console.Write("\nPress enter to continue...");
                Console.ReadLine();
                break;

            case "2":
                member.BorrowBook();
                Console.Write("\nPress enter to continue...");
                Console.ReadLine();
                break;

            case "3":
                member.ReturnBook();
                Console.Write("\nPress enter to continue...");
                Console.ReadLine();
                break;

            case "4":
                member.ViewBorrowedBooks();
                Console.Write("\nPress enter to continue...");
                Console.ReadLine();
                break;

            case "5":
                KeepRunning = false;
                Console.Clear();
                MainMenu(library);
                break;
            
            default:
                Console.WriteLine("\nInvalid choice selection!");
                break;
        }
    }
}