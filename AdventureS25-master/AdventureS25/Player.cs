namespace AdventureS25;

public static class Player
{
    public static Location CurrentLocation;
    public static List<Item> Inventory;

    public static void Initialize()
    {
        Inventory = new List<Item>();
        CurrentLocation = Map.StartLocation;
    }

    public static void Move(Command command)
    {
        if (CurrentLocation.CanMoveInDirection(command))
        {
            CurrentLocation = CurrentLocation.GetLocationInDirection(command);
            TextUtils.TypeText(CurrentLocation.GetDescription());
            ShowPossibleDirections();
        }
        else
        {
            TextUtils.TypeText("You can't move " + command.Noun + ".");
        }
    }

    public static string GetLocationDescription()
    {
        return CurrentLocation.GetDescription();
    }

    public static void Take(Command command)
    {
        // figure out which item to take: turn the noun into an item
        Item item = Items.GetItemByName(command.Noun);

        if (item == null)
        {
            TextUtils.TypeText("I don't know what " + command.Noun + " is.");
        }
        else if (!CurrentLocation.HasItem(item))
        {
            TextUtils.TypeText("There is no " + command.Noun + " here.");
        }
        else if (!item.IsTakeable)
        {
            TextUtils.TypeText("The " + command.Noun + " can't be taked.");
        }
        else
        {
            Inventory.Add(item);
            CurrentLocation.RemoveItem(item);
            item.Pickup();
            TextUtils.TypeText("You take the " + command.Noun + ".");
        }
    }

    public static void ShowInventory()
    {
        if (Inventory.Count == 0)
        {
            TextUtils.TypeText("You are empty-handed.");
        }
        else
        {
            TextUtils.TypeText("You are carrying:");
            foreach (Item item in Inventory)
            {
                string article = SemanticTools.CreateArticle(item.Name);
                TextUtils.TypeText(article + " " + item.Name);
            }
        }
    }

    public static void Look()
    {
        TextUtils.TypeText(CurrentLocation.GetDescription());
    }

    public static void Drop(Command command)
    {       
        Item item = Items.GetItemByName(command.Noun);

        if (item == null)
        {
            string article = SemanticTools.CreateArticle(command.Noun);
            TextUtils.TypeText("I don't know what " + article + " " + command.Noun + " is.");
        }
        else if (!Inventory.Contains(item))
        {
            TextUtils.TypeText("You're not carrying the " + command.Noun + ".");
        }
        else
        {
            Inventory.Remove(item);
            CurrentLocation.AddItem(item);
            TextUtils.TypeText("You drop the " + command.Noun + ".");
        }

    }
    
    public static void AddItemToInventory(string itemName)
    {
        Item item = Items.GetItemByName(itemName);

        if (item == null)
        {
            return;
        }
        
        Inventory.Add(item);
    }

    public static void RemoveItemFromInventory(string itemName)
    {
        Item item = Items.GetItemByName(itemName);
        if (item == null)
        {
            return;
        }
        Inventory.Remove(item);
    }

    public static void Use(Command command)
    {
        Item item = Items.GetItemByName(command.Noun);

        if (command.Noun == "smartphone")
        {
            string incomingCall = @"
▄▖         ▘          ▜ ▜       
▐ ▛▌▛▘▛▌▛▛▌▌▛▌▛▌  ▛▘▀▌▐ ▐       
▟▖▌▌▙▖▙▌▌▌▌▌▌▌▙▌  ▙▖█▌▐▖▐▖▗ ▗ ▗ 
              ▄▌                
▄▖  ▜ ▜         ▖               
▌ ▀▌▐ ▐ █▌▛▘▖   ▌▛▌▛▌           
▙▖█▌▐▖▐▖▙▖▌ ▖  ▙▌▙▌▌▌                              
";
            Console.WriteLine(incomingCall);
            TextUtils.TypeText("You answer the call.");
            TextUtils.TypeText("Hey, how are you?");
            TextUtils.TypeText("Jon: I heard you been sad lately. You can't get any job with your Game Dev degree... LOL! Put your clothes on and meet me outside, I need to talk to you!");
            TextUtils.TypeText("You hang up the phone.");
            TextUtils.TypeText("★★Tip★★: You can skip dialogue by clicking 'Enter' while in dialogue.");
        }


    }

    public static void ShowPossibleDirections()
    {
        if (CurrentLocation.Connections.Count == 0)
        {
            TextUtils.TypeText("No possible directions.");
            return;
        }
        var dirList = new List<string>();
        foreach (var kvp in CurrentLocation.Connections)
        {
            string dir = char.ToUpper(kvp.Key[0]) + kvp.Key.Substring(1);
            dirList.Add($"{dir} ({kvp.Value.GetName()})");
        }
        TextUtils.TypeText("Possible directions: " + string.Join(", ", dirList));
    }
}