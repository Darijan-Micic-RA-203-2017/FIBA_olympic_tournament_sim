﻿using FIBA_OT_sim.Model;
using FIBA_OT_sim.Repositories;

namespace FIBA_OT_sim.Services
{
    public class GroupPhaseService
    {
        private GroupPhaseRepository groupPhaseRepository;

        public GroupPhaseService()
        {
            groupPhaseRepository = new GroupPhaseRepository();
        }

        public GroupPhaseRepository GroupPhaseRepository
        {
            get { return groupPhaseRepository; }
            set { groupPhaseRepository = value; }
        }

        public void LoadGroupPhaseFromFileSystem(string filePath)
        {
            groupPhaseRepository.LoadGroupPhaseFromFileSystem(filePath);
        }

        public void SimulateGroupPhase()
        {
            foreach (Group group in GroupPhaseRepository.GroupPhase.Groups)
            {
                ScheduleMatchesOfGroup(group);
                foreach (Match match in group.Matches)
                {
                    MatchService.DetermineResultOfMatch(match);
                    NationalTeamService.UpdateStatsOfNationalTeamsWhoPlayedInGroupMatch(match);
                }
                RankNationalTeamsInGroup(group);
            }
            RankNationalTeamsInGroupPhase();
            PrintingService.PrintGroupPhase();
        }

        private void ScheduleMatchesOfGroup(Group group)
        {
            Match match1 = new Match(++Program.LastMatchId, TournamentPhaseOfMatch.FIRST_ROUND_OF_GROUP_PHASE, 
                group.Teams[0], group.Teams[3], new MatchResult());
            group.Matches.Add(match1);
            group.Teams[0].Matches.Add(match1);
            group.Teams[3].Matches.Add(match1);
            
            Match match2 = new Match(++Program.LastMatchId, TournamentPhaseOfMatch.FIRST_ROUND_OF_GROUP_PHASE, 
                group.Teams[2], group.Teams[1], new MatchResult());
            group.Matches.Add(match2);
            group.Teams[2].Matches.Add(match2);
            group.Teams[1].Matches.Add(match2);
            
            Match match3 = new Match(++Program.LastMatchId, TournamentPhaseOfMatch.SECOND_ROUND_OF_GROUP_PHASE, 
                group.Teams[1], group.Teams[0], new MatchResult());
            group.Matches.Add(match3);
            group.Teams[1].Matches.Add(match3);
            group.Teams[0].Matches.Add(match3);
            
            Match match4 = new Match(++Program.LastMatchId, TournamentPhaseOfMatch.SECOND_ROUND_OF_GROUP_PHASE, 
                group.Teams[3], group.Teams[2], new MatchResult());
            group.Matches.Add(match4);
            group.Teams[3].Matches.Add(match4);
            group.Teams[2].Matches.Add(match4);
            
            Match match5 = new Match(++Program.LastMatchId, TournamentPhaseOfMatch.THIRD_ROUND_OF_GROUP_PHASE, 
                group.Teams[0], group.Teams[2], new MatchResult());
            group.Matches.Add(match5);
            group.Teams[0].Matches.Add(match5);
            group.Teams[2].Matches.Add(match5);
            
            Match match6 = new Match(++Program.LastMatchId, TournamentPhaseOfMatch.THIRD_ROUND_OF_GROUP_PHASE, 
                group.Teams[1], group.Teams[3], new MatchResult());
            group.Matches.Add(match6);
            group.Teams[1].Matches.Add(match6);
            group.Teams[3].Matches.Add(match6);
        }
        
