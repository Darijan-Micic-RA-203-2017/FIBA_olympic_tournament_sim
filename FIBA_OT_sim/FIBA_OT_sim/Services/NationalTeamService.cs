using FIBA_OT_sim.Model;
using FIBA_OT_sim.Repositories;

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
                    if (copyOfNationalTeam.Equals(match.HomeTeam))
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
                    else if (copyOfNationalTeam.Equals(match.GuestTeam))
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
                .OrderByDescending((nationalTeam) => nationalTeam.PointsDifferentialInGroup)
                .ThenByDescending((nationalTeam) => nationalTeam.ScoredPointsInGroup)
                .ThenBy((nationalTeam) => nationalTeam.FIBARanking)
                .ToList();
        }

        public static IList<NationalTeam> SortNationalTeamsWithSameGroupRankingByFIBARules(
            IList<NationalTeam> nationalTeamsWithSameGroupRanking)
        {
            return nationalTeamsWithSameGroupRanking
                .OrderByDescending((nationalTeam) => nationalTeam.PointsInGroup)
                .ThenByDescending((nationalTeam) => nationalTeam.PointsDifferentialInGroup)
                .ThenByDescending((nationalTeam) => nationalTeam.ScoredPointsInGroup)
                .ThenBy((nationalTeam) => nationalTeam.FIBARanking)
                .ToList();
        }

        public static void ChangeStatusesOfAllNationalTeamsAfterGroupPhase()
        {
            foreach (Group group in GroupPhaseRepository.GroupPhase.Groups)
            {
                foreach (NationalTeam nationalTeam in group.Teams)
                {
                    if (nationalTeam.GroupPhaseRanking <= 8)
                    {
                        nationalTeam.Status = StatusOfNationalTeam.COMPETING_IN_QUARTERFINALS;
                    }
                    else
                    {
                        nationalTeam.Status = StatusOfNationalTeam.ELIMINATED_IN_GROUP_PHASE;
                    }
                }
            }
        }
    }
}
