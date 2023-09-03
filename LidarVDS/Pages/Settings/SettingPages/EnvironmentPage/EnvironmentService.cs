namespace LidarVDS.Pages.Settings.SettingPages.EnvironmentPage;

public class EnvironmentService
{
    private EnvironmentService() {}
    private static class InstanceHolder
    {
        public static readonly EnvironmentService Instance = new();
        public static readonly Environment Page = new();
    }
    public static Environment GetPage()
    {
        return InstanceHolder.Page;
    }
    public static EnvironmentService GetInstance()
    {
        return InstanceHolder.Instance;
    }
}