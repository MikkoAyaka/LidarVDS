namespace LidarVDS.Pages.Settings;

public class PageSettingsService
{
    private PageSettingsService() {}
    private static class InstanceHolder
    {
        public static readonly PageSettingsService Instance = new();
        public static readonly PageSettings Page = new();
    }
    public static PageSettings GetPage()
    {
        return InstanceHolder.Page;
    }
   public static PageSettingsService GetInstance()
    {
        return InstanceHolder.Instance;
    }
}