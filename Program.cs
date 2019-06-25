using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Project_2.Users;


namespace Project_2
{
    public class Program
    {
        #region Configuration
        private const string _PASSWORDS_FILENAME = "Passwords.txt";

        private static string[] _LoginBanner = new string[]
        {
            "",
            "*************************************************",
            "** Welcome to the EasyLibrary Catalogue System **",
            "*************************************************",
            "",
            "Please login below or enter 'exit' to terminate the catalogue.",
            ""
        };

        private static string _LoginTerminator = "exit";
        #endregion
        #region Login Management
        private static User GetLogin()
        {
            string login;
            string pass;
            ConsoleKeyInfo cki;
            User ret = null;
            do
            {
                try
                {
                    foreach (string s in _LoginBanner)
                        Console.WriteLine(s);

                    Console.Write("login: ");
                    login = Console.ReadLine();
                    if (login.ToLower() == _LoginTerminator.ToLower())
                        break;
                    Console.Write("password: ");
                    pass = "";
                    while ((cki = Console.ReadKey(true)) != null)
                    {
                        if (cki.Key == ConsoleKey.Enter)
                        {
                            Console.WriteLine();
                            break;
                        }
                        else
                            pass += cki.KeyChar;
                    }
                    if ((ret = UserManager.ValidateLogin(login, pass)) == null)
                        Console.Error.WriteLine("Invalid login.");
                }
                catch (Project_2.Exceptions.EasyLibraryException ex)
                {
                    Console.Error.WriteLine("Error: {0}", ex.Message);
                }
                Console.WriteLine();
            } while (ret == null);

            return ret;
        }
        #endregion

        static void Main(string[] args)
        {
            string pwFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\" + _PASSWORDS_FILENAME;
            UserManager.LoadDB(pwFile);

            User user;
            while ((user = GetLogin()) != null)
            {
                List<Project_2.Menus.MenuOption> menu = Project_2.Menus.MenuSystem.GetMenu(user);
                Project_2.Menus.MenuSystem.RunMenu(user, menu);
                Console.WriteLine("\nThank you for using EasyLibrary");
            }

            UserManager.SaveDB(pwFile);
        }
    }
}
