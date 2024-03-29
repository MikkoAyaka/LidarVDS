using System;
using HandyControl.Controls;

namespace LidarVDS.Utils;

public static class AppLogger
{
    public static bool DebugMode;
    
    public static void LogDebug(this string msg)
    {
        if(DebugMode) Growl.Warning(msg);
    }

    public static void LogInfo(this string msg)
    {
        if(DebugMode) Growl.Info(msg);
    }

    public static void LogError(this string msg)
    {
        if(DebugMode) Growl.Error(msg);
    }

    public static void LogSuccess(this string msg)
    {
        if(DebugMode) Growl.Success(msg);
    }

    public static void LogFailed(this string msg)
    {
        if(DebugMode) Growl.Fatal(msg);
    }
}