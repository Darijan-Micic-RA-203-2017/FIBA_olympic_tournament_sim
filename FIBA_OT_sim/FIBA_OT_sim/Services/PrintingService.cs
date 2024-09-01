using FIBA_OT_sim.Model;
using FIBA_OT_sim.Repositories;
using System.Text;

namespace FIBA_OT_sim.Services
{
    public class PrintingService
    {
        public PrintingService() { }

        public static void PrintGroupPhase()
        {
            PrintGroupPhaseMatchesByRounds();
            PrintFinalStandingsInEachGroup();
            PrintNationalTeamsQualifiedToEliminationPhase();
        }

        private static void PrintGroupPhaseMatchesByRounds()
        {
            int numberOfRounds = GroupPhaseRepository.GroupPhase.Groups[0].Teams.Count - 1;
            int numberOfMatchesInOneRound = GroupPhaseRepository.GroupPhase.Groups[0].Teams.Count / 2;
            int indexOfCurrentMatch = numberOfMatchesInOneRound;
            for (int i = 1; i <= numberOfRounds; i++)
            {
                StringBuilder roundHeaderBuilder = new StringBuilder("Grupna faza - ").Append(i).Append(". kolo:");
                Console.WriteLine(roundHeaderBuilder.ToString());

                foreach (Group group in GroupPhaseRepository.GroupPhase.Groups)
                {
                    StringBuilder groupHeaderBuilder = new StringBuilder("    Grupa ").Append(group.Name)
                        .Append(':');
                    Console.WriteLine(groupHeaderBuilder.ToString());

                    indexOfCurrentMatch -= numberOfMatchesInOneRound;
                    for (int k = 0; k < numberOfMatchesInOneRound; k++)
                    {
                        StringBuilder matchDataBuilder = new StringBuilder("        ");
                        matchDataBuilder.Append(group.Matches[indexOfCurrentMatch].HomeTeam.Name).Append(" - ");
                        matchDataBuilder.Append(group.Matches[indexOfCurrentMatch].GuestTeam.Name).Append(" (");
                        matchDataBuilder.Append(group.Matches[indexOfCurrentMatch].Result.HomeTeamPoints)
                            .Append(':');
                        matchDataBuilder.Append(group.Matches[indexOfCurrentMatch].Result.GuestTeamPoints)
                            .Append(')');
                        Console.WriteLine(matchDataBuilder.ToString());

                        indexOfCurrentMatch++;
                    }
                }

                indexOfCurrentMatch += numberOfMatchesInOneRound;
            }
        }

        private static void PrintFinalStandingsInEachGroup()
        {
            Console.WriteLine("\nKonačan plasman u grupama:");
            foreach (Group group in GroupPhaseRepository.GroupPhase.Groups)
            {
                StringBuilder groupHeaderBuilder = new StringBuilder("    Grupa ").Append(group.Name);
                groupHeaderBuilder
                    .Append(" (Naziv - pobede / porazi / postignuti poeni / primljeni poeni / koš razlika");
                groupHeaderBuilder.Append(" / bodovi):");
                Console.WriteLine(groupHeaderBuilder.ToString());

                foreach (NationalTeam nationalTeam in group.Teams)
                {
                    StringBuilder nationalTeamDataBuilder = new StringBuilder("        ")
                        .Append(nationalTeam.GroupRanking).Append(". ").Append(nationalTeam.Name).Append(' ');
                    nationalTeamDataBuilder.Append(nationalTeam.WinsInGroup).Append(" / ");
                    nationalTeamDataBuilder.Append(nationalTeam.LossesInGroup).Append(" / ");
                    nationalTeamDataBuilder.Append(nationalTeam.ScoredPointsInGroup).Append(" / ");
                    nationalTeamDataBuilder.Append(nationalTeam.AllowedPointsInGroup).Append(" / ");
                    nationalTeamDataBuilder.Append(nationalTeam.PointsDifferentialInGroup).Append(" / ");
                    nationalTeamDataBuilder.Append(nationalTeam.PointsInGroup);
                    Console.WriteLine(nationalTeamDataBuilder.ToString());
                }

                Console.WriteLine();
            }
        }

        private static void PrintNationalTeamsQualifiedToEliminationPhase()
        {
            IList<NationalTeam> nationalTeamsQualifiedToEliminationPhase = 
                NationalTeamService.GetNationalTeamsQualifiedToEliminationPhase();
            
            Console.WriteLine("Nacionalni timovi koji su se plasirali u eliminacionu fazu:");
            foreach (NationalTeam nationalTeam in nationalTeamsQualifiedToEliminationPhase)
            {
                StringBuilder nationalTeamDataBuilder = new StringBuilder("    ")
                            .Append(nationalTeam.GroupPhaseRanking).Append(". ").Append(nationalTeam.Name);
                Console.WriteLine(nationalTeamDataBuilder.ToString());
            }
        }
    }
}
