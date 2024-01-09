using System.Text;
using WCApp.Interfaces;

namespace WCApp.UtilizingStdin
{
    public class OneArgHandler : IWcNeededFunctions
    {
        private List<string> _stdinStr = new List<string>();
        private readonly OneArgFactory _wcWithOneArg;
        public OneArgHandler(OneArgFactory wcWithOneArg)
        {
            _wcWithOneArg = wcWithOneArg;
        }

        public bool InputExists()
        {
            return Console.IsInputRedirected;
        }

        public void ReadStdIn()
        {
            string? line;
            while ((line = Console.In.ReadLine()) != null)
            {
                _stdinStr.Add(line);
            }
            Console.In.Dispose();
            return;
        }

        public int NumberOfBytes()
        {
            int count = 0;
            foreach (string line in _stdinStr)
            {
                count += System.Text.ASCIIEncoding.UTF8.GetByteCount(line);
            }
            return count;
        }

        public int NumberOfCharacters()
        {
            int count = 0;
            foreach (string line in _stdinStr)
            {
                count += line.Length;
            }
            return count;
        }
        public int NumberOfLines()
        {
            return _stdinStr.Count;
        }
        public int NumberOfWords()
        {
            int count = 0;
            foreach (string line in _stdinStr)
            {
                count += line.Split(new char[] {' ','\n','\r'}, StringSplitOptions.RemoveEmptyEntries).Count();
            }
            return count;
        }
        private void PrintOptionOutput(int optionRan)
        {
            Console.WriteLine($"{optionRan}");
        }
        private void HandleCmdResults()
        {

            int lines, byytes, words, characters;

            if (!InputExists())
            {
                Console.WriteLine("No Stdin was read try again.");
                return;
            }
            else ReadStdIn();

            if (_wcWithOneArg.option == null)
            {
                lines = NumberOfLines();
                words = NumberOfWords();
                byytes = NumberOfBytes();
                Console.WriteLine($"{lines} {words} {byytes}");
            }
            else if (_wcWithOneArg.option.Equals(Constants.ProgramConstants.wcOptions[0]))
            {
                lines = NumberOfLines();
                PrintOptionOutput(lines);
            }
            else if (_wcWithOneArg.option.Equals(Constants.ProgramConstants.wcOptions[1]))
            {
                byytes = NumberOfBytes();
                PrintOptionOutput(byytes);
            }
            else if (_wcWithOneArg.option.Equals(Constants.ProgramConstants.wcOptions[2]))
            {
                words = NumberOfWords();
                PrintOptionOutput(words);
            }
            else if (_wcWithOneArg.option.Equals(Constants.ProgramConstants.wcOptions[3]))
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
