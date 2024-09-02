namespace FIBA_OT_sim.Model
{
    public class MatchResult : IComparable<MatchResult>
    {
        private long matchId;
        private int homeTeamPoints;
        private int guestTeamPoints;

        public MatchResult()
        {
            matchId = 0L;
            homeTeamPoints = 0;
            guestTeamPoints = 0;
        }

        public MatchResult(long matchId, int homeTeamPoints, int guestTeamPoints)
        {
            this.matchId = matchId;
            this.homeTeamPoints = homeTeamPoints;
            this.guestTeamPoints = guestTeamPoints;
        }

        public MatchResult(MatchResult matchResult)
        {
            matchId = matchResult.matchId;
            homeTeamPoints = matchResult.homeTeamPoints;
            guestTeamPoints = matchResult.guestTeamPoints;
        }

        public long MatchId
        {
            get { return matchId; }
            set { matchId = value; }
        }

        public int HomeTeamPoints
        {
            get { return homeTeamPoints; }
            set { homeTeamPoints = value; }
        }

        public int GuestTeamPoints
        {
            get { return guestTeamPoints; }
            set { guestTeamPoints = value; }
        }

        public override int GetHashCode()
        {
            const int prime = 53;
            int result = 1;

            result = prime * result + HomeTeamPoints.GetHashCode();
            result = prime * result + GuestTeamPoints.GetHashCode();

            return result;
        }

        public override bool Equals(object? obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (obj is not MatchResult)
            {
                return false;
            }

            MatchResult other = (MatchResult) obj;

            if (MatchId != other.MatchId)
            {
                return false;
            }

            if (HomeTeamPoints != other.HomeTeamPoints)
            {
                return false;
            }

            if (GuestTeamPoints != other.GuestTeamPoints)
            {
                return false;
            }
            
            return true;
        }

        public int CompareTo(MatchResult? other)
        {
            if (other == null)
            {
                throw new NullReferenceException();
            }

            if (this == other)
            {
                return 0;
            }

            if (MatchId < other.MatchId)
            {
                return -1;
            }
            else if (MatchId > other.MatchId)
            {
                return 1;
            }

            if (HomeTeamPoints < other.HomeTeamPoints)
            {
                return -1;
            }
            else if (HomeTeamPoints > other.HomeTeamPoints)
            {
                return 1;
            }

            if (GuestTeamPoints < other.GuestTeamPoints)
            {
                return -1;
            }
            else if (GuestTeamPoints > other.GuestTeamPoints)
            {
                return 1;
            }
            
            return 0;
        }
    }
}
