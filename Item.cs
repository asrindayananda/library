using Project_2.Subsystems;
using System;
using System.Text;

namespace Project_2.Catalogue
{
    public abstract class Item : IComparable<Item>
    {
        [AutoPrompt("title")]
        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        [AutoPrompt("publisher")]
        private string _Publisher;
        public string Publisher
        {
            get { return _Publisher; }
            set { _Publisher = value; }
        }

        [AutoPrompt("call number")]
        private string _CallNumber;
        public string CallNumber
        {
            get { return _CallNumber; }
            set { _CallNumber = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(_Title);
            sb.AppendLine(string.Format("\tCall number: {0}", _CallNumber));
            sb.AppendLine(string.Format("\tPublished by {0}", _Publisher));

            return sb.ToString();
        }

        protected virtual int DoCompare(Item other)
        {
            // Introduce a polymorphic method to do the actual comparison
            int result = 0;

            if (other == null)
                result = 1;
            else
            {
                // Exploits short circuit evaluation to compare each element, stopping if we hit any difference
                bool trash = (result = _Title.CompareTo(other._Title)) != 0 ||
                             (result = _Publisher.CompareTo(other._Publisher)) != 0 ||
                             (result = _CallNumber.CompareTo(other._CallNumber)) != 0;
            }

            return result;
        }

        public int CompareTo(Item other)
        {
            return DoCompare(other);
        }
    }
}
