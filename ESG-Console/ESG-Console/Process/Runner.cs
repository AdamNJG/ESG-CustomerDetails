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

                string input = Console.ReadLine();

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
            Console.WriteLine("To Parse a CSV file use the command \"parse\"");
        }

        private void ParseMenu()
        {
            Console.WriteLine("Please enter the path to the file that you wish to send");

            string input = Console.ReadLine();

            if (input == null || !File.Exists(input))
            {
                Console.WriteLine("invalid input or file not found, returning to main menu");
                return;
            }

            try
            {
                _parserService.ParseAndSendCustomerData(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("File parsed and sent");
        }
    }
}
