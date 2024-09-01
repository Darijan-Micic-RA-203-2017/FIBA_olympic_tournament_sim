﻿using FIBA_OT_sim.Model;

namespace FIBA_OT_sim.Services
{
    public class DrawForEliminationPhaseService
    {
        private static DrawForEliminationPhase draw;
        private static Match randomMatchThatIsOneOfFirstTwoQuarterFinals;
        private static Match otherMatchThatIsOneOfFirstTwoQuarterFinals;
        private static Match randomMatchThatIsOneOfLastTwoQuarterFinals;
        private static Match otherMatchThatIsOneOfLastTwoQuarterFinals;
        private static Match semiFinalsMatch1;
        private static Match semiFinalsMatch2;

        public DrawForEliminationPhaseService()
        {
            draw = new DrawForEliminationPhase();
            randomMatchThatIsOneOfFirstTwoQuarterFinals = new Match();
            otherMatchThatIsOneOfFirstTwoQuarterFinals = new Match();
            randomMatchThatIsOneOfLastTwoQuarterFinals = new Match();
            otherMatchThatIsOneOfLastTwoQuarterFinals = new Match();
            semiFinalsMatch1 = new Match();
            semiFinalsMatch2 = new Match();
        }

        public static DrawForEliminationPhase Draw
        {
            get { return draw; }
            set { draw = value; }
        }

        public static Match RandomMatchThatIsOneOfFirstTwoQuarterFinals
        {
            get { return randomMatchThatIsOneOfFirstTwoQuarterFinals; }
            set { randomMatchThatIsOneOfFirstTwoQuarterFinals = value; }
        }

        public static Match OtherMatchThatIsOneOfFirstTwoQuarterFinals
        {
            get { return otherMatchThatIsOneOfFirstTwoQuarterFinals; }
            set { otherMatchThatIsOneOfFirstTwoQuarterFinals = value; }
        }

        public static Match RandomMatchThatIsOneOfLastTwoQuarterFinals
        {
            get { return randomMatchThatIsOneOfLastTwoQuarterFinals; }
            set { randomMatchThatIsOneOfLastTwoQuarterFinals = value; }
        }

        public static Match OtherMatchThatIsOneOfLastTwoQuarterFinals
        {
            get { return otherMatchThatIsOneOfLastTwoQuarterFinals; }
            set { otherMatchThatIsOneOfLastTwoQuarterFinals = value; }
        }

        public static Match SemiFinalsMatch1
        {
            get { return semiFinalsMatch1; }
            set { semiFinalsMatch1 = value; }
        }

        public static Match SemiFinalsMatch2
        {
            get { return semiFinalsMatch2; }
            set { semiFinalsMatch2 = value; }
        }

        public void PerformDrawForEliminationPhase()
        {
            CreatePots();
            PlaceNationalTeamsIntoCorrectPots();
            RandomlyPairNationalTeamsFromPotDAndPotG();
            RandomlyPairNationalTeamsFromPotEAndPotF();
            RandomlyPairNewlyMadeQuarterFinalsPairs();
        }

        public void CreatePots()
        {
            draw.Pots.Add(new PotInDrawForEliminationPhase("D", new List<NationalTeam>()));
            draw.Pots.Add(new PotInDrawForEliminationPhase("E", new List<NationalTeam>()));
            draw.Pots.Add(new PotInDrawForEliminationPhase("F", new List<NationalTeam>()));
            draw.Pots.Add(new PotInDrawForEliminationPhase("G", new List<NationalTeam>()));
        }

        public void PlaceNationalTeamsIntoCorrectPots()
        {
            IList<NationalTeam> nationalTeamsQualifiedToEliminationPhase = 
                NationalTeamService.GetNationalTeamsQualifiedToEliminationPhase();
            foreach (NationalTeam nationalTeam in nationalTeamsQualifiedToEliminationPhase)
            {
                if (nationalTeam.GroupPhaseRanking <= 2)
                {
                    draw.GetPotNamed("D").NationalTeams.Add(nationalTeam);
                }
                else if (nationalTeam.GroupPhaseRanking <= 4)
                {
                    draw.GetPotNamed("E").NationalTeams.Add(nationalTeam);
                }
                else if (nationalTeam.GroupPhaseRanking <= 6)
                {
                    draw.GetPotNamed("F").NationalTeams.Add(nationalTeam);
                }
                else
                {
                    draw.GetPotNamed("G").NationalTeams.Add(nationalTeam);
                }
            }
        }
        
