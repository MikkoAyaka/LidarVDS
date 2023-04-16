namespace LidarVDS.Pages.Help;

public class PageHelpService
{
    private PageHelpService() {}
    private static class InstanceHolder
    {
        public static readonly PageHelpService Instance = new();
        public static readonly PageHelp Page = new();
    }
    public static PageHelp GetPage()
    {
        return InstanceHolder.Page;
    }
    public static PageHelpService GetInstance()
    {
        return InstanceHolder.Instance;
    }
}