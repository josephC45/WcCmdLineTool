namespace WCApp.UtilizingStdin
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class OneArgFactory(string? option) : HandleCmd
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        public string? option { get; set; } = option;

        private OneArgHandler _oneArgHandler;
        public override void HandleWcCommand()
        {
            _oneArgHandler = new(this);
        }

        public override void GetWcOutput()
        {
            _oneArgHandler.GetResults();
        }
    }
}
