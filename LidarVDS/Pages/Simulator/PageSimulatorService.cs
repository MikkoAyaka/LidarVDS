namespace LidarVDS.Pages.Simulator;

public class PageSimulatorService
{
    private PageSimulatorService() {}
    private static class InstanceHolder
    {
        public static readonly PageSimulatorService Instance = new();
        public static readonly PageSimulator Page = new();
    }
    public static PageSimulator GetPage()
    {
        return InstanceHolder.Page;
    }
    public static PageSimulatorService GetInstance()
    {
        return InstanceHolder.Instance;
    }
}