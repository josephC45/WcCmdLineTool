using WCApp.Interfaces;

namespace WcAppTests.UtilizingFilePathMockAndTests
{
    internal class TwoArgHandlerMock : IWcNeededFunctions
    {
        public string path = @"";
        public bool InputExists()
        {
            return File.Exists(path);
        }
        public int NumberOfCharacters()
        {
            return File.ReadAllText(path).Length;
        }
        public int NumberOfLines()
        {
            return File.ReadAllLines(path).Length;
        }
        public int NumberOfWords()
        {
            int count = 0;
            using (StreamReader reader = new StreamReader(path))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    count += line.Split(" ").Length;
                }
            }
            return count;
        }
        public int NumberOfBytes()
        {
            long count = new FileInfo(path).Length;
            return Convert.ToInt16(count);
        }
    }
}
