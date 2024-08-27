namespace FIBA_OT_sim.Model
{
    public class Group
    {
        private string name;
        private NationalTeam team1;
        private NationalTeam team2;
        private NationalTeam team3;
        private NationalTeam team4;

        public Group()
        {
            name = "";
            team1 = new NationalTeam();
            team2 = new NationalTeam();
            team3 = new NationalTeam();
            team4 = new NationalTeam();
        }

        public Group(string name, NationalTeam team1, NationalTeam team2, NationalTeam team3, NationalTeam team4)
        {
            this.name = name;
            this.team1 = team1;
            this.team2 = team2;
            this.team3 = team3;
            this.team4 = team4;
        }

        public Group(Group group)
        {
            name = group.name;
            team1 = group.team1;
            team2 = group.team2;
            team3 = group.team3;
            team4 = group.team4;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public NationalTeam Team1
        {
            get { return team1; }
            set { team1 = value; }
        }

        public NationalTeam Team2
        {
            get { return team2; }
            set { team2 = value; }
        }

        public NationalTeam Team3
        {
            get { return team3; }
            set { team3 = value; }
        }

        public NationalTeam Team4
        {
            get { return team4; }
            set { team4 = value; }
        }
    }
}
