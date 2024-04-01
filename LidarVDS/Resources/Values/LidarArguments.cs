using System;
using System.Collections.Generic;
using System.Linq;

namespace LidarVDS.Resources.Values;

/**
 * 枚举类
 */
public enum LidarArgumentNameEnum
{
    // PM 2.5
    PM2D5,
    // PM 10
    PM10,
    // 空气质量指数
    AQI,
    // 相对风速
    RelativeWindSpeed,
    // 湿度
    Humidity,
    // 气压
    AtmospheicPressure,
    // 光速
    LightSpeed,
    // 普朗克常数
    PlanckConstant,
    
    //能见度
    Visibility,
    
    // 波长
    Wavelength,
    // 发射光束直径,
    DiameterEmitLight,
    // 接收光束直径
    DiameterReceiveLight,
    // 发射光束夹角
    AngleEmitLight,
    // 接收光束夹角
    AngleReceiveLight,
    // 发射光束和接收光束的间距
    DistanceBetween,
    // 激光功率
    LaserPower,
    // 脉冲宽度
    PulseWidth,
    // 接收面积
    AreaReceive,
    // 发射透过率
    TransmittanceEmit,
    // 接收透过率
    TransmittanceReceive,
    // 量子效率
    QuantumEfficiency,
}

public enum LidarArgumentTypeEnum
{
    // 环境参数
    Environment,
    // 常量参数
    Constant,
    // 光学单元
    OpticalUnit,
}

/**
 * 数据类
 */
