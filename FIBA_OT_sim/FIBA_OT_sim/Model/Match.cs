namespace FIBA_OT_sim.Model
{
    public class Match : IComparable<Match>
    {
        private long id;
        private TournamentPhaseOfMatch tournamentPhase;
        private NationalTeam homeTeam;
        private NationalTeam guestTeam;
        private MatchResult result;

        public Match()
        {
            id = 0L;
            tournamentPhase = TournamentPhaseOfMatch.FIRST_ROUND_OF_GROUP_PHASE;
            homeTeam = new NationalTeam();
            guestTeam = new NationalTeam();
            result = new MatchResult();
        }

        public Match(long id, TournamentPhaseOfMatch tournamentPhase, NationalTeam homeTeam, 
            NationalTeam guestTeam, MatchResult result)
        {
            this.id = id;
            this.tournamentPhase = tournamentPhase;
            this.homeTeam = homeTeam;
            this.guestTeam = guestTeam;
            this.result = result;
        }

        public Match(Match match)
        {
            id = match.id;
            tournamentPhase = match.tournamentPhase;
            homeTeam = match.homeTeam;
            guestTeam = match.guestTeam;
            result = match.result;
        }

        public long Id
        {
            get { return id; }
            set { id = value; }
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

        public bool IsMatchBetweenTeams(NationalTeam team1, NationalTeam team2, 
            bool isHomeGuestSlottingImportant)
        {
            if (isHomeGuestSlottingImportant)
            {
                return homeTeam.Equals(team1) && guestTeam.Equals(team2);
            }
            else
            {
                return (homeTeam.Equals(team1) && guestTeam.Equals(team2)) 
                    || (homeTeam.Equals(team2) && guestTeam.Equals(team1));
            }
        }

        public override int GetHashCode()
        {
            const int prime = 53;
            int result = 1;

            result = prime * result + TournamentPhase.GetHashCode();

            return result;
        }

        public override bool Equals(object? obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (obj is not Match aTeam)
            {
                return false;
            }

            Match other = (Match) obj;

            if (Id != other.Id)
            {
                return false;
            }

            if (TournamentPhase != other.TournamentPhase)
            {
                return false;
            }

            return true;
        }

        public int CompareTo(Match? other)
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

            if (TournamentPhase < other.TournamentPhase)
            {
                return -1;
            }
            else if (TournamentPhase > other.TournamentPhase)
            {
                return 1;
            }

            return 0;
        }
    }
}
