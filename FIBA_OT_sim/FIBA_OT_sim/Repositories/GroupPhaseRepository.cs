using FIBA_OT_sim.Model;
using System.Text.Json;

namespace FIBA_OT_sim.Repositories
{
    public class GroupPhaseRepository
    {
        private static GroupPhase groupPhase;

        public GroupPhaseRepository()
        {
            groupPhase = new GroupPhase();
        }

        public GroupPhase GroupPhase
        {
            get { return groupPhase; }
            set { groupPhase = value; }
        }

        public void LoadGroupPhaseFromFileSystem()
        {
            // REFERENCE: https://learn.microsoft.com/en-us/answers/questions/699941/read-and-process-json-file-with-c
            // REFERENCE: https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/deserialization
            // REFERENCE: https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/use-dom
            string jsonString = File.ReadAllText("../../../../Resources/groups.json");
            using (JsonDocument document = JsonDocument.Parse(jsonString))
            {
                JsonElement rootElement = document.RootElement;

                foreach (JsonProperty groupProperty in rootElement.EnumerateObject())
                {
                    Group group = new Group(groupProperty.Name, new List<NationalTeam>());

                    foreach (JsonElement nationalTeamElement in groupProperty.Value.EnumerateArray())
                    {
                        string? name = nationalTeamElement.GetProperty("Team").GetString();
                        if (name == null)
                        {
                            groupPhase = new GroupPhase();

                            return;
                        }
                        string? abbreviation = nationalTeamElement.GetProperty("ISOCode").GetString();
                        if (abbreviation == null)
                        {
                            groupPhase = new GroupPhase();

                            return;
                        }
                        int fibaRanking = nationalTeamElement.GetProperty("FIBARanking").GetInt32();

                        NationalTeam nationalTeam = new NationalTeam(name, abbreviation, fibaRanking,
                            StatusOfNationalTeam.COMPETING_IN_GROUP_PHASE);
                        group.Teams.Add(nationalTeam);
                    }

                    groupPhase.Groups.Add(group);
                }
            }
        }
    }
}
