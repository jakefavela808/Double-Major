namespace AdventureS25;

public class Location
{
    private string name;
    public string Description;
    public Dictionary<string, Location> Connections;
    public List<Item> Items = new List<Item>();
    public List<NPC> NPCs = new List<NPC>(); // Add NPC support
    
    public Location(string nameInput, string descriptionInput)
    {
        name = nameInput;
        Description = descriptionInput;
        Connections = new Dictionary<string, Location>();
        NPCs = new List<NPC>();
    }

    public void AddNPC(NPC npc)
    {
        NPCs.Add(npc);
    }

    public void RemoveNPC(NPC npc)
    {
        NPCs.Remove(npc);
    }

    public bool HasNPC(string npcName)
    {
        foreach (var npc in NPCs)
        {
            if (npc.Name == npcName)
                return true;
        }
        return false;
    }

    public NPC GetNPC(string npcName)
    {
        foreach (var npc in NPCs)
        {
            if (npc.Name == npcName)
                return npc;
        }
        return null;
    }

    public string GetName()
    {
        return name;
    }

    public void AddConnection(string direction, Location location)
    {
        Connections.Add(direction, location);
    }

    public bool CanMoveInDirection(Command command)
    {
        if (Connections.ContainsKey(command.Noun))
        {
            return true;
        }
        return false;
    }

    public Location GetLocationInDirection(Command command)
    {
        return Connections[command.Noun];
    }

    public string GetDescription()
    {
        string fullDescription = name + "\n" + Description;

        if (NPCs != null && NPCs.Count > 0)
        {
            var npcNames = string.Join(", ", NPCs.Select(n => n.Name));
            fullDescription += $"\nYou see: {npcNames}.";
        }

        foreach (Item item in Items)
        {
            fullDescription += "\n" + item.GetLocationDescription();
        }
        
        return fullDescription;
    }

    public void AddItem(Item item)
    {
        Debugger.Write("Adding item "+ item.Name + "to " + name);
        Items.Add(item);
    }

    public bool HasItem(Item itemLookingFor)
    {
        foreach (Item item in Items)
        {
            if (item.Name == itemLookingFor.Name)
            {
                return true;
            }
        }
        
        return false;
    }

    public void RemoveItem(Item item)
    {
        Items.Remove(item);
    }
}