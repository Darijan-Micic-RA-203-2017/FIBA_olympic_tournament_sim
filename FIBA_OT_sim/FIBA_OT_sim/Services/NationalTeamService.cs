using FIBA_OT_sim.Model;

namespace FIBA_OT_sim.Services
{
    public class NationalTeamService
    {
        public NationalTeamService() { }

        public static void UpdateStatsOfNationalTeamsWhoPlayedInMatch(Match match)
        {
            int homeTeamPoints = match.Result.HomeTeamPoints;
            int guestTeamPoints = match.Result.GuestTeamPoints;
            int pointsDifferentialAdditionForHomeTeam = homeTeamPoints - guestTeamPoints;
            int pointsDifferentialAdditionForGuestTeam = pointsDifferentialAdditionForHomeTeam * -1;

            match.HomeTeam.ScoredPointsInGroup += homeTeamPoints;
            match.HomeTeam.AllowedPointsInGroup += guestTeamPoints;
            match.HomeTeam.PointsDifferentialInGroup += pointsDifferentialAdditionForHomeTeam;
            match.GuestTeam.ScoredPointsInGroup += guestTeamPoints;
            match.GuestTeam.AllowedPointsInGroup += homeTeamPoints;
            match.GuestTeam.PointsDifferentialInGroup += pointsDifferentialAdditionForGuestTeam;
            if (pointsDifferentialAdditionForHomeTeam > 0)
            {
                match.HomeTeam.WinsInGroup += 1;
                match.HomeTeam.PointsInGroup += 2;
                match.GuestTeam.LossesInGroup += 1;
                match.GuestTeam.PointsInGroup += 1;
            }
            else
            {
                match.HomeTeam.LossesInGroup += 1;
                match.HomeTeam.PointsInGroup += 1;
                match.GuestTeam.WinsInGroup += 1;
                match.GuestTeam.PointsInGroup += 2;
            }
        }

        public static void UpdateStatsOfNationalTeamsInCircle(IList<Match> matchesBetweenTeamsInCircle, 
            IList<NationalTeam> copiesOfNationalTeamsInCircle)
        {
            foreach (Match match in matchesBetweenTeamsInCircle)
            {
                int homeTeamPoints = match.Result.HomeTeamPoints;
                int guestTeamPoints = match.Result.GuestTeamPoints;
                int pointsDifferentialAdditionForHomeTeam = homeTeamPoints - guestTeamPoints;
                int pointsDifferentialAdditionForGuestTeam = pointsDifferentialAdditionForHomeTeam * -1;
                foreach (NationalTeam copyOfNationalTeam in copiesOfNationalTeamsInCircle)
                {
                    if (copyOfNationalTeam.Name.Equals(match.HomeTeam.Name))
                    {
                        copyOfNationalTeam.ScoredPointsInGroup += homeTeamPoints;
                        copyOfNationalTeam.AllowedPointsInGroup += guestTeamPoints;
                        copyOfNationalTeam.PointsDifferentialInGroup += pointsDifferentialAdditionForHomeTeam;
                        if (pointsDifferentialAdditionForHomeTeam > 0)
                        {
                            copyOfNationalTeam.WinsInGroup += 1;
                            copyOfNationalTeam.PointsInGroup += 2;
                        }
                        else
                        {
                            copyOfNationalTeam.LossesInGroup += 1;
                            copyOfNationalTeam.PointsInGroup += 1;
                        }
                    }
                    else if (copyOfNationalTeam.Name.Equals(match.GuestTeam.Name))
                    {
                        copyOfNationalTeam.ScoredPointsInGroup += guestTeamPoints;
                        copyOfNationalTeam.AllowedPointsInGroup += homeTeamPoints;
                        copyOfNationalTeam.PointsDifferentialInGroup += pointsDifferentialAdditionForGuestTeam;
                        if (pointsDifferentialAdditionForGuestTeam > 0)
                        {
                            copyOfNationalTeam.WinsInGroup += 1;
                            copyOfNationalTeam.PointsInGroup += 2;
                        }
                        else
                        {
                            copyOfNationalTeam.LossesInGroup += 1;
                            copyOfNationalTeam.PointsInGroup += 1;
                        }
                    }
                }
            }
        }

        public static IList<NationalTeam> SortNationalTeamsInCircleByFIBARules(
            IList<NationalTeam> nationalTeamsInCircle)
        {
            return nationalTeamsInCircle
                .OrderByDescending((copyOfNationalTeam) => copyOfNationalTeam.PointsDifferentialInGroup)
                .ThenByDescending((copyOfNationalTeam) => copyOfNationalTeam.ScoredPointsInGroup)
                .ThenBy((copyOfNationalTeam) => copyOfNationalTeam.FIBARanking)
                .ToList();
        }
    }
}
