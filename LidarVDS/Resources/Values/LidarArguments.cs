using System.Collections.Generic;
using System.Linq;

namespace LidarVDS.Resources.Values;

/**
 * 枚举类
 */
public enum LidarArgumentsEnum
{
    ENV_PM2D5 = 0,
    ENV_PM10 = 1,
    ENV_AQI = 2,
    ENV_RELATIVE_WIND_SPEED = 3,
    ENV_HUMIDITY = 4,
    ENV_ATMOSPHEIC_PRESSURE = 5
}

/**
 * 数据类
 */
public record LidarArgumentsData(string ImgPath, string Name, double MinValue, double MaxValue, double NowValue,
    string Units)
{
}

/**
 * 仓库类
 */
public class LidarArgumentsRepository
{
    private LidarArgumentsRepository()
    {
    }

    private static class InstanceHolder
    {
        public static readonly LidarArgumentsRepository Instance = new();
    }

    public static LidarArgumentsRepository GetInstance()
    {
        return InstanceHolder.Instance;
    }

    private readonly Dictionary<LidarArgumentsEnum, LidarArgumentsData> _dictionary = new()
    {
        { LidarArgumentsEnum.ENV_PM2D5, new LidarArgumentsData("pack://application:,,,/Resources/Images/PM2.5.png", "PM2.5", 0, 300, 0, "μg/m³") },
        { LidarArgumentsEnum.ENV_PM10, new LidarArgumentsData("pack://application:,,,/Resources/Images/PM10.png", "PM10", 0, 300, 0, "μg/m³") },
        { LidarArgumentsEnum.ENV_AQI, new LidarArgumentsData("pack://application:,,,/Resources/Images/AQI.png", "AQI", 0, 100, 100, "点") },
        { LidarArgumentsEnum.ENV_HUMIDITY, new LidarArgumentsData("pack://application:,,,/Resources/Images/SD.png", "湿度", 0, 100, 50, "%") },
        { LidarArgumentsEnum.ENV_RELATIVE_WIND_SPEED, new LidarArgumentsData("pack://application:,,,/Resources/Images/XDFS.png", "风速", 0, 60, 0, "m/s") },
        { LidarArgumentsEnum.ENV_ATMOSPHEIC_PRESSURE, new LidarArgumentsData("pack://application:,,,/Resources/Images/QY.png", "气压", 0.5, 2, 1, "atm") }
    };

    public List<LidarArgumentsData> GetAllData()
    {
        return _dictionary.Values.ToList();
    }

    public LidarArgumentsData GetData(LidarArgumentsEnum e)
    {
        return _dictionary[e];
    }
}