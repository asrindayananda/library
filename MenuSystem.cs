using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_2.Menus
{
    public static class MenuSystem
    {
        private static MenuOption GetMenuSelection(List<MenuOption> menuOptions, Users.User currentUser)
        {
            MenuOption result = null;

            string greeting = string.Format("Welcome {0}", currentUser);
            Console.WriteLine(greeting);
            Console.WriteLine(new string('=', greeting.Length));

            bool valid = false;
            string selectedOption = "";
            while (valid == false)
            {
                Console.WriteLine("Please select from the following options:");
                foreach (MenuOption opt in menuOptions)
                {
                    Console.WriteLine("\t{0}. {1}", opt.Option, opt.Description);
                }
                Console.Write("Please enter your selection: ");
                selectedOption = Console.ReadLine().ToUpper();
                result = menuOptions.Where(m => m.Option == selectedOption).SingleOrDefault<MenuOption>();
                if (result != null)
                    valid = true;
                else
                    Console.Error.WriteLine("Invalid option, please try again.");
            }
            Console.WriteLine();

            return result;
        }

        public static void RunMenu(Users.User currentUser, List<MenuOption> menu)
        {
            MenuOption opt;
            ExtendedResult extResult = new ExtendedResult(ResultCode.None);

            do
            {
                try
                {
                    opt = GetMenuSelection(menu, currentUser);
                    opt.Handler(currentUser, out extResult);
                    if (extResult.ResultCode == ResultCode.SubMenu)
                        RunMenu(currentUser, extResult.SubMenu);
                }
                catch (Project_2.Exceptions.EasyLibraryException ex)
                {
                    Console.Error.WriteLine("Error: {0}", ex.Message);
                }
            } while (extResult.ResultCode != ResultCode.Logout);
        }

        #region General Handler Functions
        private static void FindByTitleHandler(Users.User usr, out ExtendedResult result)
        {
            Console.Write("Please enter a title to search for: ");
            string title = Console.ReadLine();
            Console.WriteLine();
            Project_2.Catalogue.Item[] items = Project_2.Catalogue.CatalogueManager.FindByTitle(title);
            if (items.Length == 0)
                Console.WriteLine("No titles found.");
            else
            {
                Console.WriteLine("Matching titles: ");
                foreach (Project_2.Catalogue.Item item in items)
                    Console.WriteLine(string.Format("{0}", item));
            }
            Console.WriteLine();
            result = new ExtendedResult(ResultCode.None);
        }

        private static void NoopHandler(Users.User usr, out ExtendedResult result)
        {
            result = new ExtendedResult(ResultCode.None);
        }

        private static void LogoutHandler(Users.User usr, out ExtendedResult result)
        {
            result = new ExtendedResult(ResultCode.Logout);
        }
        #endregion
        #region Catalogue Management Handlers
        private static void AddBookHandler(Users.User usr, out ExtendedResult result)
        {
            Project_2.Catalogue.CatalogueManager.Add(Project_2.Subsystems.AutoPrompt.Create<Project_2.Catalogue.Book>());
            result = new ExtendedResult(ResultCode.None);
        }

        private static void AddPeriodicalHandler(Users.User usr, out ExtendedResult result)
        {
            Project_2.Catalogue.CatalogueManager.Add(Project_2.Subsystems.AutoPrompt.Create<Project_2.Catalogue.Periodical>());
            result = new ExtendedResult(ResultCode.None);
        }
        #endregion
        #region Catalogue Management Menu
        public static void CatalogueManagementMenu(Users.User usr, out ExtendedResult result)
        {
            List<MenuOption> menu = new List<MenuOption>();

            menu.Add(new MenuOption("B", "Add new book", AddBookHandler));
            menu.Add(new MenuOption("P", "Add new periodical", AddPeriodicalHandler));
            menu.Add(new MenuOption("X", "Exit", LogoutHandler));

            result = new ExtendedResult(ResultCode.SubMenu, menu);
        }
        #endregion
        #region User Management Handlers
        private static void AddUserHandler(Users.User usr, out ExtendedResult result)
        {
            Console.WriteLine("Please select from the following types of user: ");
            Console.WriteLine("\t1) Administrator");
            Console.WriteLine("\t2) Staff Member");
            Console.WriteLine("\t3) Student");
            Console.WriteLine("\t0) Go back");
            Console.Write("Selection: ");

            Users.User newUsr = null;
            int selection;
            if (int.TryParse(Console.ReadLine(), out selection) == true)
            {
                switch (selection)
                {
                    case 1: // Administrator
                        newUsr = Project_2.Subsystems.AutoPrompt.Create<Project_2.Users.Admin>();
                        break;
                    case 2: // Staff Member
                        newUsr = Project_2.Subsystems.AutoPrompt.Create<Project_2.Users.Staff>();
                        break;
                    case 3: // Student
                        newUsr = Project_2.Subsystems.AutoPrompt.Create<Project_2.Users.Student>();
                        break;
                    case 0: // Go back
                        // Do nothing
                        break;
                    default:
                        Console.Error.WriteLine("Error: Invalid user type");
                        break;
                }
            }
            if (newUsr != null)
            {
                Project_2.Users.UserManager.Add(newUsr);
                result = new ExtendedResult(ResultCode.None);
            }
            else
            {
                result = new ExtendedResult(ResultCode.Failure);
            }
        }

        private static void FindUserHandler(Users.User usr, out ExtendedResult result)
        {
            Console.Write("Enter login name: ");
            string login = Console.ReadLine();

            Users.User searchUser;
            if ((searchUser = Project_2.Users.UserManager.Find(login)) == null)
            {
                Console.Error.WriteLine("Error: User not found");
                result = new ExtendedResult(ResultCode.Failure);
            }
            else
            {
                Console.WriteLine(searchUser.GetDetail());
                Console.WriteLine();
                result = new ExtendedResult(ResultCode.None);
            }
        }

        private static void RemoveUserHandler(Users.User usr, out ExtendedResult result)
        {
            Console.Write("Enter login name: ");
            string login = Console.ReadLine();

            if (login == usr.Login)
                throw new Project_2.Exceptions.DeleteCurrentUserException();

            Project_2.Users.UserManager.Delete(login);
            result = new ExtendedResult(ResultCode.None);
        }
        #endregion
        #region User Management Menu
        public static void UserManagementMenu(Users.User usr, out ExtendedResult result)
        {
            List<MenuOption> menu = new List<MenuOption>();

            menu.Add(new MenuOption("A", "Add new user", AddUserHandler));
            menu.Add(new MenuOption("F", "Find a user", FindUserHandler));
            menu.Add(new MenuOption("R", "Remove a user", RemoveUserHandler));
            menu.Add(new MenuOption("X", "Exit", LogoutHandler));

            result = new ExtendedResult(ResultCode.SubMenu, menu);
        }
        #endregion
        #region Administrator Main Menu
        private static List<MenuOption> GetAdminMenu()
        {
            List<MenuOption> ret = new List<MenuOption>();

            ret.Add(new MenuOption("C", "Catalogue Management", CatalogueManagementMenu));
            ret.Add(new MenuOption("U", "User Management", UserManagementMenu));

            return ret;
        }
        #endregion
        #region Student Main Menu
        private static List<MenuOption> GetStudentMenu()
        {
            List<MenuOption> ret = new List<MenuOption>();

            ret.Add(new MenuOption("F", "Find by title", FindByTitleHandler));

            return ret;
        }
        #endregion
        #region Default Main Menu
        public static List<MenuOption> GetMenu(Users.User u)
        {
            List<MenuOption> ret;

            if (u is Project_2.Users.Admin)
                ret = GetAdminMenu();
            else if (u is Project_2.Users.Student)
                ret = GetStudentMenu();
            else
                ret = new List<MenuOption>();


            ret.Add(new MenuOption("X", "Logout", LogoutHandler));

            return ret;
        }
        #endregion
    }
}
