namespace FIBA_OT_sim.Model
{
    public class Group
    {
        private string name;
        private IList<NationalTeam> teams;

        public Group()
        {
            name = "";
            teams = [];
        }

        public Group(string name, IList<NationalTeam> teams)
        {
            this.name = name;
            this.teams = teams;
        }

        public Group(Group group)
        {
            name = group.name;
            teams = group.teams;
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
    }
}
