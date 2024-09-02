using FIBA_OT_sim.Model;

namespace FIBA_OT_sim.Services
{
    public class MatchService
    {
        public MatchService() { }

        public static void DetermineResultOfMatch(Match match)
        {
            int fibaRankingOfHomeTeam = match.HomeTeam.FIBARanking;
            int fibaRankingOfGuestTeam = match.GuestTeam.FIBARanking;
            bool homeTeamHigherRanked = false;
            int fibaRankingDifference = fibaRankingOfHomeTeam - fibaRankingOfGuestTeam;
            if (fibaRankingDifference < 0)
            {
                fibaRankingDifference *= -1;
                homeTeamHigherRanked = true;
            }

            double winProbabilityOfTeamWithHigherFIBARanking = 0.0;
            if (fibaRankingDifference == 1)
            {
                winProbabilityOfTeamWithHigherFIBARanking = 0.5;
            }
            else if (fibaRankingDifference == 2)
            {
                winProbabilityOfTeamWithHigherFIBARanking = 0.55;
            }
            else if (fibaRankingDifference == 3)
            {
                winProbabilityOfTeamWithHigherFIBARanking = 0.6;
            }
            else if (fibaRankingDifference == 4)
            {
                winProbabilityOfTeamWithHigherFIBARanking = 0.65;
            }
            else if (fibaRankingDifference == 5)
            {
                winProbabilityOfTeamWithHigherFIBARanking = 0.7;
            }
            else if (fibaRankingDifference == 6)
            {
                winProbabilityOfTeamWithHigherFIBARanking = 0.75;
            }
            else if (fibaRankingDifference == 7)
            {
                winProbabilityOfTeamWithHigherFIBARanking = 0.8;
            }
            else if (fibaRankingDifference == 8)
            {
                winProbabilityOfTeamWithHigherFIBARanking = 0.85;
            }
            else if (fibaRankingDifference == 9)
            {
                winProbabilityOfTeamWithHigherFIBARanking = 0.9;
            }
            else if (fibaRankingDifference >= 10)
            {
                winProbabilityOfTeamWithHigherFIBARanking = 0.95;
            }

            double randomProbability = Program.RandomNumberGenerator.NextDouble();
            if (randomProbability.CompareTo(winProbabilityOfTeamWithHigherFIBARanking) <= 0)
            {
                if (homeTeamHigherRanked)
                {
                    match.Result = new MatchResult(match.Id, 85, 85 - fibaRankingDifference);
                }
                else
                {
                    match.Result = new MatchResult(match.Id, 85 - fibaRankingDifference, 85);
                }
            }
            else
            {
                if (homeTeamHigherRanked)
                {
                    match.Result = new MatchResult(match.Id, 85 - fibaRankingDifference, 85);
                }
                else
                {
                    match.Result = new MatchResult(match.Id, 85, 85 - fibaRankingDifference);
                }
            }
        }

        public static NationalTeam GetNationalTeamThatWonMatch(Match match)
        {
            NationalTeam nationalTeamThatWonMatch = new NationalTeam();
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
            NationalTeam nationalTeamThatLostMatch = new NationalTeam();
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

        public static Match? FindMatchBetweenTeams(NationalTeam team1, NationalTeam team2, 
            bool isHomeGuestSlottingImportant)
        {
            foreach (Match match in team1.Matches)
            {
                if (match.IsMatchBetweenTeams(team1, team2, isHomeGuestSlottingImportant))
                {
                    return match;
                }
            }

            return null;
        }
    }
}