public record LidarArgumentsData(
    LidarArgumentTypeEnum ArgType,
    LidarArgumentNameEnum ArgName,
    string ImgPath,
    string Name,
    double MinValue,
    double MaxValue,
    double NowValue,
    string Units
);

    

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

    private readonly List<LidarArgumentsData> _list = new()
    {
        new LidarArgumentsData(LidarArgumentTypeEnum.Environment,LidarArgumentNameEnum.PM2D5,"pack://application:,,,/Resources/Images/PM2.5.png", "PM2.5", 0, 300, 0, "μg/m³"),
        new LidarArgumentsData(LidarArgumentTypeEnum.Environment,LidarArgumentNameEnum.PM10,"pack://application:,,,/Resources/Images/PM10.png", "PM10", 0, 300, 0, "μg/m³"),
        new LidarArgumentsData(LidarArgumentTypeEnum.Environment,LidarArgumentNameEnum.AQI,"pack://application:,,,/Resources/Images/AQI.png", "AQI", 0, 100, 100, "点"),
        new LidarArgumentsData(LidarArgumentTypeEnum.Environment,LidarArgumentNameEnum.Humidity,"pack://application:,,,/Resources/Images/SD.png", "湿度", 0, 100, 50, "%"),
        new LidarArgumentsData(LidarArgumentTypeEnum.Environment,LidarArgumentNameEnum.RelativeWindSpeed,"pack://application:,,,/Resources/Images/XDFS.png", "风速", 0, 60, 0, "m/s"),
        new LidarArgumentsData(LidarArgumentTypeEnum.Environment,LidarArgumentNameEnum.AtmospheicPressure,"pack://application:,,,/Resources/Images/QY.png", "气压", 0.5, 2, 1, "atm"),
        new LidarArgumentsData(LidarArgumentTypeEnum.Environment,LidarArgumentNameEnum.Visibility,"pack://application:,,,/Resources/Images/QY.png", "能见度", 200, 20000, 5000, "m"),
        
        new LidarArgumentsData(LidarArgumentTypeEnum.Constant,LidarArgumentNameEnum.LightSpeed,"pack://application:,,,/Resources/Images/QY.png", "光速", 299792458, 299792458, 299792458, "m/s"),
        new LidarArgumentsData(LidarArgumentTypeEnum.Constant,LidarArgumentNameEnum.PlanckConstant,"pack://application:,,,/Resources/Images/QY.png", "普朗克常数", 6.62607015 * Math.Pow(10, -34), 6.62607015 * Math.Pow(10, -34), 6.62607015 * Math.Pow(10, -34), "N·m·s"),
        
        new LidarArgumentsData(LidarArgumentTypeEnum.OpticalUnit,LidarArgumentNameEnum.Wavelength,"pack://application:,,,/Resources/Images/QY.png", "波长", 905 * Math.Pow(10, -9), 905 * Math.Pow(10, -9), 905 * Math.Pow(10, -9), "m"),
        new LidarArgumentsData(LidarArgumentTypeEnum.OpticalUnit,LidarArgumentNameEnum.DiameterEmitLight,"pack://application:,,,/Resources/Images/QY.png", "发射光束直径", 62.5 * Math.Pow(10, -6), 62.5 * Math.Pow(10, -6), 62.5 * Math.Pow(10, -6), "m"),
        new LidarArgumentsData(LidarArgumentTypeEnum.OpticalUnit,LidarArgumentNameEnum.DiameterReceiveLight,"pack://application:,,,/Resources/Images/QY.png", "接收光束直径", 50 * Math.Pow(10, -3), 50 * Math.Pow(10, -3), 50 * Math.Pow(10, -3), "m"),
        new LidarArgumentsData(LidarArgumentTypeEnum.OpticalUnit,LidarArgumentNameEnum.AngleEmitLight,"pack://application:,,,/Resources/Images/QY.png", "发射光束夹角", 0.715 * Math.Pow(10, -3),0.715 * Math.Pow(10, -3),0.715 * Math.Pow(10, -3), "rad"),
        new LidarArgumentsData(LidarArgumentTypeEnum.OpticalUnit,LidarArgumentNameEnum.AngleReceiveLight,"pack://application:,,,/Resources/Images/QY.png", "接收光束夹角", 1.2 * Math.Pow(10, -3),1.2 * Math.Pow(10, -3),1.2 * Math.Pow(10, -3), "rad"),
        new LidarArgumentsData(LidarArgumentTypeEnum.OpticalUnit,LidarArgumentNameEnum.DistanceBetween,"pack://application:,,,/Resources/Images/QY.png", "收发单元间距", 120 * Math.Pow(10, -3),120 * Math.Pow(10, -3),120 * Math.Pow(10, -3), "m"),
        
        new LidarArgumentsData(LidarArgumentTypeEnum.OpticalUnit,LidarArgumentNameEnum.LaserPower,"pack://application:,,,/Resources/Images/QY.png", "激光功率", 0.8,0.15,0.11, "w"),
        new LidarArgumentsData(LidarArgumentTypeEnum.OpticalUnit,LidarArgumentNameEnum.PulseWidth,"pack://application:,,,/Resources/Images/QY.png", "脉冲宽度", 0.00000003,0.0000001,0.00000005, "m"),
        new LidarArgumentsData(LidarArgumentTypeEnum.OpticalUnit,LidarArgumentNameEnum.AreaReceive,"pack://application:,,,/Resources/Images/QY.png", "接收望远镜面积", Math.PI * 0.04 * 0.04,Math.PI * 0.06 * 0.06,Math.PI * 0.05 * 0.05, "m^2"),
        new LidarArgumentsData(LidarArgumentTypeEnum.OpticalUnit,LidarArgumentNameEnum.TransmittanceEmit,"pack://application:,,,/Resources/Images/QY.png", "发射望远镜透过率", 0,1,1.0, ""),
        new LidarArgumentsData(LidarArgumentTypeEnum.OpticalUnit,LidarArgumentNameEnum.TransmittanceReceive,"pack://application:,,,/Resources/Images/QY.png", "接收望远镜透过率", 0,1,0.5, ""),
        new LidarArgumentsData(LidarArgumentTypeEnum.OpticalUnit,LidarArgumentNameEnum.QuantumEfficiency,"pack://application:,,,/Resources/Images/QY.png", "量子效率", 0,1,0.38, ""),
        
        
    };

    public List<LidarArgumentsData> GetArguments()
    {
        return _list;
    }

    public List<LidarArgumentsData> GetArguments(LidarArgumentTypeEnum typeEnum)
    {
        return _list.Where(x => x.ArgType == typeEnum).ToList();
    }

    public LidarArgumentsData GetArguments(LidarArgumentNameEnum nameEnum)
    {
        return _list.First(x => x.ArgName == nameEnum);
    }
}