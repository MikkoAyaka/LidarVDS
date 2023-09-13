namespace LidarVDS.Pages.Analysis;

public  class HistoryPageService
{
    private HistoryPageService() {}
    private static class InstanceHolder
    {
        public static readonly HistoryPage Instance = new();
        public static readonly HistoryPage Page = new();
    }
    public static HistoryPage GetPage()
    {
        return InstanceHolder.Page;
    }
    
    public static HistoryPage GetInstance()
    {
        return InstanceHolder.Instance;
    }
    
    
}