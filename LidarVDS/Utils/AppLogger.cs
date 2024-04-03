using System;
using HandyControl.Controls;

namespace LidarVDS.Utils;

public static class AppLogger
{
    public static bool Enabled;
    
    public static void LogDebug(this string msg)
    {
        if(Enabled) Growl.Warning(msg);
    }

    public static void LogInfo(this string msg)
    {
        if(Enabled) Growl.Info(msg);
    }

    public static void LogError(this string msg)
    {
        if(Enabled) Growl.Error(msg);
    }

    public static void LogSuccess(this string msg)
    {
        if(Enabled) Growl.Success(msg);
    }

    public static void LogFailed(this string msg)
    {
        if(Enabled) Growl.Fatal(msg);
    }
}