        public void RandomlyPairNationalTeamsFromPotDAndPotG()
        {
            // REFERENCE: https://www.bytehide.com/blog/random-elements-csharp
            int randomIndexOfNationalTeamInPotD = 
                Program.RandomNumberGenerator.Next(draw.GetPotNamed("D").NationalTeams.Count);

            NationalTeam randomNationalTeamInPotD = 
                draw.GetPotNamed("D").NationalTeams[randomIndexOfNationalTeamInPotD];
            NationalTeam otherNationalTeamInPotD = null;
            if (randomIndexOfNationalTeamInPotD == 0)
            {
                otherNationalTeamInPotD = draw.GetPotNamed("D").NationalTeams[1];
            }
            else
            {
                otherNationalTeamInPotD = draw.GetPotNamed("D").NationalTeams[0];
            }

            // REFERENCE: https://www.bytehide.com/blog/random-elements-csharp
            int randomIndexOfNationalTeamInPotG = 
                Program.RandomNumberGenerator.Next(draw.GetPotNamed("G").NationalTeams.Count);

            NationalTeam randomNationalTeamInPotG = 
                draw.GetPotNamed("G").NationalTeams[randomIndexOfNationalTeamInPotG];
            NationalTeam otherNationalTeamInPotG = null;
            if (randomIndexOfNationalTeamInPotG == 0)
            {
                otherNationalTeamInPotG = draw.GetPotNamed("G").NationalTeams[1];
            }
            else
            {
                otherNationalTeamInPotG = draw.GetPotNamed("G").NationalTeams[0];
            }

            Match quarterFinalsMatch1 = null;
            Match quarterFinalsMatch2 = null;
            if (randomNationalTeamInPotD.GroupName.Equals(randomNationalTeamInPotG.GroupName))
            {
                quarterFinalsMatch1 = new Match(++Program.LastMatchId, TournamentPhaseOfMatch.QUARTERFINALS, 
                    randomNationalTeamInPotD, otherNationalTeamInPotG, 
                    new MatchResult(quarterFinalsMatch1.Id, 0, 0));
                quarterFinalsMatch2 = new Match(++Program.LastMatchId, TournamentPhaseOfMatch.QUARTERFINALS, 
                    otherNationalTeamInPotD, randomNationalTeamInPotG, 
                    new MatchResult(quarterFinalsMatch2.Id, 0, 0));
            }
            else
            {
                quarterFinalsMatch1 = new Match(++Program.LastMatchId, TournamentPhaseOfMatch.QUARTERFINALS, 
                    randomNationalTeamInPotD, randomNationalTeamInPotD, 
                    new MatchResult(quarterFinalsMatch1.Id, 0, 0));
                quarterFinalsMatch2 = new Match(++Program.LastMatchId, TournamentPhaseOfMatch.QUARTERFINALS, 
                    otherNationalTeamInPotD, otherNationalTeamInPotG, 
                    new MatchResult(quarterFinalsMatch2.Id, 0, 0));
            }

            EliminationPhaseService.EliminationPhase.QuarterFinals.Add(quarterFinalsMatch1);
            EliminationPhaseService.EliminationPhase.QuarterFinals.Add(quarterFinalsMatch2);
        }
        
