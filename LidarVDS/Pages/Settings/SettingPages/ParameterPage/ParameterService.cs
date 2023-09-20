namespace LidarVDS.Pages.Settings.SettingPages.ParameterPage;

public class ParameterService
{
    private ParameterService() {}
    private static class InstanceHolder
    {
        public static readonly ParameterService Instance = new();
        public static readonly Parameter Page = new();
    }
    public static Parameter GetPage()
    {
        return InstanceHolder.Page;
    }
    public static ParameterService GetInstance()
    {
        return InstanceHolder.Instance;
    }
}