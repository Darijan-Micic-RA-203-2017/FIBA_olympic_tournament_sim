using FIBA_OT_sim.Model;

namespace FIBA_OT_sim.Services
{
    public class MatchService
    {
        public MatchService() { }

        public static NationalTeam GetNationalTeamThatWonMatch(Match match)
        {
            NationalTeam nationalTeamThatWonMatch = null;
            if (match.Result.HomeTeamPoints - match.Result.GuestTeamPoints > 0)
            {
                nationalTeamThatWonMatch = match.HomeTeam;
            }
            else
            {
                nationalTeamThatWonMatch = match.GuestTeam;
            }

            return nationalTeamThatWonMatch;
        }

        public static NationalTeam GetNationalTeamThatLostMatch(Match match)
        {
            NationalTeam nationalTeamThatLostMatch = null;
            if (match.Result.HomeTeamPoints - match.Result.GuestTeamPoints < 0)
            {
                nationalTeamThatLostMatch = match.HomeTeam;
            }
            else
            {
                nationalTeamThatLostMatch = match.GuestTeam;
            }

            return nationalTeamThatLostMatch;
        }

        public static Match FindMatchBetweenTeams(NationalTeam team1, NationalTeam team2)
        {
            foreach (Match match in team1.Matches)
            {
                if (match.IsMatchBetweenTeams(team1, team2))
                {
                    return match;
                }
            }

            return null;
        }
    }
}
