namespace AdventureS25;

public static class Map
{
    private static Dictionary<string, Location> nameToLocation = 
        new Dictionary<string, Location>();
    public static Location StartLocation;
    
    public static void Initialize()
    {
        Location dorm = new Location("Dorm Room", 
            "A cozy dorm room with books and posters of musicians. A cluttered desk with a laptop sits in the corner, and the bed is unmade.");
        nameToLocation.Add("Dorm Room", dorm);
        
        Location library = new Location("Library", 
            "You are in the college library. Shelves of books stretch endlessly, and students are quietly studying.");
        nameToLocation.Add("Library", library);
        
        Location cafeteria = new Location("Cafeteria", 
            "The cafeteria is bustling with students. The smell of various foods fills the air.");
        nameToLocation.Add("Cafeteria", cafeteria);
        
        Location park = new Location("Campus Park", 
            "A peaceful park with benches and walking paths. Students relax and chat here.");
        nameToLocation.Add("Campus Park", park);
        
        Location lectureHall = new Location("Lecture Hall", 
            "A large lecture hall with rows of seats and a podium at the front.");
        nameToLocation.Add("Lecture Hall", lectureHall);
        
        dorm.AddConnection("north", library);
        library.AddConnection("south", dorm);
        library.AddConnection("east", cafeteria);
        cafeteria.AddConnection("west", library);
        park.AddConnection("west", cafeteria);
        cafeteria.AddConnection("east", park);
        lectureHall.AddConnection("north", park);
        park.AddConnection("south", lectureHall);

        StartLocation = dorm;
    }
    

    public static void AddItem(string itemName, string locationName)
    {
        // find out which Location is named locationName
        Location location = GetLocationByName(locationName);
        Item item = Items.GetItemByName(itemName);
        
        // add the item to the location
        if (item != null && location != null)
        {
            location.AddItem(item);
        }
    }
    
    public static void RemoveItem(string itemName, string locationName)
    {
        // find out which Location is named locationName
        Location location = GetLocationByName(locationName);
        Item item = Items.GetItemByName(itemName);
        
        // remove the item to the location
        if (item != null && location != null)
        {
            location.RemoveItem(item);
        }
    }

    private static Location GetLocationByName(string locationName)
    {
        if (nameToLocation.ContainsKey(locationName))
        {
            return nameToLocation[locationName];
        }
        else
        {
            return null;
        }
    }
}