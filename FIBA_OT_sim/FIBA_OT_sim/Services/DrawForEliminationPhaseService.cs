using FIBA_OT_sim.Model;

namespace FIBA_OT_sim.Services
{
    public class DrawForEliminationPhaseService
    {
        private static DrawForEliminationPhase draw;
        private static IList<Match> variantsOfPossibleSemiFinalsMatches;

        public DrawForEliminationPhaseService()
        {
            draw = new DrawForEliminationPhase();
            variantsOfPossibleSemiFinalsMatches = new List<Match>();
        }

        public static DrawForEliminationPhase Draw
        {
            get { return draw; }
            set { draw = value; }
        }

        public static IList<Match> VariantsOfPossibleSemiFinalsMatches
        {
            get { return variantsOfPossibleSemiFinalsMatches; }
            set { variantsOfPossibleSemiFinalsMatches = value; }
        }

        public void PerformDrawForEliminationPhase()
        {
            CreatePots();
            PlaceNationalTeamsIntoCorrectPots();
            RandomlyPairNationalTeamsFromPotDAndPotG();
            RandomlyPairNationalTeamsFromPotEAndPotF();
            RandomlyPairNewlyMadeQuarterFinalsPairs();
            PrintingService.PrintDrawForEliminationPhase();
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
            NationalTeam otherNationalTeamInPotD = new NationalTeam();
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
            NationalTeam otherNationalTeamInPotG = new NationalTeam();
            if (randomIndexOfNationalTeamInPotG == 0)
            {
                otherNationalTeamInPotG = draw.GetPotNamed("G").NationalTeams[1];
            }
            else
            {
                otherNationalTeamInPotG = draw.GetPotNamed("G").NationalTeams[0];
            }

            Match quarterFinalsMatch1 = new Match();
            Match quarterFinalsMatch2 = new Match();
            if (randomNationalTeamInPotD.GroupName.Equals(randomNationalTeamInPotG.GroupName))
            {
                quarterFinalsMatch1 = new Match(++Program.LastMatchId, TournamentPhaseOfMatch.QUARTERFINALS, 
                    randomNationalTeamInPotD, otherNationalTeamInPotG, 
                    new MatchResult(quarterFinalsMatch1.Id, 0, 0));
                randomNationalTeamInPotD.Matches.Add(quarterFinalsMatch1);
                otherNationalTeamInPotG.Matches.Add(quarterFinalsMatch1);

                quarterFinalsMatch2 = new Match(++Program.LastMatchId, TournamentPhaseOfMatch.QUARTERFINALS, 
                    otherNationalTeamInPotD, randomNationalTeamInPotG, 
                    new MatchResult(quarterFinalsMatch2.Id, 0, 0));
                otherNationalTeamInPotD.Matches.Add(quarterFinalsMatch2);
                randomNationalTeamInPotG.Matches.Add(quarterFinalsMatch2);
            }
            else
            {
                quarterFinalsMatch1 = new Match(++Program.LastMatchId, TournamentPhaseOfMatch.QUARTERFINALS, 
                    randomNationalTeamInPotD, randomNationalTeamInPotG, 
                    new MatchResult(quarterFinalsMatch1.Id, 0, 0));
                randomNationalTeamInPotD.Matches.Add(quarterFinalsMatch1);
                randomNationalTeamInPotG.Matches.Add(quarterFinalsMatch1);

                quarterFinalsMatch2 = new Match(++Program.LastMatchId, TournamentPhaseOfMatch.QUARTERFINALS, 
                    otherNationalTeamInPotD, otherNationalTeamInPotG, 
                    new MatchResult(quarterFinalsMatch2.Id, 0, 0));
                otherNationalTeamInPotD.Matches.Add(quarterFinalsMatch2);
                otherNationalTeamInPotG.Matches.Add(quarterFinalsMatch2);
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
            NationalTeam otherNationalTeamInPotE = new NationalTeam();
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
            NationalTeam otherNationalTeamInPotF = new NationalTeam();
            if (randomIndexOfNationalTeamInPotF == 0)
            {
                otherNationalTeamInPotF = draw.GetPotNamed("F").NationalTeams[1];
            }
            else
            {
                otherNationalTeamInPotF = draw.GetPotNamed("F").NationalTeams[0];
            }

            Match quarterFinalsMatch3 = new Match();
            Match quarterFinalsMatch4 = new Match();
            if (randomNationalTeamInPotE.GroupName.Equals(randomNationalTeamInPotF.GroupName))
            {
                quarterFinalsMatch3 = new Match(++Program.LastMatchId, TournamentPhaseOfMatch.QUARTERFINALS, 
                    randomNationalTeamInPotE, otherNationalTeamInPotF, 
                    new MatchResult(quarterFinalsMatch3.Id, 0, 0));
                randomNationalTeamInPotE.Matches.Add(quarterFinalsMatch3);
                otherNationalTeamInPotF.Matches.Add(quarterFinalsMatch3);

                quarterFinalsMatch4 = new Match(++Program.LastMatchId, TournamentPhaseOfMatch.QUARTERFINALS, 
                    otherNationalTeamInPotE, randomNationalTeamInPotF, 
                    new MatchResult(quarterFinalsMatch4.Id, 0, 0));
                otherNationalTeamInPotE.Matches.Add(quarterFinalsMatch4);
                randomNationalTeamInPotF.Matches.Add(quarterFinalsMatch4);
            }
            else
            {
                quarterFinalsMatch3 = new Match(++Program.LastMatchId, TournamentPhaseOfMatch.QUARTERFINALS, 
                    randomNationalTeamInPotE, randomNationalTeamInPotF, 
                    new MatchResult(quarterFinalsMatch3.Id, 0, 0));
                randomNationalTeamInPotE.Matches.Add(quarterFinalsMatch3);
                randomNationalTeamInPotF.Matches.Add(quarterFinalsMatch3);

                quarterFinalsMatch4 = new Match(++Program.LastMatchId, TournamentPhaseOfMatch.QUARTERFINALS, 
                    otherNationalTeamInPotE, otherNationalTeamInPotF, 
                    new MatchResult(quarterFinalsMatch4.Id, 0, 0));
                otherNationalTeamInPotE.Matches.Add(quarterFinalsMatch4);
                otherNationalTeamInPotF.Matches.Add(quarterFinalsMatch4);
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

            Match randomMatchThatIsOneOfFirstTwoQuarterFinals = 
                firstTwoQuarterFinalsPairs[randomIndexOfMatchThatIsOneOfFirstTwoQuarterFinals];
            Match otherMatchThatIsOneOfFirstTwoQuarterFinals = new Match();
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

            Match randomMatchThatIsOneOfLastTwoQuarterFinals = 
                lastTwoQuarterFinalsPairs[randomIndexOfMatchThatIsOneOfLastTwoQuarterFinals];
            Match otherMatchThatIsOneOfLastTwoQuarterFinals = new Match();
            if (randomIndexOfMatchThatIsOneOfLastTwoQuarterFinals == 0)
            {
                otherMatchThatIsOneOfLastTwoQuarterFinals = lastTwoQuarterFinalsPairs[1];
            }
            else
            {
                otherMatchThatIsOneOfLastTwoQuarterFinals = lastTwoQuarterFinalsPairs[0];
            }
            
            Match variant1OfPossibleFirstSemiFinalsMatch = new Match(0L, TournamentPhaseOfMatch.SEMIFINALS, 
                randomMatchThatIsOneOfFirstTwoQuarterFinals.HomeTeam, 
                randomMatchThatIsOneOfLastTwoQuarterFinals.HomeTeam, new MatchResult());
            variantsOfPossibleSemiFinalsMatches.Add(variant1OfPossibleFirstSemiFinalsMatch);
            Match variant2OfPossibleFirstSemiFinalsMatch = new Match(0L, TournamentPhaseOfMatch.SEMIFINALS, 
                randomMatchThatIsOneOfFirstTwoQuarterFinals.HomeTeam, 
                randomMatchThatIsOneOfLastTwoQuarterFinals.GuestTeam, new MatchResult());
            variantsOfPossibleSemiFinalsMatches.Add(variant2OfPossibleFirstSemiFinalsMatch);
            Match variant3OfPossibleFirstSemiFinalsMatch = new Match(0L, TournamentPhaseOfMatch.SEMIFINALS, 
                randomMatchThatIsOneOfFirstTwoQuarterFinals.GuestTeam, 
                randomMatchThatIsOneOfLastTwoQuarterFinals.HomeTeam, new MatchResult());
            variantsOfPossibleSemiFinalsMatches.Add(variant3OfPossibleFirstSemiFinalsMatch);
            Match variant4OfPossibleFirstSemiFinalsMatch = new Match(0L, TournamentPhaseOfMatch.SEMIFINALS, 
                randomMatchThatIsOneOfFirstTwoQuarterFinals.GuestTeam, 
                randomMatchThatIsOneOfLastTwoQuarterFinals.GuestTeam, new MatchResult());
            variantsOfPossibleSemiFinalsMatches.Add(variant4OfPossibleFirstSemiFinalsMatch);

            Match variant1OfPossibleSecondSemiFinalsMatch = new Match(0L, TournamentPhaseOfMatch.SEMIFINALS, 
                otherMatchThatIsOneOfFirstTwoQuarterFinals.HomeTeam, 
                otherMatchThatIsOneOfLastTwoQuarterFinals.HomeTeam, new MatchResult());
            variantsOfPossibleSemiFinalsMatches.Add(variant1OfPossibleSecondSemiFinalsMatch);
            Match variant2OfPossibleSecondSemiFinalsMatch = new Match(0L, TournamentPhaseOfMatch.SEMIFINALS, 
                otherMatchThatIsOneOfFirstTwoQuarterFinals.HomeTeam, 
                otherMatchThatIsOneOfLastTwoQuarterFinals.GuestTeam, new MatchResult());
            variantsOfPossibleSemiFinalsMatches.Add(variant2OfPossibleSecondSemiFinalsMatch);
            Match variant3OfPossibleSecondSemiFinalsMatch = new Match(0L, TournamentPhaseOfMatch.SEMIFINALS, 
                otherMatchThatIsOneOfFirstTwoQuarterFinals.GuestTeam, 
                otherMatchThatIsOneOfLastTwoQuarterFinals.HomeTeam, new MatchResult());
            variantsOfPossibleSemiFinalsMatches.Add(variant3OfPossibleSecondSemiFinalsMatch);
            Match variant4OfPossibleSecondSemiFinalsMatch = new Match(0L, TournamentPhaseOfMatch.SEMIFINALS, 
                otherMatchThatIsOneOfFirstTwoQuarterFinals.GuestTeam, 
                otherMatchThatIsOneOfLastTwoQuarterFinals.GuestTeam, new MatchResult());
            variantsOfPossibleSemiFinalsMatches.Add(variant4OfPossibleSecondSemiFinalsMatch);
        }
    }
}
