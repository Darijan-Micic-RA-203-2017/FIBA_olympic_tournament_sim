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
        }

        private static void PrintGroupPhaseMatchesByRounds()
        {
            Console.WriteLine("Rezultati utakmica u grupama:");
            foreach (Group group in GroupPhaseRepository.GroupPhase.Groups)
            {
                StringBuilder groupHeaderBuilder = new StringBuilder("    Grupa ").Append(group.Name).Append(':');
                Console.WriteLine(groupHeaderBuilder.ToString());

                foreach (Match match in group.Matches)
                {
                    StringBuilder matchDataBuilder = new StringBuilder("        ");
                    matchDataBuilder.Append(match.HomeTeam.Name).Append(" - ");
                    matchDataBuilder.Append(match.GuestTeam.Name).Append(" (");
                    matchDataBuilder.Append(match.Result.HomeTeamPoints).Append(':');
                    matchDataBuilder.Append(match.Result.GuestTeamPoints).Append(')');
                    Console.WriteLine(matchDataBuilder.ToString());
                }

                Console.WriteLine();
            }
        }

        private static void PrintFinalStandingsInEachGroup()
        {
            Console.WriteLine("Konačan plasman u grupama:");
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
    }
}
