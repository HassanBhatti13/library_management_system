// Library Management System //

using Library_Management_System;

MainMenu();

void MainMenu()
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
            LibrarianMenu();

            break;

        case "2":
            MemberMenu();
            break;

        case "3":
            break;

        default:
            break;
    }
}

void LibrarianMenu()

{
    Librarian librarian = new Librarian("Hassan", 101);
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


        Book newBook = new Book();

        switch (LibrarianMenuInput)
        {
            case "1":
                librarian.AddBook(newBook);
                Console.WriteLine("\nPress enter to continue...");
                Console.ReadLine();
                break;

            case "2":
                // librarian.RemoveBook();
                Console.WriteLine("\nPress enter to continue...");
                Console.ReadLine();
                break;

            case "3":
                // librarian.ViewAllBooks();
                Console.WriteLine("\nPress enter to continue...");
                Console.ReadLine();
                break;

            case "4":
                KeepRunning = false;
                Console.Clear();
                MainMenu();
                break;

            default:
                Console.WriteLine("\nInvalid choice selection!");
                break;
        }
    }
}

void MemberMenu()
{
    Member member = new Member("Ali", 102);

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
            break;

        case "2":
            // member.ViewAllBooks();
            Console.WriteLine("\nPress enter to continue...");
            Console.ReadLine();
            break;
    }
}