using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Project_2.Exceptions;

namespace Project_2.Users
{
    public static class UserManager
    {
        private delegate User UserCreationHandler(string[] elements);

        private static List<User> _UserList = new List<User>();
        public static void Add(User user)
        {
            if (Find(user.Login) != null)
            {
                throw new UserExistsException();
            }
            _UserList.Add(user);
        }

        public static void Delete(string login)
        {
            var u = Find(login);

            if (u == null)
            {
                throw new UserNotFoundException();
            }
            _UserList.Remove(Find(login));
        }

        public static User Find(string login)
        {
            var usr = (from u in _UserList.AsEnumerable()
                       where u.Login == login
                       select u).SingleOrDefault<User>();

            return usr;
        }

        private struct UserType
        {
            public string TypeName;
            public UserCreationHandler Handler;
        }

        private static UserType [] _UserTypes = new UserType[] {
            new UserType() { TypeName = Admin.FILE_ENTRY_ID, Handler = Admin.FromFileEntry },
            new UserType() { TypeName = Staff.FILE_ENTRY_ID, Handler = Staff.FromFileEntry },
            new UserType() { TypeName = Student.FILE_ENTRY_ID, Handler = Student.FromFileEntry }
        };

        public static void LoadDB(string fileName)
        {
            using (var sr = File.OpenText(fileName))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    try
                    {
                        var components = s.Split(new char[] { ':' });
                        if (components != null && components.Length > 0)
                        {
                            var ute = _UserTypes.Where(u => u.TypeName == components[0]).SingleOrDefault<UserType>();

                            if (!ute.Equals(null))
                            {
                                UserManager.Add(ute.Handler(components));
                            }
                            else
                            {
                                throw new InvalidPasswordFileEntryFormatException();
                            }
                        }
                    }
                    catch (UserDBException ude)
                    {
                        Console.Error.WriteLine("Error loading password file entry: {0}", ude.Message);
                    }
                }
                sr.Close();
            }
        }

        public static void SaveDB(string fileName)
        {
            using (var sw = new StreamWriter(File.OpenWrite(fileName)))
            {
                foreach (User u in _UserList)
                {
                    sw.WriteLine(u.ToFileEntry());
                }
                sw.Close();
            }
        }

        public static User ValidateLogin(string login, string password)
        {
            var u = Find(login);

            if (u != null && u.Password != password)
            {
                throw new InvalidLoginException();
            }
            return u;
        }
    }
}
