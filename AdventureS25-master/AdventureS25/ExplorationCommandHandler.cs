namespace AdventureS25;

public static class ExplorationCommandHandler
{
    private static Dictionary<string, Action<Command>> commandMap =
        new Dictionary<string, Action<Command>>()
        {
            {"eat", Eat},
            {"go", Move},
            {"tron", Tron},
            {"troff", Troff},
            {"take", Take},
            {"inventory", ShowInventory},
            {"look", Look},
            {"drop", Drop},
            {"nouns", Nouns},
            {"verbs", Verbs},
            {"fight", ChangeToFightState},
            {"explore", ChangeToExploreState},
            {"talk", ChangeToTalkState},
            {"use", Use}
        };

    private static void TidyUp(Command command)
    {
        Conditions.ChangeCondition(ConditionTypes.IsTidiedUp, true);
    }

    private static void Puke(Command obj)
    {
        Conditions.ChangeCondition(ConditionTypes.IsHungover, true);
    }

    private static void UnSpawnBeerInInventory(Command obj)
    {
        Conditions.ChangeCondition(ConditionTypes.IsBeerMed, false);

    }

    private static void SpawnBeerInInventory(Command command)
    {
        Conditions.ChangeCondition(ConditionTypes.IsBeerMed, true);
    }


    private static void ChangeToTalkState(Command obj)
    {
        var currentLocation = Player.CurrentLocation;
        if (currentLocation.HasNPC("Jon"))
        {
            States.ChangeState(StateTypes.Talking);
            var jon = currentLocation.GetNPC("Jon");
            TextUtils.TypeText(jon.Dialogue);
            // Optionally, set a flag or context for ConversationCommandHandler to know we're talking to Jon
            ConversationContext.CurrentNPC = jon;
        }
        else
        {
            TextUtils.TypeText("There's no one here to talk to.");
        }
    }
    
    private static void ChangeToFightState(Command obj)
    {
        States.ChangeState(StateTypes.Fighting);
    }
    
    private static void ChangeToExploreState(Command obj)
    {
        States.ChangeState(StateTypes.Exploring);
    }

    private static void Verbs(Command command)
    {
        List<string> verbs = ExplorationCommandValidator.GetVerbs();
        foreach (string verb in verbs)
        {
            Console.WriteLine(verb);
        }
    }

    private static void Nouns(Command command)
    {
        List<string> nouns = ExplorationCommandValidator.GetNouns();
        foreach (string noun in nouns)
        {
            Console.WriteLine(noun);
        }
    }

    public static void Handle(Command command)
    {
        if (commandMap.ContainsKey(command.Verb))
        {
            Action<Command> method = commandMap[command.Verb];
            method.Invoke(command);
        }
        else
        {
            Console.WriteLine("I don't know how to do that.");
        }
    }
    
    private static void Drop(Command command)
    {
        Player.Drop(command);
    }
    
    private static void Look(Command command)
    {
        Player.Look();
    }

    private static void ShowInventory(Command command)
    {
        Player.ShowInventory();
    }
    
    private static void Take(Command command)
    {
        Player.Take(command);
    }

    private static void Troff(Command command)
    {
        Debugger.Troff();
    }

    private static void Tron(Command command)
    {
        Debugger.Tron();
    }

    public static void Eat(Command command)
    {
        TextUtils.TypeText("Eating..." + command.Noun);
    }

    public static void Use(Command command)
    {
        Player.Use(command);
    }

    public static void Move(Command command)
    {
        Player.Move(command);
    }
}