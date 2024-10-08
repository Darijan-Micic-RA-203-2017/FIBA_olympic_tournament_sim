﻿using FIBA_OT_sim.Model;

namespace FIBA_OT_sim.Services
{
    public class EliminationPhaseService
    {
        private static EliminationPhase eliminationPhase;

        // REFERENCE: https://www.csharptutorial.net/csharp-tutorial/csharp-static-constructor/
        static EliminationPhaseService()
        {
            eliminationPhase = new EliminationPhase();
        }

        public EliminationPhaseService() { }

        public static EliminationPhase EliminationPhase
        {
            get { return eliminationPhase; }
            set { eliminationPhase = value; }
        }

        public void SimulateEliminationPhase()
        {
            SimulateQuarterFinals();
            SimulateSemiFinals();
            SimulateThirdPlaceMatch();
            SimulateFinal();
            PrintingService.PrintEliminationPhase();
        }

        public void SimulateQuarterFinals()
        {
            foreach (Match quarterFinal in eliminationPhase.QuarterFinals)
            {
                MatchService.DetermineResultOfMatch(quarterFinal);
                NationalTeamService.ChangeStatusesOfNationalTeamsAfterQuarterFinalsMatch(quarterFinal);
            }
        }

        public void SimulateSemiFinals()
        {
            CreateSemiFinalsMatches();
            foreach (Match semiFinal in eliminationPhase.SemiFinals)
            {
                MatchService.DetermineResultOfMatch(semiFinal);
                NationalTeamService.ChangeStatusesOfNationalTeamsAfterSemiFinalsMatch(semiFinal);
            }
        }

        private void CreateSemiFinalsMatches()
        {
            IList<NationalTeam> nationalTeamsQualifiedToSemiFinals = 
                NationalTeamService.GetNationalTeamsQualifiedToSemiFinals();

            int numberOfCreatedSemiFinalsMatches = 0;
            foreach (NationalTeam teamQualifiedToSemis in nationalTeamsQualifiedToSemiFinals)
            {
                if (numberOfCreatedSemiFinalsMatches == 2)
                {
                    break;
                }

                if (teamQualifiedToSemis.FacesWinnerInSemifinals == null)
                {
                    return;
                }
                NationalTeam winnerOfQFMatchOnOppositeSideOfBracket = 
                    MatchService.GetNationalTeamThatWonMatch(teamQualifiedToSemis.FacesWinnerInSemifinals);

                if (teamQualifiedToSemis.SideOfBracket == SideOfBracket.POTS_D_AND_G_SIDE_OF_BRACKET)
                {
                    eliminationPhase.SemiFinals.Add(new Match(++Program.LastMatchId, 
                        TournamentPhaseOfMatch.SEMIFINALS, teamQualifiedToSemis, 
                        winnerOfQFMatchOnOppositeSideOfBracket, new MatchResult(Program.LastMatchId, 0, 0)));

                    numberOfCreatedSemiFinalsMatches++;
                }
                else
                {
                    eliminationPhase.SemiFinals.Add(new Match(++Program.LastMatchId, 
                        TournamentPhaseOfMatch.SEMIFINALS, winnerOfQFMatchOnOppositeSideOfBracket, 
                        teamQualifiedToSemis, new MatchResult(Program.LastMatchId, 0, 0)));

                    numberOfCreatedSemiFinalsMatches++;
                }
            }
        }

        public void SimulateThirdPlaceMatch()
        {
            CreateThirdPlaceMatch();
            MatchService.DetermineResultOfMatch(eliminationPhase.ThirdPlaceMatch);
            NationalTeamService.ChangeStatusesOfNationalTeamsAfterThirdPlaceMatch(
                eliminationPhase.ThirdPlaceMatch);
        }

        private void CreateThirdPlaceMatch()
        {
            IList<NationalTeam> nationalTeamsSetToCompeteInThirdPlaceMatch = 
                NationalTeamService.GetNationalTeamsSetToCompeteInThirdPlaceMatch();
            
            if (nationalTeamsSetToCompeteInThirdPlaceMatch[0].SideOfBracket == 
                SideOfBracket.POTS_D_AND_G_SIDE_OF_BRACKET)
            {
                eliminationPhase.ThirdPlaceMatch = new Match(++Program.LastMatchId, 
                    TournamentPhaseOfMatch.THIRD_PLACE_MATCH, nationalTeamsSetToCompeteInThirdPlaceMatch[0], 
                    nationalTeamsSetToCompeteInThirdPlaceMatch[1], new MatchResult(Program.LastMatchId, 0, 0));
            }
            else
            {
                eliminationPhase.ThirdPlaceMatch = new Match(++Program.LastMatchId, 
                    TournamentPhaseOfMatch.THIRD_PLACE_MATCH, nationalTeamsSetToCompeteInThirdPlaceMatch[1], 
                    nationalTeamsSetToCompeteInThirdPlaceMatch[0], new MatchResult(Program.LastMatchId, 0, 0));
            }
        }

        public void SimulateFinal()
        {
            CreateFinal();
            MatchService.DetermineResultOfMatch(eliminationPhase.Final);
            NationalTeamService.ChangeStatusesOfNationalTeamsAfterFinal(eliminationPhase.Final);
        }

        private void CreateFinal()
        {
            IList<NationalTeam> nationalTeamsSetToCompeteInFinal = 
                NationalTeamService.GetNationalTeamsSetToCompeteInFinal();

            if (nationalTeamsSetToCompeteInFinal[0].SideOfBracket == SideOfBracket.POTS_D_AND_G_SIDE_OF_BRACKET)
            {
                eliminationPhase.Final = new Match(++Program.LastMatchId, TournamentPhaseOfMatch.FINAL, 
                    nationalTeamsSetToCompeteInFinal[0], nationalTeamsSetToCompeteInFinal[1], 
                    new MatchResult(Program.LastMatchId, 0, 0));
            }
            else
            {
                eliminationPhase.Final = new Match(++Program.LastMatchId, TournamentPhaseOfMatch.FINAL, 
                    nationalTeamsSetToCompeteInFinal[1], nationalTeamsSetToCompeteInFinal[0], 
                    new MatchResult(Program.LastMatchId, 0, 0));
            }
        }
    }
}
