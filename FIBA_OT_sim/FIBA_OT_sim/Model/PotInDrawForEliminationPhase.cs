namespace FIBA_OT_sim.Model
{
    public class PotInDrawForEliminationPhase
    {
        private IList<NationalTeam> nationalTeams;

        public PotInDrawForEliminationPhase()
        {
            nationalTeams = new List<NationalTeam>();
        }

        public PotInDrawForEliminationPhase(IList<NationalTeam> nationalTeams)
        {
            this.nationalTeams = nationalTeams;
        }

        public PotInDrawForEliminationPhase(PotInDrawForEliminationPhase pot)
        {
            nationalTeams = pot.nationalTeams;
        }

        public IList<NationalTeam> NationalTeams
        {
            get { return nationalTeams; }
            set { nationalTeams = value; }
        }
    }
}
