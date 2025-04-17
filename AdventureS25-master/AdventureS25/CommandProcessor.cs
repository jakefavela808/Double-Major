namespace AdventureS25;

public static class CommandProcessor
{
    public static Command Process()
    {
        while (true)
        {
            string rawInput = GetInput();
            Command command = Parser.Parse(rawInput);

            // If both verb and noun are blank, stay on the same line and prompt again
            if (string.IsNullOrWhiteSpace(command.Verb) && string.IsNullOrWhiteSpace(command.Noun))
            {
                continue;
            }

            Debugger.Write("Verb: [" + command.Verb + "]");
            Debugger.Write("Noun: [" + command.Noun + "]");
            
            // make sure we have the words in our vocabulary
            bool isValid = CommandValidator.IsValid(command);
            command.IsValid = isValid;

            // do stuff with the command
            Debugger.Write("isValid = " + isValid);

            return command;
        }
    }
    
    public static string GetInput()
    {
        // Print the prompt without a newline
        Console.Write("> ");
        string input = ReadLineNoExtraNewline();
        return input;
    }

    // Reads a line from the console, but prevents extra newlines or double prompts on blank input
    private static string ReadLineNoExtraNewline()
    {
        var input = new System.Text.StringBuilder();
        while (true)
        {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter)
            {
                if (input.Length == 0)
                {
                    // Do not print anything, just break and let GetInput print the prompt again
                    Console.Write("\r> "); // Overwrite prompt on same line
                    continue;
                }
                Console.WriteLine();
                break;
            }
            else if (key.Key == ConsoleKey.Backspace)
            {
                if (input.Length > 0)
                {
                    input.Length--;
                    Console.Write("\b \b");
                }
            }
            else
            {
                input.Append(key.KeyChar);
                Console.Write(key.KeyChar);
            }
        }
        return input.ToString();
    }
}