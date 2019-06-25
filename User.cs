using Project_2.Subsystems;
using System;

namespace Project_2.Users
{
    public abstract class User
    {
        [AutoPrompt("login name")]
        private string _Login;
        public string Login
        {
            get { return _Login; }
            set { _Login = value; }
        }

        [AutoPrompt("password")]
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        [AutoPrompt("given name")]
        private string _GivenName;
        public string GivenName
        {
            get { return _GivenName; }
            set { _GivenName = value; }
        }

        [AutoPrompt("family name")]
        private string _FamilyName;
        public string FamilyName
        {
            get { return _FamilyName; }
            set { _FamilyName = value; }
        }

        public abstract string Title { get; }

        public User() // required for AutoPrompt
        {
        }

        public User(string login, string password, string givenName, string familyName)
        {
            _Login = login;
            _Password = password;
            _GivenName = givenName;
            _FamilyName = familyName;
        }

        public abstract string GetDetail();

        protected string GetFileEntryDetail()
        {
            return string.Format("{0}:{1}:{2}:{3}", _Login, _Password, _GivenName, _FamilyName);
        }

        public abstract string ToFileEntry();

        public override string ToString()
        {
            return string.Format("{0} {1} ({2})", _GivenName, _FamilyName, Title);
        }
    }
}
