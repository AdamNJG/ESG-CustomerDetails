﻿using ESG_Console_Parser.Customer;
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

        private static List<CustomerData> ParseCustomerData(string path)
        {
            List<CustomerData> customers = new List<CustomerData>();
            using (TextFieldParser parser = new TextFieldParser(path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                if (parser.EndOfData || parser.ReadLine() == null)
                {
                    throw new IOException($"The File at path {path} was empty");
                }

                int count = 0;
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    count++;

                    customers.Add(new CustomerData(
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

        public void ParseAndSendCustomerData(string path)
        {
            List<CustomerData> customerData = ParseCustomerData(path);

            customerData.ForEach(c =>
            {
                _customerSender.SendCustomerData(c);
            });
        }
    }
}