namespace AdventureS25;

public static class Game
{
    public static void PlayGame()
    {
        StartMenu.Show();
        Initialize();

        ShowHelp();
        TextUtils.TypeText(Player.GetLocationDescription());
        
        bool isPlaying = true;
        
        while (isPlaying == true)
        {
            Command command = CommandProcessor.Process();
            
            if (command.IsValid)
            {
                if (command.Verb == "exit")
                {
                    TextUtils.TypeText("Game Over!");
                    isPlaying = false;
                }
                else if (command.Verb == "help")
                {
                    ShowHelp();
                }
                else
                {
                    CommandHandler.Handle(command);
                }
            }
        }
    }


    private static void ShowHelp()
    {
        TextUtils.TypeText("Available commands:");
        TextUtils.TypeText("- go [direction]: Move in a direction (n, s, e, w)");
        TextUtils.TypeText("- take [item]: Pick up an item");
        TextUtils.TypeText("- drop [item]: Drop an item from your inventory");
        TextUtils.TypeText("- use [item]: Use an item in your inventory");
        TextUtils.TypeText("- talk: Talk to someone");
        TextUtils.TypeText("- look: Look around your current location");
        TextUtils.TypeText("- inventory: Check what you're carrying");
        TextUtils.TypeText("- help: Display all available commands");
        TextUtils.TypeText("- exit: Quit the game");
        TextUtils.TypeText("- skip: Press 'Enter' during dialogue to skip text");
    }

    private static void Initialize()
    {
        Conditions.Initialize();
        States.Initialize();
        Map.Initialize();
        Items.Initialize();
        Player.Initialize();
    }
}