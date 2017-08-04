namespace HelpYou.Com.DB.Context
{
    public class ContextFactory
    {
        private readonly static object obj=new object();
        private static HelpYouDbContext _instance;
        private ContextFactory() { }
        public static HelpYouDbContext GetInstanceContext()
        {
            if (_instance == null)
            {
                lock (obj)
                {
                    _instance = _instance ?? (_instance = new HelpYouDbContext());
                }
            }
            return _instance;
        }
    }
}
