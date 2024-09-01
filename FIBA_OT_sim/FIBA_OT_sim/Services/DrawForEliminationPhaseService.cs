using FIBA_OT_sim.Model;

namespace FIBA_OT_sim.Services
{
    public class DrawForEliminationPhaseService
    {
        private static DrawForEliminationPhase draw;

        public DrawForEliminationPhaseService()
        {
            draw = new DrawForEliminationPhase();
        }

        public static DrawForEliminationPhase Draw
        {
            get { return draw; }
            set { draw = value; }
        }

        public void PerformDrawForEliminationPhase()
        {
            PlaceNationalTeamsIntoCorrectPots();
            RandomlyPairNationalTeamsFromPotDAndPotG();
            RandomlyPairNationalTeamsFromPotEAndPotF();
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
    }
}