        public void RankNationalTeamsInGroup(Group group)
        {
            group.Teams = group.Teams.OrderByDescending((nationalTeam) => nationalTeam.PointsInGroup).ToList();
            
            IList<List<NationalTeam>> subgroupsWithSameNumberOfPoints = 
                SeparateNationalTeamsIntoSubgroupsBasedOnPointsInGroup(group);
            
            int groupRanking = 1;
            foreach (List<NationalTeam> subgroup in subgroupsWithSameNumberOfPoints)
            {
                if (subgroup.Count == 1)
                {
                    subgroup[0].GroupRanking = groupRanking;
                    groupRanking++;
                }
                else if (subgroup.Count == 2)
                {
                    groupRanking = RankNationalTeamsInSubgroupOfTwoTeams(subgroup, groupRanking);
                }
                else
                {
                    groupRanking = RankNationalTeamsInSubgroupOfMoreThanTwoTeams(subgroup, groupRanking);
                }
            }
            
            group.Teams = group.Teams.OrderBy((nationalTeam) => nationalTeam.GroupRanking).ToList();
        }

        private IList<List<NationalTeam>> SeparateNationalTeamsIntoSubgroupsBasedOnPointsInGroup(Group group)
        {
            IList<List<NationalTeam>> subgroupsWithSameNumberOfPoints = new List<List<NationalTeam>>();
            subgroupsWithSameNumberOfPoints.Add(new List<NationalTeam>());
            NationalTeam firstTeam = group.Teams[0];
            subgroupsWithSameNumberOfPoints[0].Add(firstTeam);

            NationalTeam previousNationalTeam = firstTeam;
            for (int i = 1; i < group.Teams.Count; i++)
            {
                if (group.Teams[i].PointsInGroup == previousNationalTeam.PointsInGroup)
                {
                    subgroupsWithSameNumberOfPoints[subgroupsWithSameNumberOfPoints.Count - 1]
                        .Add(group.Teams[i]);

                    previousNationalTeam = group.Teams[i];
                }
                else
                {
                    subgroupsWithSameNumberOfPoints.Add(new List<NationalTeam>());
                    subgroupsWithSameNumberOfPoints[subgroupsWithSameNumberOfPoints.Count - 1]
                        .Add(group.Teams[i]);

                    previousNationalTeam = group.Teams[i];
                }
            }

            return subgroupsWithSameNumberOfPoints;
        }

        private int RankNationalTeamsInSubgroupOfTwoTeams(IList<NationalTeam> subgroup, int groupRanking)
        {
            Match? match = MatchService.FindMatchBetweenTeams(subgroup[0], subgroup[1], false);
            if (match == null)
            {
                return groupRanking;
            }

            NationalTeam nationalTeamThatWonMatch = MatchService.GetNationalTeamThatWonMatch(match);
            if (nationalTeamThatWonMatch.Equals(subgroup[0]))
            {
                subgroup[0].GroupRanking = groupRanking;
                groupRanking++;
                subgroup[1].GroupRanking = groupRanking;
            }
            else
            {
                subgroup[1].GroupRanking = groupRanking;
                groupRanking++;
                subgroup[0].GroupRanking = groupRanking;
            }

            groupRanking++;

            return groupRanking;
        }

        private int RankNationalTeamsInSubgroupOfMoreThanTwoTeams(IList<NationalTeam> subgroup, int groupRanking)
        {
            IList<Match> matchesBetweenTeamsInCircle = FindMatchesBetweenTeamsInCircle(subgroup);
            IList<NationalTeam> copiesOfNationalTeamsInCircle = CreateCopiesOfNationalTeamsInCircle(subgroup);
            NationalTeamService.UpdateStatsOfNationalTeamsInCircle(matchesBetweenTeamsInCircle, 
                copiesOfNationalTeamsInCircle);
            copiesOfNationalTeamsInCircle = NationalTeamService.SortNationalTeamsInCircleByFIBARules(
                copiesOfNationalTeamsInCircle);
            groupRanking = AssignGroupRankingsToOriginalNationalTeamsInSubgroup(subgroup, 
                copiesOfNationalTeamsInCircle, groupRanking);
            
            return groupRanking;
        }

        private IList<Match> FindMatchesBetweenTeamsInCircle(IList<NationalTeam> subgroup)
        {
            IList<Match> matchesBetweenTeamsInCircle = new List<Match>();
            for (int i = 0; i < subgroup.Count - 1; i++)
            {
                for (int j = i + 1; j < subgroup.Count; j++)
                {
                    Match? matchBetweenTwoTeamsInCircle = 
                        MatchService.FindMatchBetweenTeams(subgroup[i], subgroup[j], false);
                    if (matchBetweenTwoTeamsInCircle == null)
                    {
                        return matchesBetweenTeamsInCircle;
                    }

                    matchesBetweenTeamsInCircle.Add(matchBetweenTwoTeamsInCircle);
                }
            }

            return matchesBetweenTeamsInCircle;
        }

