namespace WCApp
{
    /// <summary>
    /// Going through the process of practicing a Factory method design pattern
    /// </summary>
    public abstract class HandleCmd
    {
        //Factory method
        public abstract void HandleWcCommand();

        public HandleCmd()
        { 
            this.HandleWcCommand();
        }
        public abstract void GetWcOutput();
      
    }
}
