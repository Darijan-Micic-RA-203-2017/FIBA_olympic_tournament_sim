namespace FIBA_OT_sim.Model
{
    public class PotInDrawForEliminationPhase
    {
        private string name;
        private IList<NationalTeam> nationalTeams;

        public PotInDrawForEliminationPhase()
        {
            name = "";
            nationalTeams = new List<NationalTeam>();
        }

        public PotInDrawForEliminationPhase(string name, IList<NationalTeam> nationalTeams)
        {
            this.name = name;
            this.nationalTeams = nationalTeams;
        }

        public PotInDrawForEliminationPhase(PotInDrawForEliminationPhase pot)
        {
            name = pot.name;
            nationalTeams = pot.nationalTeams;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public IList<NationalTeam> NationalTeams
        {
            get { return nationalTeams; }
            set { nationalTeams = value; }
        }
    }
}
