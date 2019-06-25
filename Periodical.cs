using Project_2.Subsystems;
using System.Text;

namespace Project_2.Catalogue
{
    public class Periodical : Item
    {
        [AutoPrompt("volume number")]
        private int _Volume;
        public int Volume
        {
            get { return _Volume; }
            set { _Volume = value; }
        }

        [AutoPrompt("issue number")]
        private int _Issue;
        public int Issue
        {
            get { return _Issue; }
            set { _Issue = value; }
        }
        
        [AutoPrompt("year of publication")]
        private int _Year;
        public int Year
        {
            get { return _Year; }
            set { _Year = value; }
        }

        protected override int DoCompare(Item other)
        {
            int result = base.DoCompare(other);

            if (result == 0)
            {
                Periodical p = other as Periodical;

                if (p == null)
                    result = 1;
                else
                {
                    // Exploits short circuit evaluation to compare each element, stopping if we hit any difference
                    bool trash = (result = _Volume.CompareTo(p._Volume)) != 0 ||
                                 (result = _Issue.CompareTo(p._Issue)) != 0 ||
                                 (result = _Year.CompareTo(p._Year)) != 0;
                }
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.AppendLine(string.Format("\tVolume {0} Issue {1}", _Volume, _Issue));
            sb.AppendLine(string.Format("\tPublished in {0}", _Year));

            return sb.ToString();
        }
    }
}
