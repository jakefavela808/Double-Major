namespace AdventureS25;

public static class StartMenu
{
    public static void Show()
    {
        while (true)
        {
            Console.Clear();
            string logo = @"
██████╗  ██████╗ ██╗   ██╗██████╗ ██╗     ███████╗    ███╗   ███╗ █████╗      ██╗ ██████╗ ██████╗ 
██╔══██╗██╔═══██╗██║   ██║██╔══██╗██║     ██╔════╝    ████╗ ████║██╔══██╗     ██║██╔═══██╗██╔══██╗
██║  ██║██║   ██║██║   ██║██████╔╝██║     █████╗      ██╔████╔██║███████║     ██║██║   ██║██████╔╝
██║  ██║██║   ██║██║   ██║██╔══██╗██║     ██╔══╝      ██║╚██╔╝██║██╔══██║██   ██║██║   ██║██╔══██╗
██████╔╝╚██████╔╝╚██████╔╝██████╔╝███████╗███████╗    ██║ ╚═╝ ██║██║  ██║╚█████╔╝╚██████╔╝██║  ██║
╚═════╝  ╚═════╝  ╚═════╝ ╚═════╝ ╚══════╝╚══════╝    ╚═╝     ╚═╝╚═╝  ╚═╝ ╚════╝  ╚═════╝ ╚═╝  ╚═╝
                                                                                                  

                        ▗     ▗   ▌        ▌     ▌      ▗                  
                    ▀▌  ▜▘█▌▚▘▜▘  ▛▌▀▌▛▘█▌▛▌  ▀▌▛▌▌▌█▌▛▌▜▘▌▌▛▘█▌  ▛▌▀▌▛▛▌█▌
                    █▌  ▐▖▙▖▞▖▐▖  ▙▌█▌▄▌▙▖▙▌  █▌▙▌▚▘▙▖▌▌▐▖▙▌▌ ▙▖  ▙▌█▌▌▌▌▙▖
                                                                  ▄▌       
                                                                                                                                    
                                                                                                                                       
";
            Console.WriteLine(logo);
            Console.WriteLine();
            TextUtils.TypeText("1. Start Game");
            TextUtils.TypeText("2. About Game");
            TextUtils.TypeText("3. Quit Game");
            Console.Write("> ");
            string input = Console.ReadLine();
            if (input == "1")
            {
                Console.Clear();
                return;
            }
            else if (input == "2")
            {
                Console.Clear();
                TextUtils.TypeText("Double Major Adventure is a text-based adventure game where you explore, collect items, and overcome challenges!");
                TextUtils.TypeText("Press Enter to return to the menu.", false);
                Console.ReadLine();
            }
            else if (input == "3")
            {
                Environment.Exit(0);
            }
        }
    }
}
