namespace FIBA_OT_sim.Model
{
    public class Match
    {
        private TournamentPhaseOfMatch tournamentPhase;
        private NationalTeam homeTeam;
        private NationalTeam guestTeam;
        private MatchResult result;

        public Match()
        {
            tournamentPhase = TournamentPhaseOfMatch.FIRST_ROUND_OF_GROUP_PHASE;
            homeTeam = new NationalTeam();
            guestTeam = new NationalTeam();
            result = new MatchResult();
        }

        public Match(TournamentPhaseOfMatch tournamentPhase, NationalTeam homeTeam, NationalTeam guestTeam, 
            MatchResult result)
        {
            this.tournamentPhase = tournamentPhase;
            this.homeTeam = homeTeam;
            this.guestTeam = guestTeam;
            this.result = result;
        }

        public Match(Match match)
        {
            tournamentPhase = match.tournamentPhase;
            homeTeam = match.homeTeam;
            guestTeam = match.guestTeam;
            result = match.result;
        }

        public TournamentPhaseOfMatch TournamentPhase
        {
            get { return tournamentPhase; }
            set { tournamentPhase = value; }
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

        public bool IsMatchBetweenTeams(NationalTeam team1, NationalTeam team2)
        {
            return (homeTeam.Name.Equals(team1.Name) && guestTeam.Name.Equals(team2.Name)) 
                || (homeTeam.Name.Equals(team2.Name) && guestTeam.Name.Equals(team1.Name));
        }
    }
}
