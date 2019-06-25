using System;
using System.Collections.Generic;

namespace Project_2.Menus
{
    public delegate void MenuHandler(Users.User usr, out ExtendedResult result);
    public class MenuOption
    {
        private string _Option;
        public string Option
        {
            get { return _Option; }
        }
        public string _Description;
        public string Description
        {
            get { return _Description; }
        }
        public MenuHandler _Handler;
        public MenuHandler Handler
        {
            get { return _Handler; }
        }
        public MenuOption(string option, string description, MenuHandler handler)
        {
            _Option = option;
            _Description = description;
            _Handler = handler;
        }
    }
}
