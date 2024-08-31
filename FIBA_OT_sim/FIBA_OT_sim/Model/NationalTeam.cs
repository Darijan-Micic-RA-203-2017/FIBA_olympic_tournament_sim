namespace FIBA_OT_sim.Model
{
    public class NationalTeam
    {
        private string name;
        private string abbreviation;
        private int fibaRanking;
        private int winsInGroup;
        private int lossesInGroup;
        private int scoredPointsInGroup;
        private int allowedPointsInGroup;
        private int pointsDifferentialInGroup;
        private int pointsInGroup;
        private int groupRanking;
        private int groupPhaseRanking;
        private StatusOfNationalTeam status;
        private IList<Match> matches;

        public NationalTeam()
        {
            name = "";
            abbreviation = "";
            fibaRanking = 0;
            winsInGroup = 0;
            lossesInGroup = 0;
            scoredPointsInGroup = 0;
            allowedPointsInGroup = 0;
            pointsDifferentialInGroup = 0;
            pointsInGroup = 0;
            groupRanking = 0;
            groupPhaseRanking = 0;
            status = StatusOfNationalTeam.COMPETING_IN_GROUP_PHASE;
            matches = new List<Match>();
        }

        public NationalTeam(string name, string abbreviation, int fibaRanking, int winsInGroup, 
            int lossesInGroup, int scoredPointsInGroup, int allowedPointsInGroup, int pointsDifferentialInGroup, 
            int pointsInGroup, int groupRanking, int groupPhaseRanking, StatusOfNationalTeam status, 
            IList<Match> matches)
        {
            this.name = name;
            this.abbreviation = abbreviation;
            this.fibaRanking = fibaRanking;
            this.winsInGroup = winsInGroup;
            this.lossesInGroup = lossesInGroup;
            this.scoredPointsInGroup = scoredPointsInGroup;
            this.allowedPointsInGroup = allowedPointsInGroup;
            this.pointsDifferentialInGroup = pointsDifferentialInGroup;
            this.pointsInGroup = pointsInGroup;
            this.groupRanking = groupRanking;
            this.groupPhaseRanking = groupPhaseRanking;
            this.status = status;
            this.matches = matches;
        }

        public NationalTeam(NationalTeam nationalTeam)
        {
            name = nationalTeam.name;
            abbreviation = nationalTeam.abbreviation;
            fibaRanking = nationalTeam.fibaRanking;
            winsInGroup = nationalTeam.winsInGroup;
            lossesInGroup = nationalTeam.lossesInGroup;
            scoredPointsInGroup = nationalTeam.scoredPointsInGroup;
            allowedPointsInGroup = nationalTeam.allowedPointsInGroup;
            pointsDifferentialInGroup = nationalTeam.pointsDifferentialInGroup;
            pointsInGroup = nationalTeam.pointsInGroup;
            groupRanking = nationalTeam.groupRanking;
            groupPhaseRanking = nationalTeam.groupPhaseRanking;
            status = nationalTeam.status;
            matches = new List<Match>();
            foreach (Match originalMatch in nationalTeam.matches)
            {
                matches.Add(new Match(originalMatch));
            }
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

        public int WinsInGroup
        {
            get { return winsInGroup; }
            set { winsInGroup = value; }
        }

        public int LossesInGroup
        {
            get { return lossesInGroup; }
            set { lossesInGroup = value; }
        }

        public int ScoredPointsInGroup
        {
            get { return scoredPointsInGroup; }
            set { scoredPointsInGroup = value; }
        }

        public int AllowedPointsInGroup
        {
            get { return allowedPointsInGroup; }
            set { allowedPointsInGroup = value; }
        }

        public int PointsDifferentialInGroup
        {
            get { return pointsDifferentialInGroup; }
            set { pointsDifferentialInGroup = value; }
        }

        public int PointsInGroup
        {
            get { return pointsInGroup; }
            set { pointsInGroup = value; }
        }

        public int GroupRanking
        {
            get { return groupRanking; }
            set { groupRanking = value; }
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
