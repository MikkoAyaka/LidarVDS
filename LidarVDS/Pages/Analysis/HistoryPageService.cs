namespace LidarVDS.Pages.Analysis;

public  class HistoryPageService
{
    private HistoryPageService() {}
    private static class InstanceHolder
    {
        public static readonly HistoryPageService Instance = new();
        public static readonly HistoryPage Page = new();
    }
    public static HistoryPage GetPage()
    {
        return InstanceHolder.Page;
    }
    
    public static HistoryPageService GetInstance()
    {
        return InstanceHolder.Instance;
    }
    
    
}