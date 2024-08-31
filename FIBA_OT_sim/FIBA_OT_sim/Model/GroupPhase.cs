namespace FIBA_OT_sim.Model
{
    public class GroupPhase
    {
        private IList<Group> groups;

        public GroupPhase()
        {
            groups = new List<Group>();
        }

        public GroupPhase(IList<Group> groups)
        {
            this.groups = groups;
        }

        public GroupPhase(GroupPhase groupPhase)
        {
            groups = new List<Group>();
            foreach (Group originalGroup in groupPhase.groups)
            {
                groups.Add(new Group(originalGroup));
            }
        }

        public IList<Group> Groups
        {
            get { return groups; }
            set { groups = value; }
        }
    }
}
