using Project_2.Exceptions;
using System;

namespace Project_2.Users
{
    public class Student : User
    {
        public Student() // required for AutoPrompt
            : base()
        {
        }

        public Student(string login, string password, string givenName, string familyName)
            : base(login, password, givenName, familyName)
        {
        }

        public override string Title
        {
            get { return "Student"; }
        }

        public override string GetDetail()
        {
            return ToString();
        }

        public const string FILE_ENTRY_ID = "STUDENT";

        public static User FromFileEntry(string[] elements)
        {
            if (elements.Length != 5)
                throw new InvalidPasswordFileEntryException();

            return new Student(elements[1], elements[2], elements[3], elements[4]);
        }

        public override string ToFileEntry()
        {
            return string.Format("{0}:{1}", FILE_ENTRY_ID, GetFileEntryDetail());
        }
    }
}
