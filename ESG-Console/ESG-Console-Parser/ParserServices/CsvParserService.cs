using ESG_Console_Parser.Customer;
using ESG_Console_Parser.Ports;
using Microsoft.VisualBasic.FileIO;

namespace ESG_Console_Parser.ParserServices
{
    public class CsvParserService
    {
        ICustomerSender _customerSender;

        public CsvParserService(ICustomerSender customerSender)
        {
            _customerSender = customerSender;
        }

        private static List<CustomerDetailsDto> ParseCustomerDetails(string path)
        {
            List<CustomerDetailsDto> customers = new List<CustomerDetailsDto>();
            using (TextFieldParser parser = new TextFieldParser(path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                if (parser.EndOfData || parser.ReadLine() == null)
                {
                    throw new IOException($"The File at path {path} was empty");
                }

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields()!; // this is suppressing a null warning, when I have already added a nullcheck.
                    if (fields == null)
                    {
                        continue;
                    }

                    customers.Add(new CustomerDetailsDto(
                        fields[0],
                        fields[1],
                        fields[2],
                        fields[3],
                        fields[4],
                        fields[5],
                        fields[6],
                        fields[7]
                        ));
                }
            }

            return customers;
        }

        public void ParseAndSendCustomerDetails(string path)
        {
            List<CustomerDetailsDto> customerDetails = ParseCustomerDetails(path);

            foreach (CustomerDetailsDto customerDetailsDto in customerDetails)
            {
                _customerSender.SendCustomerDetails(customerDetailsDto);
            }
        }
    }
}