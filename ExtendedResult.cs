using System.Collections.Generic;

namespace Project_2.Menus
{
    public enum ResultCode { None, Failure, SubMenu, Logout };
    public class ExtendedResult
    {
        private ResultCode _ResultCode;
        public ResultCode ResultCode
        {
            get { return _ResultCode; }
        }

        private List<MenuOption> _SubMenu;
        public List<MenuOption> SubMenu
        {
            get { return _SubMenu; }
        }

        public ExtendedResult(ResultCode resultCode)
        {
            _ResultCode = resultCode;
            _SubMenu = null;
        }

        public ExtendedResult(ResultCode resultCode, List<MenuOption> subMenu)
            : this(resultCode)
        {
            _SubMenu = subMenu;
        }
    }
}
