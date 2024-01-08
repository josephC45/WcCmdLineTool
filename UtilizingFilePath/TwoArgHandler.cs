using WCApp.Interfaces;

namespace WCApp.UtilizingFilePath
{
    public class TwoArgHandler : IWcOptionFunctions
    {
        private readonly TwoArgFactory _twoArgFactory;
        public TwoArgHandler(TwoArgFactory twoArgs)
        {
            _twoArgFactory = twoArgs;
        }

        #region Methods pertaining to specific wc options with File path as argument
        public bool InputExists()
        {
            return File.Exists(_twoArgFactory.path);
        }
        public int NumberOfCharacters()
        {
            return File.ReadAllText(_twoArgFactory.path).Length;
        }
        public int NumberOfLines()
        {
            return File.ReadAllLines(_twoArgFactory.path).Length;
        }
        public int NumberOfWords()
        {
            int count = 0;
            using (StreamReader reader = new StreamReader(_twoArgFactory.path))
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
            long count = new FileInfo(_twoArgFactory.path).Length;
            return Convert.ToInt16(count);
        }
        #endregion

        private void PrintOptionOutput(int optionRan)
        {
            Console.WriteLine($"{optionRan} {_twoArgFactory.path}");
        }
        private void HandleCmdResults()
        {

            int lines, byytes, words, characters;
            if (!InputExists())
            {
                Console.WriteLine("Path does not exist try again");
                return;
            }

            if (_twoArgFactory.option == null)
            {
                lines = NumberOfLines();
                words = NumberOfWords();
                byytes = NumberOfBytes();
                Console.WriteLine($"{lines} {words} {byytes} {_twoArgFactory.path}");
            }
            else if (_twoArgFactory.option.Equals(Constants.ProgramConstants.wcOptions[0]))
            {
                lines = NumberOfLines();
                PrintOptionOutput(lines);
            }
            else if (_twoArgFactory.option.Equals(Constants.ProgramConstants.wcOptions[1]))
            {
                byytes = NumberOfBytes();
                PrintOptionOutput(byytes);
            }
            else if (_twoArgFactory.option.Equals(Constants.ProgramConstants.wcOptions[2]))
            {
                words = NumberOfWords();
                PrintOptionOutput(words);
            }
            else if (_twoArgFactory.option.Equals(Constants.ProgramConstants.wcOptions[3]))
            {
                characters = NumberOfCharacters();
                PrintOptionOutput(characters);
            }
        }

        public void GetResults()
        {
            HandleCmdResults();
        }

    }
}
