// Library Management System //

using Library_Management_System;

Library library = new Library(); //Created a Library instance
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
            MemberMenu(library);
            break;

        case "3":
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


        Book newBook = new Book(); //I create a new instance of Book i.e newBook then pass it to AddBook(), BUT the book isn't stored anywhere!

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
        Console.WriteLine("\nWelcome Member!");
        Console.WriteLine("1. Register as a new member");
        Console.WriteLine("2. View available books");
        Console.WriteLine("3. Borrow a book");
        Console.WriteLine("4. Return a book");
        Console.WriteLine("5. View list of your borrowed books");
        Console.WriteLine("6. Return to the Main Menu");

        Console.Write("\nYour choice: ");
        string MemberMenuInput = Console.ReadLine();

        switch (MemberMenuInput)
        {
            case "1":
                Console.WriteLine("\nFunction not yet programmed!");
                Console.Write("\nPress enter to continue...");
                Console.ReadLine();
                break;

            case "2":
                member.ViewBookCatalogue();
                Console.Write("\nPress enter to continue...");
                Console.ReadLine();
                break;

            case "3":
                Console.Write("\nPress enter to continue...");
                Console.ReadLine();
                break;

            case "4":
                Console.Write("\nPress enter to continue...");
                Console.ReadLine();
                break;

            case "5":
                Console.Write("\nPress enter to continue...");
                Console.ReadLine();
                break;

            case "6":
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