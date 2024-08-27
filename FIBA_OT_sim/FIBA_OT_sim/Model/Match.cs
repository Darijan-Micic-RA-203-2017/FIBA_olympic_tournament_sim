namespace FIBA_OT_sim.Model
{
    public class Match
    {
        private NationalTeam homeTeam;
        private NationalTeam guestTeam;
        private MatchResult result;

        public Match()
        {
            homeTeam = new NationalTeam();
            guestTeam = new NationalTeam();
            result = new MatchResult();
        }

        public Match(NationalTeam homeTeam, NationalTeam guestTeam, MatchResult result)
        {
            this.homeTeam = homeTeam;
            this.guestTeam = guestTeam;
            this.result = result;
        }

        public Match(Match match)
        {
            homeTeam = match.homeTeam;
            guestTeam = match.guestTeam;
            result = match.result;
        }

        public NationalTeam HomeTeam
        {
            get { return homeTeam; }
            set { homeTeam = value; }
        }

        public NationalTeam GuestTeam
        {
            get { return guestTeam; }
            set { guestTeam = value; }
        }

        public MatchResult Result
        {
            get { return result; }
            set { result = value; }
        }
    }
}
