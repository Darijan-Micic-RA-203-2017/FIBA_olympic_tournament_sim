using FIBA_OT_sim.Model;

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
            PlaceNationalTeamsIntoCorrectPots();
            RandomlyPairNationalTeamsFromPotDAndPotG();
            RandomlyPairNationalTeamsFromPotEAndPotF();
            RandomlyPairNewlyMadeQuarterFinalsPairs();
        }

        public void PlaceNationalTeamsIntoCorrectPots()
        {
            IList<NationalTeam> nationalTeamsQualifiedToEliminationPhase = 
                NationalTeamService.GetNationalTeamsQualifiedToEliminationPhase();
            foreach (NationalTeam nationalTeam in nationalTeamsQualifiedToEliminationPhase)
            {
                if (nationalTeam.GroupPhaseRanking <= 2)
                {
                    draw.PotD.Add(nationalTeam);
                }
                else if (nationalTeam.GroupPhaseRanking <= 4)
                {
                    draw.PotE.Add(nationalTeam);
                }
                else if (nationalTeam.GroupPhaseRanking <= 6)
                {
                    draw.PotF.Add(nationalTeam);
                }
                else
                {
                    draw.PotG.Add(nationalTeam);
                }
            }
        }
        
        public void RandomlyPairNationalTeamsFromPotDAndPotG()
        {
            // REFERENCE: https://www.bytehide.com/blog/random-elements-csharp
            int randomIndexOfNationalTeamInPotD = Program.RandomNumberGenerator.Next(draw.PotD.Count);

            NationalTeam randomNationalTeamInPotD = draw.PotD[randomIndexOfNationalTeamInPotD];
            NationalTeam otherNationalTeamInPotD = null;
            if (randomIndexOfNationalTeamInPotD == 0)
            {
                otherNationalTeamInPotD = draw.PotD[1];
            }
            else
            {
                otherNationalTeamInPotD = draw.PotD[0];
            }

            // REFERENCE: https://www.bytehide.com/blog/random-elements-csharp
            int randomIndexOfNationalTeamInPotG = Program.RandomNumberGenerator.Next(draw.PotG.Count);

            NationalTeam randomNationalTeamInPotG = draw.PotG[randomIndexOfNationalTeamInPotG];
            NationalTeam otherNationalTeamInPotG = null;
            if (randomIndexOfNationalTeamInPotG == 0)
            {
                otherNationalTeamInPotG = draw.PotG[1];
            }
            else
            {
                otherNationalTeamInPotG = draw.PotG[0];
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
            int randomIndexOfNationalTeamInPotE = Program.RandomNumberGenerator.Next(draw.PotE.Count);

            NationalTeam randomNationalTeamInPotE = draw.PotE[randomIndexOfNationalTeamInPotE];
            NationalTeam otherNationalTeamInPotE = null;
            if (randomIndexOfNationalTeamInPotE == 0)
            {
                otherNationalTeamInPotE = draw.PotE[1];
            }
            else
            {
                otherNationalTeamInPotE = draw.PotE[0];
            }

            // REFERENCE: https://www.bytehide.com/blog/random-elements-csharp
            int randomIndexOfNationalTeamInPotF = Program.RandomNumberGenerator.Next(draw.PotF.Count);

            NationalTeam randomNationalTeamInPotF = draw.PotF[randomIndexOfNationalTeamInPotF];
            NationalTeam otherNationalTeamInPotF = null;
            if (randomIndexOfNationalTeamInPotF == 0)
            {
                otherNationalTeamInPotF = draw.PotF[1];
            }
            else
            {
                otherNationalTeamInPotF = draw.PotF[0];
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
