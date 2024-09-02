namespace FIBA_OT_sim.Model
{
    public class PotInDrawForEliminationPhase : IComparable<PotInDrawForEliminationPhase>
    {
        private string name;
        private IList<NationalTeam> nationalTeams;

        public PotInDrawForEliminationPhase()
        {
            name = "";
            nationalTeams = new List<NationalTeam>();
        }

        public PotInDrawForEliminationPhase(string name, IList<NationalTeam> nationalTeams)
        {
            this.name = name;
            this.nationalTeams = nationalTeams;
        }

        public PotInDrawForEliminationPhase(PotInDrawForEliminationPhase pot)
        {
            name = pot.name;
            nationalTeams = pot.nationalTeams;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public IList<NationalTeam> NationalTeams
        {
            get { return nationalTeams; }
            set { nationalTeams = value; }
        }

        public override int GetHashCode()
        {
            const int prime = 59;
            int result = 1;

            result = prime * result + Name.GetHashCode();

            return result;
        }

        public override bool Equals(object? obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (obj is not PotInDrawForEliminationPhase aTeam)
            {
                return false;
            }

            PotInDrawForEliminationPhase other = (PotInDrawForEliminationPhase) obj;

            if (!Name.Equals(other.Name))
            {
                return false;
            }

            return true;
        }

        public int CompareTo(PotInDrawForEliminationPhase? other)
        {
            if (other == null)
            {
                throw new NullReferenceException();
            }

            if (this == other)
            {
                return 0;
            }

            if (string.Compare(Name, other.Name) < 0)
            {
                return -1;
            }
            else if (string.Compare(Name, other.Name) > 0)
            {
                return 1;
            }

            return 0;
        }
    }
}
