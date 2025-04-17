namespace AdventureS25
{
    public class NPC
    {
        public string Name { get; set; }
        public string Dialogue { get; set; }

        public NPC(string name, string dialogue)
        {
            Name = name;
            Dialogue = dialogue;
        }
    }
}
