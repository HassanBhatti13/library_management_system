// Library Management System //

using Library_Management_System;

Library library = new Library(); //Created a Library instance
library.LoadMembersFromFile(); // Load members from file

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