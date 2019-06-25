using Project_2.Exceptions;
using Project_2.Subsystems;
using System;
using System.Text;

namespace Project_2.Users
{
    public class Staff : User
    {
        [AutoPrompt("department")]
        private string _Department;
        public string Department
        {
            get { return _Department; }
            set { _Department = value; }
        }

        public Staff() // required for AutoPrompt
            : base()
        {
        }

        public Staff(string login, string password, string givenName, string familyName, string department)
            : base(login, password, givenName, familyName)
        {
            _Department = department;
        }

        public override string Title
        {
            get { return "Staff Member"; }
        }

        public override string GetDetail()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(ToString());
            sb.AppendLine(string.Format("\tDepartment: {0}", _Department));
    
            return sb.ToString();
        }

        public const string FILE_ENTRY_ID = "STAFF";

        public static User FromFileEntry(string[] elements)
        {
            if (elements.Length != 6)
                throw new InvalidPasswordFileEntryException();

            return new Staff(elements[1], elements[2], elements[3], elements[4], elements[5]);
        }

        public override string ToFileEntry()
        {
            return string.Format("{0}:{1}:{2}", FILE_ENTRY_ID, GetFileEntryDetail(), _Department);
        }
    }
}
