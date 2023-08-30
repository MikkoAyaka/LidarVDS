namespace LidarVDS.Pages.Settings.SettingPages.OtherPage;

public class OtherService
{
    private OtherService() {}
    private static class InstanceHolder
    {
        public static readonly OtherService Instance = new();
        public static readonly Other Page = new();
    }
    public static Other GetPage()
    {
        return InstanceHolder.Page;
    }
    public static OtherService GetInstance()
    {
        return InstanceHolder.Instance;
    }
}