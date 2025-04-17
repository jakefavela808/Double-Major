namespace AdventureS25;

public static class ConversationCommandHandler
{
    private static Dictionary<string, Action<Command>> commandMap =
        new Dictionary<string, Action<Command>>()
        {
            {"y", Yes},
            {"n", No},
            {"leave", Leave},
        };
    
    public static void Handle(Command command)
    {
        if (commandMap.ContainsKey(command.Verb))
        {
            Action<Command> action = commandMap[command.Verb];
            action.Invoke(command);
        }
    }

    private static void Yes(Command command)
    {
        if (ConversationContext.CurrentNPC != null && ConversationContext.CurrentNPC.Name == "Jon")
        {
            TextUtils.TypeText("Jon smiles: 'Great! Double majoring can open up so many opportunities. Let me know if you have questions.'");
        }
        else
        {
            TextUtils.TypeText("You agreed");
        }
    }
    
    private static void No(Command command)
    {
        if (ConversationContext.CurrentNPC != null && ConversationContext.CurrentNPC.Name == "Jon")
        {
            TextUtils.TypeText("Jon shrugs: 'That's okay! It's not for everyone. If you change your mind, just ask.'");
        }
        else
        {
            TextUtils.TypeText("You are disagreed");
        }
    }

    private static void Leave(Command command)
    {
        if (ConversationContext.CurrentNPC != null && ConversationContext.CurrentNPC.Name == "Jon")
        {
            TextUtils.TypeText("Jon nods: 'See you around!'");
            ConversationContext.CurrentNPC = null;
        }
        else
        {
            TextUtils.TypeText("You are dead");
        }
        States.ChangeState(StateTypes.Exploring);
    }
}