        public void RandomlyPairNationalTeamsFromPotEAndPotF()
        {
            // REFERENCE: https://www.bytehide.com/blog/random-elements-csharp
            int randomIndexOfNationalTeamInPotE = 
                Program.RandomNumberGenerator.Next(draw.GetPotNamed("E").NationalTeams.Count);

            NationalTeam randomNationalTeamInPotE = 
                draw.GetPotNamed("E").NationalTeams[randomIndexOfNationalTeamInPotE];
            NationalTeam otherNationalTeamInPotE = null;
            if (randomIndexOfNationalTeamInPotE == 0)
            {
                otherNationalTeamInPotE = draw.GetPotNamed("E").NationalTeams[1];
            }
            else
            {
                otherNationalTeamInPotE = draw.GetPotNamed("E").NationalTeams[0];
            }

            // REFERENCE: https://www.bytehide.com/blog/random-elements-csharp
            int randomIndexOfNationalTeamInPotF = 
                Program.RandomNumberGenerator.Next(draw.GetPotNamed("F").NationalTeams.Count);

            NationalTeam randomNationalTeamInPotF = 
                draw.GetPotNamed("F").NationalTeams[randomIndexOfNationalTeamInPotF];
            NationalTeam otherNationalTeamInPotF = null;
            if (randomIndexOfNationalTeamInPotF == 0)
            {
                otherNationalTeamInPotF = draw.GetPotNamed("F").NationalTeams[1];
            }
            else
            {
                otherNationalTeamInPotF = draw.GetPotNamed("F").NationalTeams[0];
            }

            Match quarterFinalsMatch3 = null;
            Match quarterFinalsMatch4 = null;
            if (randomNationalTeamInPotE.GroupName.Equals(randomNationalTeamInPotF.GroupName))
            {
                quarterFinalsMatch3 = new Match(++Program.LastMatchId, TournamentPhaseOfMatch.QUARTERFINALS, 
                    randomNationalTeamInPotE, otherNationalTeamInPotF, 
                    new MatchResult(quarterFinalsMatch3.Id, 0, 0));
                quarterFinalsMatch4 = new Match(++Program.LastMatchId, TournamentPhaseOfMatch.QUARTERFINALS, 
                    otherNationalTeamInPotE, randomNationalTeamInPotF, 
                    new MatchResult(quarterFinalsMatch4.Id, 0, 0));
            }
            else
            {
                quarterFinalsMatch3 = new Match(++Program.LastMatchId, TournamentPhaseOfMatch.QUARTERFINALS, 
                    randomNationalTeamInPotE, randomNationalTeamInPotE, 
                    new MatchResult(quarterFinalsMatch3.Id, 0, 0));
                quarterFinalsMatch4 = new Match(++Program.LastMatchId, TournamentPhaseOfMatch.QUARTERFINALS, 
                    otherNationalTeamInPotE, otherNationalTeamInPotF, 
                    new MatchResult(quarterFinalsMatch4.Id, 0, 0));
            }

            EliminationPhaseService.EliminationPhase.QuarterFinals.Add(quarterFinalsMatch3);
            EliminationPhaseService.EliminationPhase.QuarterFinals.Add(quarterFinalsMatch4);
        }

        public void RandomlyPairNewlyMadeQuarterFinalsPairs()
        {
            IList<Match> firstTwoQuarterFinalsPairs = new List<Match>();
            for (int i = 0; i < 2; i++)
            {
                firstTwoQuarterFinalsPairs.Add(EliminationPhaseService.EliminationPhase.QuarterFinals[i]);
            }
            IList<Match> lastTwoQuarterFinalsPairs = new List<Match>();
            for (int i = 2; i < 4; i++)
            {
                lastTwoQuarterFinalsPairs.Add(EliminationPhaseService.EliminationPhase.QuarterFinals[i]);
            }

            // REFERENCE: https://www.bytehide.com/blog/random-elements-csharp
            int randomIndexOfMatchThatIsOneOfFirstTwoQuarterFinals = 
                Program.RandomNumberGenerator.Next(firstTwoQuarterFinalsPairs.Count);

            randomMatchThatIsOneOfFirstTwoQuarterFinals = 
                firstTwoQuarterFinalsPairs[randomIndexOfMatchThatIsOneOfFirstTwoQuarterFinals];
            if (randomIndexOfMatchThatIsOneOfFirstTwoQuarterFinals == 0)
            {
                otherMatchThatIsOneOfFirstTwoQuarterFinals = firstTwoQuarterFinalsPairs[1];
            }
            else
            {
                otherMatchThatIsOneOfFirstTwoQuarterFinals = firstTwoQuarterFinalsPairs[0];
            }

            // REFERENCE: https://www.bytehide.com/blog/random-elements-csharp
            int randomIndexOfMatchThatIsOneOfLastTwoQuarterFinals = 
                Program.RandomNumberGenerator.Next(lastTwoQuarterFinalsPairs.Count);

            randomMatchThatIsOneOfLastTwoQuarterFinals =
                lastTwoQuarterFinalsPairs[randomIndexOfMatchThatIsOneOfLastTwoQuarterFinals];
            if (randomIndexOfMatchThatIsOneOfLastTwoQuarterFinals == 0)
            {
                otherMatchThatIsOneOfLastTwoQuarterFinals = lastTwoQuarterFinalsPairs[1];
            }
            else
            {
                otherMatchThatIsOneOfLastTwoQuarterFinals = lastTwoQuarterFinalsPairs[0];
            }

            semiFinalsMatch1 = new Match(++Program.LastMatchId, TournamentPhaseOfMatch.SEMIFINALS, 
                new NationalTeam(), new NationalTeam(), new MatchResult());
            semiFinalsMatch2 = new Match(++Program.LastMatchId, TournamentPhaseOfMatch.SEMIFINALS, 
                new NationalTeam(), new NationalTeam(), new MatchResult());

            EliminationPhaseService.EliminationPhase.SemiFinals.Add(semiFinalsMatch1);
            EliminationPhaseService.EliminationPhase.SemiFinals.Add(semiFinalsMatch2);
        }
    }
}
