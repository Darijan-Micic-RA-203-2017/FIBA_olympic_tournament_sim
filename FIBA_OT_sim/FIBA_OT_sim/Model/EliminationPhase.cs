namespace FIBA_OT_sim.Model
{
    public class EliminationPhase
    {
        private IList<Match> quarterFinals;
        private IList<Match> semiFinals;
        private Match thirdPlaceMatch;
        private Match final;

        public EliminationPhase()
        {
            quarterFinals = new List<Match>();
            semiFinals = new List<Match>();
            thirdPlaceMatch = new Match();
            final = new Match();
        }

        public EliminationPhase(IList<Match> quarterFinals, IList<Match> semiFinals, Match thirdPlaceMatch, 
            Match final)
        {
            this.quarterFinals = quarterFinals;
            this.semiFinals = semiFinals;
            this.thirdPlaceMatch = thirdPlaceMatch;
            this.final = final;
        }

        public EliminationPhase(EliminationPhase eliminationPhase)
        {
            quarterFinals = new List<Match>();
            foreach (Match originalQuarterFinalsMatch in eliminationPhase.quarterFinals)
            {
                quarterFinals.Add(new Match(originalQuarterFinalsMatch));
            }
            semiFinals = new List<Match>();
            foreach (Match originalSemiFinalsMatch in eliminationPhase.semiFinals)
            {
                semiFinals.Add(new Match(originalSemiFinalsMatch));
            }
            thirdPlaceMatch = new Match(eliminationPhase.thirdPlaceMatch);
            final = new Match(eliminationPhase.final);
        }

        public IList<Match> QuarterFinals
        {
            get { return quarterFinals; }
            set { quarterFinals = value; }
        }

        public IList<Match> SemiFinals
        {
            get { return semiFinals; }
            set { semiFinals = value; }
        }

        public Match ThirdPlaceMatch
        {
            get { return thirdPlaceMatch; }
            set { thirdPlaceMatch = value; }
        }

        public Match Final
        {
            get { return final; }
            set { final = value; }
        }
    }
}
