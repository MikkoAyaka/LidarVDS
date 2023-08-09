namespace LidarVDS.Pages.Analysis;

public class PageAnalysisService
{
    private PageAnalysisService() {}
    private static class InstanceHolder
    {
        public static readonly PageAnalysisService Instance = new();
        public static readonly PageAnalysis Page = new();
    }
    public static PageAnalysis GetPage()
    {
        return InstanceHolder.Page;
    }
    public static PageAnalysisService GetInstance()
    {
        return InstanceHolder.Instance;
    }
}

