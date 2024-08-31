namespace FIBA_OT_sim.Model
{
    public class Group
    {
        private string name;
        private IList<NationalTeam> teams;
        private IList<Match> matches;

        public Group()
        {
            name = "";
            teams = new List<NationalTeam>();
            matches = new List<Match>();
        }

        public Group(string name, IList<NationalTeam> teams, IList<Match> matches)
        {
            this.name = name;
            this.teams = teams;
            this.matches = matches;
        }

        public Group(Group group)
        {
            name = group.name;
            teams = new List<NationalTeam>();
            foreach (NationalTeam originalNationalTeam in group.teams)
            {
                teams.Add(new NationalTeam(originalNationalTeam));
            }
            matches = new List<Match>();
            foreach (Match originalMatch in group.matches)
            {
                matches.Add(new Match(originalMatch));
            }
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
    }
}
