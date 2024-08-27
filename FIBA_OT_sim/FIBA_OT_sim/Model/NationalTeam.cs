namespace FIBA_OT_sim.Model
{
    public class NationalTeam
    {
        private string name;
        private string abbreviation;
        private int fibaRanking;
        private int groupPhaseRanking;
        private StatusOfNationalTeam status;
        private IList<Match> matches;

        public NationalTeam()
        {
            name = "";
            abbreviation = "";
            fibaRanking = 0;
            groupPhaseRanking = 0;
            status = StatusOfNationalTeam.COMPETING_IN_GROUP_PHASE;
            matches = new List<Match>();
        }

        public NationalTeam(string name, string abbreviation, int fibaRanking, int groupPhaseRanking, 
            StatusOfNationalTeam status, IList<Match> matches)
        {
            this.name = name;
            this.abbreviation = abbreviation;
            this.fibaRanking = fibaRanking;
            this.groupPhaseRanking = groupPhaseRanking;
            this.status = status;
            this.matches = matches;
        }

        public NationalTeam(NationalTeam nationalTeam)
        {
            name = nationalTeam.name;
            abbreviation = nationalTeam.abbreviation;
            fibaRanking = nationalTeam.fibaRanking;
            groupPhaseRanking = nationalTeam.groupPhaseRanking;
            status = nationalTeam.status;
            matches = nationalTeam.matches;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Abbreviation
        {
            get { return abbreviation; }
            set { abbreviation = value; }
        }

        public int FIBARanking
        {
            get { return fibaRanking; }
            set { fibaRanking = value; }
        }

        public int GroupPhaseRanking
        {
            get { return groupPhaseRanking; }
            set { groupPhaseRanking = value; }
        }

        public StatusOfNationalTeam Status
        {
            get { return status; }
            set { status = value; }
        }

        public IList<Match> Matches
        {
            get { return matches; }
            set { matches = value; }
        }
    }
}
