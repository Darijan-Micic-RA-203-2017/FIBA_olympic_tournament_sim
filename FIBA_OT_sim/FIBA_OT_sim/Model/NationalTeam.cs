namespace FIBA_OT_sim.Model
{
    public class NationalTeam : IComparable<NationalTeam>
    {
        private long id;
        private string name;
        private string abbreviation;
        private int fibaRanking;
        private string groupName;
        private int winsInGroup;
        private int lossesInGroup;
        private int scoredPointsInGroup;
        private int allowedPointsInGroup;
        private int pointsDifferentialInGroup;
        private int pointsInGroup;
        private int groupRanking;
        private int groupPhaseRanking;
        private StatusOfNationalTeam status;
        private SideOfBracket sideOfBracket;
        private Match? facesWinnerInSemifinals;
        private IList<Match> matches;

        public NationalTeam()
        {
            id = 0L;
            name = "";
            abbreviation = "";
            fibaRanking = 0;
            groupName = "";
            winsInGroup = 0;
            lossesInGroup = 0;
            scoredPointsInGroup = 0;
            allowedPointsInGroup = 0;
            pointsDifferentialInGroup = 0;
            pointsInGroup = 0;
            groupRanking = 0;
            groupPhaseRanking = 0;
            status = StatusOfNationalTeam.COMPETING_IN_GROUP_PHASE;
            sideOfBracket = SideOfBracket.NO_SIDE;
            facesWinnerInSemifinals = null;
            matches = new List<Match>();
        }

        public NationalTeam(long id, string name, string abbreviation, int fibaRanking, string groupName, 
            int winsInGroup, int lossesInGroup, int scoredPointsInGroup, int allowedPointsInGroup, 
            int pointsDifferentialInGroup, int pointsInGroup, int groupRanking, int groupPhaseRanking, 
            StatusOfNationalTeam status, SideOfBracket sideOfBracket, Match? facesWinnerInSemifinals, 
            IList<Match> matches)
        {
            this.id = id;
            this.name = name;
            this.abbreviation = abbreviation;
            this.fibaRanking = fibaRanking;
            this.groupName = groupName;
            this.winsInGroup = winsInGroup;
            this.lossesInGroup = lossesInGroup;
            this.scoredPointsInGroup = scoredPointsInGroup;
            this.allowedPointsInGroup = allowedPointsInGroup;
            this.pointsDifferentialInGroup = pointsDifferentialInGroup;
            this.pointsInGroup = pointsInGroup;
            this.groupRanking = groupRanking;
            this.groupPhaseRanking = groupPhaseRanking;
            this.status = status;
            this.sideOfBracket = sideOfBracket;
            this.facesWinnerInSemifinals = facesWinnerInSemifinals;
            this.matches = matches;
        }

        public NationalTeam(NationalTeam nationalTeam)
        {
            id = nationalTeam.id;
            name = nationalTeam.name;
            abbreviation = nationalTeam.abbreviation;
            fibaRanking = nationalTeam.fibaRanking;
            groupName = nationalTeam.groupName;
            winsInGroup = nationalTeam.winsInGroup;
            lossesInGroup = nationalTeam.lossesInGroup;
            scoredPointsInGroup = nationalTeam.scoredPointsInGroup;
            allowedPointsInGroup = nationalTeam.allowedPointsInGroup;
            pointsDifferentialInGroup = nationalTeam.pointsDifferentialInGroup;
            pointsInGroup = nationalTeam.pointsInGroup;
            groupRanking = nationalTeam.groupRanking;
            groupPhaseRanking = nationalTeam.groupPhaseRanking;
            status = nationalTeam.status;
            sideOfBracket = nationalTeam.sideOfBracket;
            facesWinnerInSemifinals = nationalTeam.facesWinnerInSemifinals;
            matches = nationalTeam.matches;
        }

        public long Id
        {
            get { return id; }
            set { id = value; }
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

        public string GroupName
        {
            get { return groupName; }
            set { groupName = value; }
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

        public SideOfBracket SideOfBracket
        {
            get { return sideOfBracket; }
            set { sideOfBracket = value; }
        }

        public Match FacesWinnerInSemifinals
        {
            get { return facesWinnerInSemifinals; }
            set { facesWinnerInSemifinals = value; }
        }

        public IList<Match> Matches
        {
            get { return matches; }
            set { matches = value; }
        }

        public override int GetHashCode()
        {
            const int prime = 43;
            int result = 1;

            result = prime * result + Name.GetHashCode();
            result = prime * result + Abbreviation.GetHashCode();
            result = prime * result + FIBARanking.GetHashCode();
            result = prime * result + GroupName.GetHashCode();

            return result;
        }

        public override bool Equals(object? obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (obj is not NationalTeam)
            {
                return false;
            }

            NationalTeam other = (NationalTeam) obj;

            if (Id != other.Id)
            {
                return false;
            }

            if (!Name.Equals(other.Name))
            {
                return false;
            }

            if (!Abbreviation.Equals(other.Abbreviation))
            {
                return false;
            }

            if (FIBARanking != other.FIBARanking)
            {
                return false;
            }

            if (!GroupName.Equals(other.GroupName))
            {
                return false;
            }

            return true;
        }
        
        public int CompareTo(NationalTeam? other)
        {
            if (other == null)
            {
                throw new NullReferenceException();
            }

            if (this == other)
            {
                return 0;
            }

            if (Id < other.Id)
            {
                return -1;
            }
            else if (Id > other.Id)
            {
                return 1;
            }

            if (string.Compare(Name, other.Name) < 0)
            {
                return -1;
            }
            else if (string.Compare(Name, other.Name) > 0)
            {
                return 1;
            }

            if (string.Compare(Abbreviation, other.Abbreviation) < 0)
            {
                return -1;
            }
            else if (string.Compare(Abbreviation, other.Abbreviation) > 0)
            {
                return 1;
            }

            if (FIBARanking < other.FIBARanking)
            {
                return -1;
            }
            else if (FIBARanking > other.FIBARanking)
            {
                return 1;
            }

            if (string.Compare(GroupName, other.GroupName) < 0)
            {
                return -1;
            }
            else if (string.Compare(GroupName, other.GroupName) > 0)
            {
                return 1;
            }

            return 0;
        }
    }
}
