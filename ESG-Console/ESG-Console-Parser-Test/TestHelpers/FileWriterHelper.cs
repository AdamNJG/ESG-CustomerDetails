﻿using ESG_Console_Parser.Customer;

namespace ESG_Console_Parser_Test.TestHelpers
{
    internal static class ParserServiceTestHelper
    {
        public static void WriteCsv(string path, CustomerDetailsDto data, bool append = false)
        {
            string csvLine = String.Format("{0},{1},{2},{3},{4},{5},{6},{7}", data.CustomerRef.ToString(), data.CustomerName, data.AddressLine1, data.AddressLine2, data.Town, data.County, data.Country, data.PostCode);

            using (StreamWriter writer = new StreamWriter(path, append))
            {
                if (!append)
                {
                    writer.WriteLine("Customer Ref,Customer Name,Address Line 1,Address Line 2,Town,County,Country,Postcode");
                }
                writer.WriteLine(csvLine);
            }
        }

        public static void WriteCsvMultipleRecords(string path, List<CustomerDetailsDto> data)
        {
            ParserServiceTestHelper.CreateCsvNoRecords(path);
            data.ForEach(c =>
            {
                ParserServiceTestHelper.WriteCsv(path, c, true);
            });
        }

        public static void CreateCsvNoRecords(string path)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine("Customer Ref,Customer Name,Address Line 1,Address Line 2,Town,County,Country,Postcode");
            }
        }

        /*
        public static CustomerDetailsDto CreateTestCustomerDetails()
        {
            string customerRef = Guid.NewGuid().ToString();
            string customerName = "John Smith";
            string addressLine1 = "1 Main Street";
            string addressLine2 = string.Empty;
            string town = "London";
            string county = "Greater London";
            string country = "United Kingdom";
            string postCode = "E1 7PT";

            return new CustomerDetailsDto(customerRef, customerName, addressLine1, addressLine2, town, county, country, postCode);
        }*/

        public static List<CustomerDetailsDto> CreateTestCustomerDetailsList()
        {
            List<CustomerDetailsDto> list = new List<CustomerDetailsDto>();
            list.Add(new CustomerDetailsDto("4c239663-2dd5-4f9a-97f1-56b6fb7c0de7", "John Smith", "1 Main Street", string.Empty, "London", string.Empty, "United Kingdom", "E1 7PT"));
            list.Add(new CustomerDetailsDto("1d24d895-8651-47b1-84ae-4dfb43e28994", "Jane Doe", "10 Park Avenue", "Suburb", "Manchester", string.Empty, "United Kingdom", "M4 5WL"));
            list.Add(new CustomerDetailsDto("dc8e7c7d-baa2-4bb4-8f39-3c9a03a39068", "David Johnson", "25 High Street", string.Empty, "Birmingham", string.Empty, "United Kingdom", "B5 2DB"));
            list.Add(new CustomerDetailsDto("cb9e0639-2b5c-4815-bdf7-2483e0e33012", "Sarah Williams", "5 Elm Road", string.Empty, "Glasgow", string.Empty, "United Kingdom", "G3 8RT"));
            list.Add(new CustomerDetailsDto("0d972e85-9d26-4df5-b34d-90c9f22a504a", "Michael Brown", "7 Victoria Square", string.Empty, "Leeds", "yorkshire", "United Kingdom", "LS1 4AD"));

            return list;
        }

        public static void CreateEmptyCsv(string path)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {

            }
        }

        public static void DeleteTestDirectory(string directory)
        {
            if (Directory.Exists(directory))
            {
                Directory.Delete(directory, true);
            }
        }
    }
}
