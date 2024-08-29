namespace FIBA_OT_sim.Model
{
    public class NationalTeam
    {
        private string name;
        private string abbreviation;
        private int fibaRanking;
        private int winsInGroupPhase;
        private int lossesInGroupPhase;
        private int scoredPointsInGroupPhase;
        private int allowedPointsInGroupPhase;
        private int pointsDifferentialInGroupPhase;
        private int pointsInGroupPhase;
        private int groupPhaseRanking;
        private StatusOfNationalTeam status;
        private IList<Match> matches;

        public NationalTeam()
        {
            name = "";
            abbreviation = "";
            fibaRanking = 0;
            winsInGroupPhase = 0;
            lossesInGroupPhase = 0;
            scoredPointsInGroupPhase = 0;
            allowedPointsInGroupPhase = 0;
            pointsDifferentialInGroupPhase = 0;
            pointsInGroupPhase = 0;
            groupPhaseRanking = 0;
            status = StatusOfNationalTeam.COMPETING_IN_GROUP_PHASE;
            matches = new List<Match>();
        }

        public NationalTeam(string name, string abbreviation, int fibaRanking, int winsInGroupPhase, 
            int lossesInGroupPhase, int scoredPointsInGroupPhase, int allowedPointsInGroupPhase, 
            int pointsDifferentialInGroupPhase, int pointsInGroupPhase, int groupPhaseRanking, 
            StatusOfNationalTeam status, IList<Match> matches)
        {
            this.name = name;
            this.abbreviation = abbreviation;
            this.fibaRanking = fibaRanking;
            this.winsInGroupPhase = winsInGroupPhase;
            this.lossesInGroupPhase = lossesInGroupPhase;
            this.scoredPointsInGroupPhase = scoredPointsInGroupPhase;
            this.allowedPointsInGroupPhase = allowedPointsInGroupPhase;
            this.pointsDifferentialInGroupPhase = pointsDifferentialInGroupPhase;
            this.pointsInGroupPhase = pointsInGroupPhase;
            this.groupPhaseRanking = groupPhaseRanking;
            this.status = status;
            this.matches = matches;
        }

        public NationalTeam(NationalTeam nationalTeam)
        {
            name = nationalTeam.name;
            abbreviation = nationalTeam.abbreviation;
            fibaRanking = nationalTeam.fibaRanking;
            winsInGroupPhase = nationalTeam.winsInGroupPhase;
            lossesInGroupPhase = nationalTeam.lossesInGroupPhase;
            scoredPointsInGroupPhase = nationalTeam.scoredPointsInGroupPhase;
            allowedPointsInGroupPhase = nationalTeam.allowedPointsInGroupPhase;
            pointsDifferentialInGroupPhase = nationalTeam.pointsDifferentialInGroupPhase;
            pointsInGroupPhase = nationalTeam.pointsInGroupPhase;
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

        public int WinsInGroupPhase
        {
            get { return winsInGroupPhase; }
            set { winsInGroupPhase = value; }
        }

        public int LossesInGroupPhase
        {
            get { return lossesInGroupPhase; }
            set { lossesInGroupPhase = value; }
        }

        public int ScoredPointsInGroupPhase
        {
            get { return scoredPointsInGroupPhase; }
            set { scoredPointsInGroupPhase = value; }
        }

        public int AllowedPointsInGroupPhase
        {
            get { return allowedPointsInGroupPhase; }
            set { allowedPointsInGroupPhase = value; }
        }

        public int PointsDifferentialInGroupPhase
        {
            get { return pointsDifferentialInGroupPhase; }
            set { pointsDifferentialInGroupPhase = value; }
        }

        public int PointsInGroupPhase
        {
            get { return pointsInGroupPhase; }
            set { pointsInGroupPhase = value; }
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
