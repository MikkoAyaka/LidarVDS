using System;
using System.Collections.Generic;

namespace LidarVDS.Utils;

public class TimingUtil
{
    private static Dictionary<string, int> _timingCache = new();

    /**
     * 开始一个计时任务
     */
    public static void StartTiming(string taskName)
    {
        _timingCache[taskName] = DateTime.Now.Millisecond;
    }

    /**
     * 获取计时任务的结果
     */
    public static long StopTiming(string taskName)
    {
        if (!_timingCache.ContainsKey(taskName)) return -1;
        else return DateTime.Now.Millisecond - _timingCache[taskName];
    }
}