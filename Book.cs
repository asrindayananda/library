using Project_2.Subsystems;
using System.Text;

namespace Project_2.Catalogue
{
    public class Book : Item
    {
        [AutoPrompt("author")]
        private string _Author;
        public string Author
        {
            get { return _Author; }
            set { _Author = value; }
        }

        [AutoPrompt("year of publication")]
        private int _Year;
        public int Year
        {
            get { return _Year; }
            set { _Year = value; }
        }

        [AutoPrompt("ISBN")]
        private string _ISBN;
        public string ISBN
        {
            get { return _ISBN; }
            set { _ISBN = value; }
        }

        protected override int DoCompare(Item other)
        {
            int result = base.DoCompare(other);

            if (result == 0)
            {
                Book b = other as Book;

                if (b == null)
                    result = 1;
                else
                {
                    // Exploits short circuit evaluation to compare each element, stopping if we hit any difference
                    bool trash = (result = _Author.CompareTo(b._Author)) != 0 ||
                                 (result = _Year.CompareTo(b._Year)) != 0 ||
                                 (result = _ISBN.CompareTo(b._ISBN)) != 0;
                }
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.AppendLine(string.Format("\tAuthored by {0}", _Author));
            sb.AppendLine(string.Format("\tPublished in {0}", _Year));
            sb.AppendLine(string.Format("\tISBN {0}", _ISBN));

            return sb.ToString();
        }
    }
}
