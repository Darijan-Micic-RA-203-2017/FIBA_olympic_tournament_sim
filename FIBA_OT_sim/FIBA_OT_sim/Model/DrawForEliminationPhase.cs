namespace FIBA_OT_sim.Model
{
    public class DrawForEliminationPhase
    {
        private IList<NationalTeam> potD;
        private IList<NationalTeam> potE;
        private IList<NationalTeam> potF;
        private IList<NationalTeam> potG;

        public DrawForEliminationPhase()
        {
            potD = new List<NationalTeam>();
            potE = new List<NationalTeam>();
            potF = new List<NationalTeam>();
            potG = new List<NationalTeam>();
        }

        public DrawForEliminationPhase(IList<NationalTeam> potD, IList<NationalTeam> potE, 
            IList<NationalTeam> potF, IList<NationalTeam> potG)
        {
            this.potD = potD;
            this.potE = potE;
            this.potF = potF;
            this.potG = potG;
        }

        public DrawForEliminationPhase(DrawForEliminationPhase drawForEliminationPhase)
        {
            potD = drawForEliminationPhase.potD;
            potE = drawForEliminationPhase.potE;
            potF = drawForEliminationPhase.potF;
            potG = drawForEliminationPhase.potG;
        }

        public IList<NationalTeam> PotD
        {
            get { return potD; }
            set { potD = value; }
        }

        public IList<NationalTeam> PotE
        {
            get { return potE; }
            set { potE = value; }
        }

        public IList<NationalTeam> PotF
        {
            get { return potF; }
            set { potF = value; }
        }

        public IList<NationalTeam> PotG
        {
            get { return potG; }
            set { potG = value; }
        }
    }
}
