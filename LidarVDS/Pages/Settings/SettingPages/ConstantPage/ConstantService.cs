using LidarVDS.Pages.Settings.SettingPages.ConstantPage;

namespace LidarVDS.Pages.Settings.SettingPages.ConstantPage;

public class ConstantService
{
    private ConstantService() {}
    private static class InstanceHolder
    {
        public static readonly ConstantService Instance = new();
        public static readonly Constant Page = new();
    }
    public static Constant GetPage()
    {
        return InstanceHolder.Page;
    }
    public static ConstantService GetInstance()
    {
        return InstanceHolder.Instance;
    }
}