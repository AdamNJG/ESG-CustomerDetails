using ESG_Console_Parser.Customer;
using ESG_Console_Parser.ParserServices;
using ESG_Console_Parser_Test.TestDoubles;
using ESG_Console_Parser_Test.TestHelpers;
using FluentAssertions;

namespace ESG_Console_Parser_Test
{
    [TestClass]
    public class ParserServiceTests
    {
        private static readonly string testFileDirectory = "./test-csv-files";
        private static readonly string testFilePath = Path.Combine(testFileDirectory, "test.csv");

        [TestInitialize]
        public void TestInitialize()
        {
            ParserServiceTestHelper.DeleteTestDirectory(testFileDirectory);
            Directory.CreateDirectory(testFileDirectory);
        }

        /*
        [TestMethod]
        public void ParserService_ReadFile_MatchesSource()
        {
            CustomerData data = ParserServiceTestHelper.CreateTestCustomerData();
            ParserServiceTestHelper.WriteCsv(testFilePath, data);

            CustomerData readData = CsvParserService.ParseCustomerData(testFilePath).First();

            readData.Should().BeEquivalentTo(readData);
        }

        [TestMethod]
        public void ParserService_ReadFileMultiple_MatchesSource()
        {
            List<CustomerData> data = ParserServiceTestHelper.CreateTestCustomerDataList();
            ParserServiceTestHelper.WriteCsvMultipleRecords(testFilePath, data);

            List<CustomerData> readData = CsvParserService.ParseCustomerData(testFilePath);

            readData.Should().BeEquivalentTo(data);
        }

        [TestMethod]
        public void ParserService_ReadFileNotExisting_ThrowsFileNotFoundException()
        {
            Action act = () =>
            {
                List<CustomerData> readData = CsvParserService.ParseCustomerData(testFilePath);
            };

            act.Should().Throw<FileNotFoundException>();
        }
        
        [TestMethod]
        public void ParserService_ReadFileEmpty_ThrowsException()
        {
            ParserServiceTestHelper.CreateEmptyCsv(testFilePath);

            Action act = () =>
            {
                List<CustomerData> readData = CsvParserService.ParseCustomerData(testFilePath);
            };

            act.Should().Throw<IOException>()
                .WithMessage($"The File at path {testFilePath} was empty");
        }*/

        [TestMethod]
        public void ParserService_SendDataMultipleCustomers()
        {
            List<CustomerDataDto> data = ParserServiceTestHelper.CreateTestCustomerDataList();
            ParserServiceTestHelper.WriteCsvMultipleRecords(testFilePath, data);

            TestCustomerSender mockSender = new TestCustomerSender();

            CsvParserService csvParser = new CsvParserService(mockSender);

            csvParser.ParseAndSendCustomerData(testFilePath);

            List<CustomerDataDto> retrievedData = mockSender.Customers;

            retrievedData.Should().BeEquivalentTo(data);
        }

        [TestMethod]
        public void ParserService_ParseAndSendNotExisting_ThrowsFileNotFoundException()
        {
            TestCustomerSender mockSender = new TestCustomerSender();

            CsvParserService csvParser = new CsvParserService(mockSender);

            Action act = () =>
            {
                csvParser.ParseAndSendCustomerData(testFilePath);
            };

            act.Should().Throw<FileNotFoundException>();
        }

        [TestMethod]
        public void ParserService_ParseAndSendEmpty_ThrowsIOException()
        {
            ParserServiceTestHelper.CreateEmptyCsv(testFilePath);

            TestCustomerSender mockSender = new TestCustomerSender();

            CsvParserService csvParser = new CsvParserService(mockSender);

            Action act = () =>
            {
                csvParser.ParseAndSendCustomerData(testFilePath);
            };

            act.Should().Throw<IOException>()
                .WithMessage($"The File at path {testFilePath} was empty");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            ParserServiceTestHelper.DeleteTestDirectory(testFileDirectory);
        }
    }
}
