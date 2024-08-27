namespace FIBA_OT_sim.Model
{
    public class MatchResult
    {
        private int homeTeamPoints;
        private int guestTeamPoints;

        public MatchResult()
        {
            homeTeamPoints = 0;
            guestTeamPoints = 0;
        }

        public MatchResult(int homeTeamPoints, int guestTeamPoints)
        {
            this.homeTeamPoints = homeTeamPoints;
            this.guestTeamPoints = guestTeamPoints;
        }

        public MatchResult(MatchResult matchResult)
        {
            homeTeamPoints = matchResult.homeTeamPoints;
            guestTeamPoints = matchResult.guestTeamPoints;
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
    }
}
