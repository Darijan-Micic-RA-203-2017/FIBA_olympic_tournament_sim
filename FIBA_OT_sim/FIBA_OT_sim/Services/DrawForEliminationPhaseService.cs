using FIBA_OT_sim.Model;

namespace FIBA_OT_sim.Services
{
    public class DrawForEliminationPhaseService
    {
        private static DrawForEliminationPhase draw;
        private static IList<Match> variantsOfPossibleSemiFinalsMatches;

        // REFERENCE: https://www.csharptutorial.net/csharp-tutorial/csharp-static-constructor/
        static DrawForEliminationPhaseService()
        {
            draw = new DrawForEliminationPhase();
            variantsOfPossibleSemiFinalsMatches = new List<Match>();
        }

        public DrawForEliminationPhaseService() { }

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
                    nationalTeam.SideOfBracket = SideOfBracket.POTS_D_AND_G_SIDE_OF_BRACKET;
                    draw.GetPotWithName("D")?.NationalTeams.Add(nationalTeam);
                }
                else if (nationalTeam.GroupPhaseRanking <= 4)
                {
                    nationalTeam.SideOfBracket = SideOfBracket.POTS_E_AND_F_SIDE_OF_BRACKET;
                    draw.GetPotWithName("E")?.NationalTeams.Add(nationalTeam);
                }
                else if (nationalTeam.GroupPhaseRanking <= 6)
                {
                    nationalTeam.SideOfBracket = SideOfBracket.POTS_E_AND_F_SIDE_OF_BRACKET;
                    draw.GetPotWithName("F")?.NationalTeams.Add(nationalTeam);
                }
                else
                {
                    nationalTeam.SideOfBracket = SideOfBracket.POTS_D_AND_G_SIDE_OF_BRACKET;
                    draw.GetPotWithName("G")?.NationalTeams.Add(nationalTeam);
                }
            }
        }
        
        public void RandomlyPairNationalTeamsFromPotDAndPotG()
        {
            PotInDrawForEliminationPhase? potD = draw.GetPotWithName("D");
            if (potD == null)
            {
                return;
            }
            PotInDrawForEliminationPhase? potG = draw.GetPotWithName("G");
            if (potG == null)
            {
                return;
            }

            // REFERENCE: https://www.bytehide.com/blog/random-elements-csharp
            int randomIndexOfNationalTeamInPotD = Program.RandomNumberGenerator.Next(potD.NationalTeams.Count);

            NationalTeam randomNationalTeamInPotD = potD.NationalTeams[randomIndexOfNationalTeamInPotD];
            NationalTeam otherNationalTeamInPotD = new NationalTeam();
            if (randomIndexOfNationalTeamInPotD == 0)
            {
                otherNationalTeamInPotD = potD.NationalTeams[1];
            }
            else
            {
                otherNationalTeamInPotD = potD.NationalTeams[0];
            }

            // REFERENCE: https://www.bytehide.com/blog/random-elements-csharp
            int randomIndexOfNationalTeamInPotG = Program.RandomNumberGenerator.Next(potG.NationalTeams.Count);

            NationalTeam randomNationalTeamInPotG = potG.NationalTeams[randomIndexOfNationalTeamInPotG];
            NationalTeam otherNationalTeamInPotG = new NationalTeam();
            if (randomIndexOfNationalTeamInPotG == 0)
            {
                otherNationalTeamInPotG = potG.NationalTeams[1];
            }
            else
            {
                otherNationalTeamInPotG = potG.NationalTeams[0];
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
            PotInDrawForEliminationPhase? potE = draw.GetPotWithName("E");
            if (potE == null)
            {
                return;
            }
            PotInDrawForEliminationPhase? potF = draw.GetPotWithName("F");
            if (potF == null)
            {
                return;
            }

            // REFERENCE: https://www.bytehide.com/blog/random-elements-csharp
            int randomIndexOfNationalTeamInPotE = Program.RandomNumberGenerator.Next(potE.NationalTeams.Count);

            NationalTeam randomNationalTeamInPotE = potE.NationalTeams[randomIndexOfNationalTeamInPotE];
            NationalTeam otherNationalTeamInPotE = new NationalTeam();
            if (randomIndexOfNationalTeamInPotE == 0)
            {
                otherNationalTeamInPotE = potE.NationalTeams[1];
            }
            else
            {
                otherNationalTeamInPotE = potE.NationalTeams[0];
            }

            // REFERENCE: https://www.bytehide.com/blog/random-elements-csharp
            int randomIndexOfNationalTeamInPotF = Program.RandomNumberGenerator.Next(potF.NationalTeams.Count);

            NationalTeam randomNationalTeamInPotF = potF.NationalTeams[randomIndexOfNationalTeamInPotF];
            NationalTeam otherNationalTeamInPotF = new NationalTeam();
            if (randomIndexOfNationalTeamInPotF == 0)
            {
                otherNationalTeamInPotF = potF.NationalTeams[1];
            }
            else
            {
                otherNationalTeamInPotF = potF.NationalTeams[0];
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
            IList<Match> qfPairsBetweenPotDAndPotG = new List<Match>();
            for (int i = 0; i < 2; i++)
            {
                qfPairsBetweenPotDAndPotG.Add(EliminationPhaseService.EliminationPhase.QuarterFinals[i]);
            }
            IList<Match> qfPairsBetweenPotEAndPotF = new List<Match>();
            for (int i = 2; i < 4; i++)
            {
                qfPairsBetweenPotEAndPotF.Add(EliminationPhaseService.EliminationPhase.QuarterFinals[i]);
            }

            // REFERENCE: https://www.bytehide.com/blog/random-elements-csharp
            int randomIndexOfQFMatchBetweenPotDAndPotG = 
                Program.RandomNumberGenerator.Next(qfPairsBetweenPotDAndPotG.Count);

            Match randomQFMatchBetweenPotDAndPotG = 
                qfPairsBetweenPotDAndPotG[randomIndexOfQFMatchBetweenPotDAndPotG];
            Match otherQFMatchBetweenPotDAndPotG = new Match();
            if (randomIndexOfQFMatchBetweenPotDAndPotG == 0)
            {
                otherQFMatchBetweenPotDAndPotG = qfPairsBetweenPotDAndPotG[1];
            }
            else
            {
                otherQFMatchBetweenPotDAndPotG = qfPairsBetweenPotDAndPotG[0];
            }

            // REFERENCE: https://www.bytehide.com/blog/random-elements-csharp
            int randomIndexOfQFMatchBetweenPotEAndPotF = 
                Program.RandomNumberGenerator.Next(qfPairsBetweenPotEAndPotF.Count);

            Match randomQFMatchBetweenPotEAndPotF = 
                qfPairsBetweenPotEAndPotF[randomIndexOfQFMatchBetweenPotEAndPotF];
            Match otherQFMatchBetweenPotEAndPotF = new Match();
            if (randomIndexOfQFMatchBetweenPotEAndPotF == 0)
            {
                otherQFMatchBetweenPotEAndPotF = qfPairsBetweenPotEAndPotF[1];
            }
            else
            {
                otherQFMatchBetweenPotEAndPotF = qfPairsBetweenPotEAndPotF[0];
            }
            
            randomQFMatchBetweenPotDAndPotG.HomeTeam.FacesWinnerInSemifinals = randomQFMatchBetweenPotEAndPotF;
            randomQFMatchBetweenPotDAndPotG.GuestTeam.FacesWinnerInSemifinals = randomQFMatchBetweenPotEAndPotF;
            randomQFMatchBetweenPotEAndPotF.HomeTeam.FacesWinnerInSemifinals = randomQFMatchBetweenPotDAndPotG;
            randomQFMatchBetweenPotEAndPotF.GuestTeam.FacesWinnerInSemifinals = randomQFMatchBetweenPotDAndPotG;

            otherQFMatchBetweenPotDAndPotG.HomeTeam.FacesWinnerInSemifinals = otherQFMatchBetweenPotEAndPotF;
            otherQFMatchBetweenPotDAndPotG.GuestTeam.FacesWinnerInSemifinals = otherQFMatchBetweenPotEAndPotF;
            otherQFMatchBetweenPotEAndPotF.HomeTeam.FacesWinnerInSemifinals = otherQFMatchBetweenPotDAndPotG;
            otherQFMatchBetweenPotEAndPotF.GuestTeam.FacesWinnerInSemifinals = otherQFMatchBetweenPotDAndPotG;
            
            Match variant1OfPossibleFirstSemiFinalsMatch = new Match(0L, TournamentPhaseOfMatch.SEMIFINALS, 
                randomQFMatchBetweenPotDAndPotG.HomeTeam, 
                randomQFMatchBetweenPotEAndPotF.HomeTeam, new MatchResult());
            variantsOfPossibleSemiFinalsMatches.Add(variant1OfPossibleFirstSemiFinalsMatch);
            Match variant2OfPossibleFirstSemiFinalsMatch = new Match(0L, TournamentPhaseOfMatch.SEMIFINALS, 
                randomQFMatchBetweenPotDAndPotG.HomeTeam, 
                randomQFMatchBetweenPotEAndPotF.GuestTeam, new MatchResult());
            variantsOfPossibleSemiFinalsMatches.Add(variant2OfPossibleFirstSemiFinalsMatch);
            Match variant3OfPossibleFirstSemiFinalsMatch = new Match(0L, TournamentPhaseOfMatch.SEMIFINALS, 
                randomQFMatchBetweenPotDAndPotG.GuestTeam, 
                randomQFMatchBetweenPotEAndPotF.HomeTeam, new MatchResult());
            variantsOfPossibleSemiFinalsMatches.Add(variant3OfPossibleFirstSemiFinalsMatch);
            Match variant4OfPossibleFirstSemiFinalsMatch = new Match(0L, TournamentPhaseOfMatch.SEMIFINALS, 
                randomQFMatchBetweenPotDAndPotG.GuestTeam, 
                randomQFMatchBetweenPotEAndPotF.GuestTeam, new MatchResult());
            variantsOfPossibleSemiFinalsMatches.Add(variant4OfPossibleFirstSemiFinalsMatch);

            Match variant1OfPossibleSecondSemiFinalsMatch = new Match(0L, TournamentPhaseOfMatch.SEMIFINALS, 
                otherQFMatchBetweenPotDAndPotG.HomeTeam, 
                otherQFMatchBetweenPotEAndPotF.HomeTeam, new MatchResult());
            variantsOfPossibleSemiFinalsMatches.Add(variant1OfPossibleSecondSemiFinalsMatch);
            Match variant2OfPossibleSecondSemiFinalsMatch = new Match(0L, TournamentPhaseOfMatch.SEMIFINALS, 
                otherQFMatchBetweenPotDAndPotG.HomeTeam, 
                otherQFMatchBetweenPotEAndPotF.GuestTeam, new MatchResult());
            variantsOfPossibleSemiFinalsMatches.Add(variant2OfPossibleSecondSemiFinalsMatch);
            Match variant3OfPossibleSecondSemiFinalsMatch = new Match(0L, TournamentPhaseOfMatch.SEMIFINALS, 
                otherQFMatchBetweenPotDAndPotG.GuestTeam, 
                otherQFMatchBetweenPotEAndPotF.HomeTeam, new MatchResult());
            variantsOfPossibleSemiFinalsMatches.Add(variant3OfPossibleSecondSemiFinalsMatch);
            Match variant4OfPossibleSecondSemiFinalsMatch = new Match(0L, TournamentPhaseOfMatch.SEMIFINALS, 
                otherQFMatchBetweenPotDAndPotG.GuestTeam, 
                otherQFMatchBetweenPotEAndPotF.GuestTeam, new MatchResult());
            variantsOfPossibleSemiFinalsMatches.Add(variant4OfPossibleSecondSemiFinalsMatch);
        }
    }
}
