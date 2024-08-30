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
            foreach (Group group in groupPhaseRepository.GroupPhase.Groups)
            {
                ScheduleMatchesOfGroup(group);
                foreach (Match match in group.Matches)
                {
                    DetermineResultOfGroupPhaseMatch(match);
                    UpdateGroupDataOfNationalTeamsAfterMatch(match);
                }
                RankNationalTeamsInGroup(group);
            }
        }

        private void ScheduleMatchesOfGroup(Group group)
        {
            Match match1 = new Match(TournamentPhaseOfMatch.FIRST_ROUND_OF_GROUP_PHASE, 
                group.Teams[0], group.Teams[3], new MatchResult());
            group.Matches.Add(match1);
            group.Teams[0].Matches.Add(match1);
            group.Teams[3].Matches.Add(match1);
            
            Match match2 = new Match(TournamentPhaseOfMatch.FIRST_ROUND_OF_GROUP_PHASE, 
                group.Teams[2], group.Teams[1], new MatchResult());
            group.Matches.Add(match2);
            group.Teams[2].Matches.Add(match2);
            group.Teams[1].Matches.Add(match2);
            
            Match match3 = new Match(TournamentPhaseOfMatch.SECOND_ROUND_OF_GROUP_PHASE, 
                group.Teams[1], group.Teams[0], new MatchResult());
            group.Matches.Add(match3);
            group.Teams[1].Matches.Add(match3);
            group.Teams[0].Matches.Add(match3);
            
            Match match4 = new Match(TournamentPhaseOfMatch.SECOND_ROUND_OF_GROUP_PHASE, 
                group.Teams[3], group.Teams[2], new MatchResult());
            group.Matches.Add(match4);
            group.Teams[3].Matches.Add(match4);
            group.Teams[2].Matches.Add(match4);
            
            Match match5 = new Match(TournamentPhaseOfMatch.THIRD_ROUND_OF_GROUP_PHASE, 
                group.Teams[0], group.Teams[2], new MatchResult());
            group.Matches.Add(match5);
            group.Teams[0].Matches.Add(match5);
            group.Teams[2].Matches.Add(match5);
            
            Match match6 = new Match(TournamentPhaseOfMatch.THIRD_ROUND_OF_GROUP_PHASE, 
                group.Teams[1], group.Teams[3], new MatchResult());
            group.Matches.Add(match6);
            group.Teams[1].Matches.Add(match6);
            group.Teams[3].Matches.Add(match6);
        }

        private void DetermineResultOfGroupPhaseMatch(Match match)
        {
            int fibaRankingOfHomeTeam = match.HomeTeam.FIBARanking;
            Console.WriteLine("Home team                           FIBA ranking: " + fibaRankingOfHomeTeam);
            int fibaRankingOfGuestTeam = match.GuestTeam.FIBARanking;
            Console.WriteLine("Guest team                          FIBA ranking: " + fibaRankingOfGuestTeam);
            bool homeTeamHigherRanked = false;
            int fibaRankingDifference = fibaRankingOfHomeTeam - fibaRankingOfGuestTeam;
            if (fibaRankingDifference < 0)
            {
                fibaRankingDifference *= -1;
                homeTeamHigherRanked = true;
            }
            Console.WriteLine("Is home team                       higher ranked: " + homeTeamHigherRanked);
            Console.WriteLine("FIBA ranking                          difference: " + fibaRankingDifference);
            
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
            Console.WriteLine("Win probability of team with higher FIBA ranking: " 
                + winProbabilityOfTeamWithHigherFIBARanking);
            
            double randomProbability = Program.RandomNumberGenerator.NextDouble();
            Console.WriteLine("Randomly generated                   probability: " + randomProbability);
            if (randomProbability.CompareTo(winProbabilityOfTeamWithHigherFIBARanking) <= 0)
            {
                if (homeTeamHigherRanked)
                {
                    match.Result = new MatchResult(85, 85 - fibaRankingDifference);
                }
                else
                {
                    match.Result = new MatchResult(85 - fibaRankingDifference, 85);
                }
            }
            else
            {
                if (homeTeamHigherRanked)
                {
                    match.Result = new MatchResult(85 - fibaRankingDifference, 85);
                }
                else
                {
                    match.Result = new MatchResult(85, 85 - fibaRankingDifference);
                }
            }
            Console.WriteLine("Match                                     result: " 
                + match.Result.HomeTeamPoints + ":" + match.Result.GuestTeamPoints + "\n");
        }
        
        private void UpdateGroupDataOfNationalTeamsAfterMatch(Match match)
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

        public void RankNationalTeamsInGroup(Group group)
        {
            group.Teams = (IList<NationalTeam>) group.Teams.OrderByDescending(
                (nationalTeam) => nationalTeam.PointsInGroup);
            NationalTeam firstTeam = group.Teams[0];

            List<List<NationalTeam>> nationalTeamsWithSameNumberOfPoints = new List<List<NationalTeam>>();
            nationalTeamsWithSameNumberOfPoints.Add(new List<NationalTeam>());
            nationalTeamsWithSameNumberOfPoints[0].Add(firstTeam);
            NationalTeam previousNationalTeam = firstTeam;
            for (int i = 1; i < group.Teams.Count; i++)
            {
                if (group.Teams[i].PointsInGroup == previousNationalTeam.PointsInGroup)
                {
                    nationalTeamsWithSameNumberOfPoints[nationalTeamsWithSameNumberOfPoints.Count - 1]
                        .Add(group.Teams[i]);

                    previousNationalTeam = group.Teams[i];
                }
                else
                {
                    nationalTeamsWithSameNumberOfPoints.Add(new List<NationalTeam>());
                    nationalTeamsWithSameNumberOfPoints[nationalTeamsWithSameNumberOfPoints.Count - 1]
                        .Add(group.Teams[i]);

                    previousNationalTeam = group.Teams[i];
                }
            }

            for (int i = 0; i < nationalTeamsWithSameNumberOfPoints.Count; i++)
            {
                if (nationalTeamsWithSameNumberOfPoints[i].Count == 1)
                {
                    continue;
                }

                if (nationalTeamsWithSameNumberOfPoints[i].Count == 2)
                {
                }
            }
        }
    }
}
