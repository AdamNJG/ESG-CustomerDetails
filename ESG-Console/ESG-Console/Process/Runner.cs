using ESG_Console_Parser.ParserServices;

namespace ESG_Console.Process
{
    public class Runner
    {
        private readonly CsvParserService _parserService;

        public Runner(CsvParserService parserService)
        {
            _parserService = parserService;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Enter a command (type 'exit' to quit or 'help' to get help):");

                string input = GetInput();

                if (input != null && input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                ProcessCommand(input);
            }
        }

        private void ProcessCommand(string input)
        {
            switch (input.ToUpper())
            {
                case "HELP":
                    ListHelp();
                    break;
                case "PARSE":
                    ParseMenu();
                    break;
                default:
                    Console.WriteLine("invalid command");
                    break;
            }
        }

        private static void ListHelp()
        {
            Console.WriteLine("\"parse\": Parse a CSV file use the command ");
        }

        private void ParseMenu()
        {
            while (true)
            {
                Console.WriteLine("Please enter the path to the file that you wish to send (do not wrap the path in quotes)");

                string input = GetInput();

                try
                {
                    _parserService.ParseAndSendCustomerDetails(input);
                    Console.WriteLine("File parsed and sent");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        private string GetInput()
        {
            string input = Console.ReadLine();

            if (input == null)
            {
                return input;
            }

            return input.Trim();
        }
    }
}
