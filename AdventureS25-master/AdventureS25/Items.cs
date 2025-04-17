namespace AdventureS25;

public static class Items
{
    private static Dictionary<string, Item> nameToItem = 
        new Dictionary<string, Item>();
    
    public static void Initialize()
    {
        Item smartphone = new Item("smartphone",
            "A sleek and modern smartphone", 
            "A sleek and modern smartphone lies on the ground.");
        nameToItem.Add("smartphone", smartphone);
        
        // tell the map to add the item at a specific location
        Map.AddItem(smartphone.Name, "Dorm Room");
    }

    public static Item GetItemByName(string itemName)
    {
        if (nameToItem.ContainsKey(itemName))
        {
            return nameToItem[itemName];
        }
        return null;
    }
}