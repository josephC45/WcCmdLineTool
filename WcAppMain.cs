using WCApp.UtilizingFilePath;
using WCApp.UtilizingStdin;
//TODO: Finish testing for Stdin
namespace WCApp
{
    public class WcAppMain
    {
        public void ValidateArguments(ref string? path, ref string? option, string[] args)
        {
            if(args.Length == 2)
            {
                option = args[0];
                path = args[1];
            }else if(args.Length == 1)
            {
                if (Console.IsInputRedirected)
                {
                    path = null;
                    option = args[0];
                }
                else
                {
                    path = args[0];
                    option = null;
                }
            }
        }
        public static void Main(string[] args)
        {
            WcAppMain main = new();
            string? path = null;
            string? option = null;

            main.ValidateArguments(ref path, ref option, args);

            //If we have a file path to utilize
            if (path != null)
            {
                HandleCmd wc = new TwoArgFactory(option, path);
                wc.GetWcOutput();
            }
            else
            {
                HandleCmd wc = new OneArgFactory(option);
                wc.GetWcOutput();
            }
        }
    }
}