        private IList<NationalTeam> CreateCopiesOfNationalTeamsInCircle(IList<NationalTeam> subgroup)
        {
            IList<NationalTeam> copiesOfNationalTeamsInCircle = new List<NationalTeam>();
            foreach (NationalTeam originalNationalTeam in subgroup)
            {
                NationalTeam copyOfNationalTeam = new NationalTeam(originalNationalTeam);
                copyOfNationalTeam.WinsInGroup = 0;
                copyOfNationalTeam.LossesInGroup = 0;
                copyOfNationalTeam.ScoredPointsInGroup = 0;
                copyOfNationalTeam.AllowedPointsInGroup = 0;
                copyOfNationalTeam.PointsDifferentialInGroup = 0;
                copyOfNationalTeam.PointsInGroup = 0;
                
                copiesOfNationalTeamsInCircle.Add(copyOfNationalTeam);
            }
            
            return copiesOfNationalTeamsInCircle;
        }
        
        private int AssignGroupRankingsToOriginalNationalTeamsInSubgroup(IList<NationalTeam> subgroup, 
            IList<NationalTeam> copiesOfNationalTeamsInCircle, int groupRanking)
        {
            foreach (NationalTeam copyOfNationalTeam in copiesOfNationalTeamsInCircle)
            {
                copyOfNationalTeam.GroupRanking = groupRanking;
                foreach (NationalTeam originalNationalTeam in subgroup)
                {
                    if (originalNationalTeam.Equals(copyOfNationalTeam))
                    {
                        originalNationalTeam.GroupRanking = copyOfNationalTeam.GroupRanking;

                        break;
                    }
                }

                groupRanking++;
            }

            return groupRanking;
        }

        public void RankNationalTeamsInGroupPhase()
        {
            IList<List<NationalTeam>> subgroupsWithSameGroupRanking = new List<List<NationalTeam>>();
            for (int groupRanking = 1; groupRanking <= GroupPhaseRepository.GroupPhase.Groups[0].Teams.Count; 
                groupRanking++)
            {
                subgroupsWithSameGroupRanking.Add(FindTeamsWithSameGroupRanking(groupRanking));

                IList<NationalTeam> latestAddedSubgroup = 
                    subgroupsWithSameGroupRanking[subgroupsWithSameGroupRanking.Count - 1];
                latestAddedSubgroup = 
                    NationalTeamService.SortNationalTeamsWithSameGroupRankingByFIBARules(latestAddedSubgroup);
                AssignGroupPhaseRankingsToNationalTeamsInSubgroup(latestAddedSubgroup, groupRanking);
            }

            NationalTeamService.ChangeStatusesOfAllNationalTeamsAfterGroupPhase();
        }

        private List<NationalTeam> FindTeamsWithSameGroupRanking(int groupRanking)
        {
            List<NationalTeam> nationalTeamsWithSameGroupRanking = new List<NationalTeam>();
            foreach (Group group in GroupPhaseRepository.GroupPhase.Groups)
            {
                nationalTeamsWithSameGroupRanking.Add(group.Teams[groupRanking - 1]);
            }

            return nationalTeamsWithSameGroupRanking;
        }

        private void AssignGroupPhaseRankingsToNationalTeamsInSubgroup(IList<NationalTeam> subgroup, 
            int groupRanking)
        {
            int minGroupPhaseRankingInThisSubgroup = subgroup.Count * groupRanking - (subgroup.Count - 1);
            int groupPhaseRanking = minGroupPhaseRankingInThisSubgroup;
            foreach (NationalTeam nationalTeam in subgroup)
            {
                nationalTeam.GroupPhaseRanking = groupPhaseRanking;
                groupPhaseRanking++;
            }
        }
    }
}
