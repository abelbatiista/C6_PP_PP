using System;
using BookApp.Menu.MainMenu;
using BookApp.Menu.AuthorMenu;
using BookApp.Menu.BookMenu;
using BookApp.Menu.EditorialMenu;
using BookApp.Menu.CategoryMenu;
using BookApp.Menu.BookMenu.FindBookMenu;
using BookApp.Classes.AuthorClass;
using BookApp.Classes.BookClass;
using BookApp.Classes.EditorialClass;
using BookApp.Classes.CategoryClass;
using BookApp.Classes.BookClass.FindBookClass;

namespace BookApp
{
    class Program
    {
#pragma warning disable IDE0060 // Remove unused parameter¡
        static void Main(string[] args)
#pragma warning restore IDE0060 // Remove unused parameter
        {

            CMainMenu mainMenu = new CMainMenu(true);

            while (mainMenu.MainMenuOpen)
            {
                mainMenu.ShowMenu();
                mainMenu.ChooseOption();
                mainMenu.MainMenuChoice = Console.ReadLine();

                switch (mainMenu.MainMenuChoice)
                {
                    case "1":
                        CAuthorMenu authorMenu = new CAuthorMenu(true);
                        while (authorMenu.AuthorMenuOpen)
                        {
                            CAuthor author = new CAuthor();
                            authorMenu.ShowAuthorMenu();
                            authorMenu.ChooseOption();
                            authorMenu.AuthorMenuChoice = Console.ReadLine();

                            switch (authorMenu.AuthorMenuChoice)
                            {
                                case "1":
                                    author.InsertAuthor();
                                    break;
                                case "2":
                                    author.UpdateAuthor();
                                    break;
                                case "3":
                                    author.DeleteAuthor();
                                    break;
                                case "4":
                                    author.GetAuthors();
                                    break;
                                case "5":
                                    authorMenu.AuthorMenuOpen = authorMenu.BackForward();
                                    break;
                                default:
                                    authorMenu.WrongChoice();
                                    break;
                            }
                        }
                        break;

                    case "2":
                        CCategoryMenu categoryMenu = new CCategoryMenu(true);
                        while (categoryMenu.CategoryMenuOpen)
                        {
                            CCategory category = new CCategory();
                            categoryMenu.ShowCategoryMenu();
                            categoryMenu.ChooseOption();
                            categoryMenu.CategoryMenuChoice = Console.ReadLine();

                            switch (categoryMenu.CategoryMenuChoice)
                            {
                                case "1":
                                    category.InsertCategory();
                                    break;
                                case "2":
                                    category.UpdateCategory();
                                    break;
                                case "3":
                                    category.DeleteCategory();
                                    break;
                                case "4":
                                    category.GetCategories();
                                    break;
                                case "5":
                                    categoryMenu.CategoryMenuOpen = categoryMenu.BackForward();
                                    break;
                                default:
                                    categoryMenu.WrongChoice();
                                    break;
                            }
                        }
                        break;

                    case "3":
                        CEditorialMenu editorialMenu = new CEditorialMenu(true);
                        while (editorialMenu.EditorialMenuOpen)
                        {
                            CEditorial editorial = new CEditorial();
                            editorialMenu.ShowEditorialMenu();
                            editorialMenu.ChooseOption();
                            editorialMenu.EditorialMenuChoice = Console.ReadLine();

                            switch (editorialMenu.EditorialMenuChoice)
                            {
                                case "1":
                                    editorial.InsertEditorial();
                                    break;
                                case "2":
                                    editorial.UpdateEditorial();
                                    break;
                                case "3":
                                    editorial.DeleteEditorial();
                                    break;
                                case "4":
                                    editorial.GetEditorial();
                                    break;
                                case "5":
                                    editorialMenu.EditorialMenuOpen = editorialMenu.BackForward();
                                    break;
                                default:
                                    editorialMenu.WrongChoice();
                                    break;
                            }
                        }
                        break;

                    case "4":
                        CBookMenu bookMenu = new CBookMenu(true);
                        while (bookMenu.BookMenuOpen)
                        {
                            CBook book = new CBook();
                            bookMenu.ShowBookMenu();
                            bookMenu.ChooseOption();
                            bookMenu.BookMenuChoice = Console.ReadLine();

                            switch (bookMenu.BookMenuChoice)
                            {
                                case "1":
                                    book.InsertBook();
                                    break;
                                case "2":
                                    book.UpdateBook();
                                    break;
                                case "3":
                                    book.DeleteBook();
                                    break;
                                case "4":
                                    book.GetBooks();
                                    break;
                                case "5":
                                    bookMenu.BookMenuOpen = bookMenu.BackForward();
                                    break;
                                default:
                                    bookMenu.WrongChoice();
                                    break;
                            }
                        }
                        break;

                    case "5":
                        CFindBookMenu findBookMenu = new CFindBookMenu(true);
                        while (findBookMenu.FindBookMenuOpen)
                        {
                            CFindBook findBook = new CFindBook();
                            findBookMenu.ShowFindBookMenu();
                            findBookMenu.ChooseOption();
                            findBookMenu.FindBookMenuChoice = Console.ReadLine();

                            switch (findBookMenu.FindBookMenuChoice)
                            {
                                case "1":
                                    findBook.FindBooksByBookName();
                                    break;
                                case "2":
                                    findBook.FindBooksByEditorialCountry();
                                    break;
                                case "3":
                                    findBook.FindBooksByYearSinceUntil();
                                    break;
                                case "4":
                                    findBook.FindBooksByAuthorName();
                                    break;
                                case "5":
                                    findBook.FindBooksByEditorialName();
                                    break;
                                case "6":
                                    findBookMenu.FindBookMenuOpen = findBookMenu.BackForward();
                                    break;
                                default:
                                    findBookMenu.WrongChoice();
                                    break;
                            }
                        }
                        break;

                    case "6":
                        mainMenu.MainMenuOpen = mainMenu.CloseProgram();
                        break;
                    default:
                        mainMenu.WrongChoice();
                        break;
                }
            }

            Console.WriteLine("Gracias por utilizar nuestros servicios.");

        }
    }
}
