namespace FIBA_OT_sim.Model
{
    public class DrawForEliminationPhase
    {
        private IList<PotInDrawForEliminationPhase> pots;

        public DrawForEliminationPhase()
        {
            pots = new List<PotInDrawForEliminationPhase>();
        }

        public DrawForEliminationPhase(IList<PotInDrawForEliminationPhase> pots)
        {
            this.pots = pots;
        }

        public DrawForEliminationPhase(DrawForEliminationPhase drawForEliminationPhase)
        {
            pots = drawForEliminationPhase.pots;
        }

        public IList<PotInDrawForEliminationPhase> Pots
        {
            get { return pots; }
            set { pots = value; }
        }

        public PotInDrawForEliminationPhase GetPotNamed(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return null;
            }

            return pots.First((pot) => pot.Name.Equals(name));
        }
    }
}
