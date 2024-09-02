namespace FIBA_OT_sim.Model
{
    public class Group : IComparable<Group>
    {
        private long id;
        private string name;
        private IList<NationalTeam> teams;
        private IList<Match> matches;

        public Group()
        {
            id = 0L;
            name = "";
            teams = new List<NationalTeam>();
            matches = new List<Match>();
        }

        public Group(long id, string name, IList<NationalTeam> teams, IList<Match> matches)
        {
            this.id = id;
            this.name = name;
            this.teams = teams;
            this.matches = matches;
        }

        public Group(Group group)
        {
            id = group.id;
            name = group.name;
            teams = group.teams;
            matches = group.matches;
        }

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public IList<NationalTeam> Teams
        {
            get { return teams; }
            set { teams = value; }
        }

        public IList<Match> Matches
        {
            get { return matches; }
            set { matches = value; }
        }

        public override int GetHashCode()
        {
            const int prime = 41;
            int result = 1;

            result = prime * result + Name.GetHashCode();

            return result;
        }

        public override bool Equals(object? obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (obj is not Group)
            {
                return false;
            }

            Group other = (Group) obj;

            if (Id != other.Id)
            {
                return false;
            }

            if (!Name.Equals(other.Name))
            {
                return false;
            }

            return true;
        }

        public int CompareTo(Group? other)
        {
            if (other == null)
            {
                throw new NullReferenceException();
            }

            if (this == other)
            {
                return 0;
            }

            if (Id < other.Id)
            {
                return -1;
            }
            else if (Id > other.Id)
            {
                return 1;
            }

            if (string.Compare(Name, other.Name) < 0)
            {
                return -1;
            }
            else if (string.Compare(Name, other.Name) > 0)
            {
                return 1;
            }

            return 0;
        }
    }
}
