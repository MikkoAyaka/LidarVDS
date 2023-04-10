using System;
using HandyControl.Controls;

namespace LidarVDS.Utils;

public static class AppLogger
{
    private const bool DebugMode = true;
    public static void LogDebug(this string msg)
    {
        if(DebugMode) Growl.Warning(msg);
    }

    public static void LogInfo(this string msg)
    {
        Growl.Info(msg);
    }

    public static void LogError(this string msg)
    {
        Growl.Error(msg);
    }

    public static void LogSuccess(this string msg)
    {
        Growl.Success(msg);
    }

    public static void LogFailed(this string msg)
    {
        Growl.Fatal(msg);
    }
}