namespace LidarVDS.Pages.Settings.SettingPages.LidarPage;

public class LidarService
{
    private LidarService() {}
    private static class InstanceHolder
    {
        public static readonly LidarService Instance = new();
        public static readonly Lidar Page = new();
    }
    public static Lidar GetPage()
    {
        return InstanceHolder.Page;
    }
    public static LidarService GetInstance()
    {
        return InstanceHolder.Instance;
    }
}