using FIBA_OT_sim.Model;
using FIBA_OT_sim.Repositories;

namespace FIBA_OT_sim.Services
{
    public class NationalTeamService
    {
        public NationalTeamService() { }

        public static void UpdateStatsOfNationalTeamsWhoPlayedInGroupMatch(Match groupMatch)
        {
            int homeTeamPoints = groupMatch.Result.HomeTeamPoints;
            int guestTeamPoints = groupMatch.Result.GuestTeamPoints;
            int pointsDifferentialAdditionForHomeTeam = homeTeamPoints - guestTeamPoints;
            int pointsDifferentialAdditionForGuestTeam = pointsDifferentialAdditionForHomeTeam * -1;

            groupMatch.HomeTeam.ScoredPointsInGroup += homeTeamPoints;
            groupMatch.HomeTeam.AllowedPointsInGroup += guestTeamPoints;
            groupMatch.HomeTeam.PointsDifferentialInGroup += pointsDifferentialAdditionForHomeTeam;
            groupMatch.GuestTeam.ScoredPointsInGroup += guestTeamPoints;
            groupMatch.GuestTeam.AllowedPointsInGroup += homeTeamPoints;
            groupMatch.GuestTeam.PointsDifferentialInGroup += pointsDifferentialAdditionForGuestTeam;
            if (pointsDifferentialAdditionForHomeTeam > 0)
            {
                groupMatch.HomeTeam.WinsInGroup += 1;
                groupMatch.HomeTeam.PointsInGroup += 2;
                groupMatch.GuestTeam.LossesInGroup += 1;
                groupMatch.GuestTeam.PointsInGroup += 1;
            }
            else
            {
                groupMatch.HomeTeam.LossesInGroup += 1;
                groupMatch.HomeTeam.PointsInGroup += 1;
                groupMatch.GuestTeam.WinsInGroup += 1;
                groupMatch.GuestTeam.PointsInGroup += 2;
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

        public static IList<NationalTeam> GetNationalTeamsQualifiedToEliminationPhase()
        {
            IList<NationalTeam> nationalTeamsQualifiedToEliminationPhase = new List<NationalTeam>();
            foreach (Group group in GroupPhaseRepository.GroupPhase.Groups)
            {
                foreach (NationalTeam nationalTeam in group.Teams)
                {
                    if (nationalTeam.Status != StatusOfNationalTeam.COMPETING_IN_GROUP_PHASE 
                        && nationalTeam.Status != StatusOfNationalTeam.ELIMINATED_IN_GROUP_PHASE)
                    {
                        nationalTeamsQualifiedToEliminationPhase.Add(nationalTeam);
                    }
                }
            }
            nationalTeamsQualifiedToEliminationPhase = nationalTeamsQualifiedToEliminationPhase
                .OrderBy((nationalTeam) => nationalTeam.GroupPhaseRanking).ToList();

            return nationalTeamsQualifiedToEliminationPhase;
        }

        public static void ChangeStatusesOfNationalTeamsAfterQuarterFinalsMatch(Match quarterFinalsMatch)
        {
            NationalTeam nationalTeamThatWonQuarterFinalsMatch = 
                MatchService.GetNationalTeamThatWonMatch(quarterFinalsMatch);
            nationalTeamThatWonQuarterFinalsMatch.Status = StatusOfNationalTeam.COMPETING_IN_SEMIFINALS;

            NationalTeam nationalTeamThatLostQuarterFinalsMatch = 
                MatchService.GetNationalTeamThatLostMatch(quarterFinalsMatch);
            nationalTeamThatLostQuarterFinalsMatch.Status = StatusOfNationalTeam.ELIMINATED_IN_QUARTERFINALS;
        }

        public static IList<NationalTeam> GetNationalTeamsQualifiedToSemiFinals()
        {
            IList<NationalTeam> nationalTeamsQualifiedToSemiFinals = new List<NationalTeam>();
            foreach (Group group in GroupPhaseRepository.GroupPhase.Groups)
            {
                foreach (NationalTeam nationalTeam in group.Teams)
                {
                    if (nationalTeam.Status == StatusOfNationalTeam.COMPETING_IN_SEMIFINALS)
                    {
                        nationalTeamsQualifiedToSemiFinals.Add(nationalTeam);
                    }
                }
            }

            return nationalTeamsQualifiedToSemiFinals;
        }

        public static void ChangeStatusesOfNationalTeamsAfterSemiFinalsMatch(Match semiFinalsMatch)
        {
            NationalTeam nationalTeamThatWonSemiFinalsMatch = 
                MatchService.GetNationalTeamThatWonMatch(semiFinalsMatch);
            nationalTeamThatWonSemiFinalsMatch.Status = StatusOfNationalTeam.COMPETING_IN_FINALS;

            NationalTeam nationalTeamThatLostSemiFinalsMatch = 
                MatchService.GetNationalTeamThatLostMatch(semiFinalsMatch);
            nationalTeamThatLostSemiFinalsMatch.Status = StatusOfNationalTeam.COMPETING_IN_THIRD_PLACE_MATCH;
        }
    }
}
