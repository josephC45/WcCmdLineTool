namespace WCApp.UtilizingFilePath
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class TwoArgFactory(string? option, string path) : HandleCmd
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        public string? option { get; set; } = option;
        public string path { get; set; } = path;

        private TwoArgHandler _handle;

        public override void HandleWcCommand()
        {
            _handle = new(this);
        }

        public override void GetWcOutput()
        {
            _handle.GetResults();
        }
    }
}
