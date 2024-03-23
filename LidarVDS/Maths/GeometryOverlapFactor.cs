using System;
using System.Diagnostics;
using System.Linq;
using HandyControl.Tools.Extension;
using LidarVDS.Resources.Values;

namespace LidarVDS.Maths;

public class GeometryOverlapFactor: AbstractAlgorithm<double,double>
{
    private static readonly GeometryOverlapFactor instance = new();
    private GeometryOverlapFactor() {}
    public static GeometryOverlapFactor Instance
    {
        get
        {
            return instance;
        }
    }

    public enum AlgTypeEnum
    {
        Theory,
        Fitting
    }
    [Obsolete("请使用 Accept ( double , AlgTypeEnum ) 方法代替该方法")]
    public override double Accept(double x)
    {
        return Accept(x, AlgTypeEnum.Theory);
    }

    public double Accept(double x, AlgTypeEnum algType)
    {
        var result = 0.0;
        switch (algType)
        {
            case AlgTypeEnum.Theory:
                result = Accept_Theory(x);
                break;
            case AlgTypeEnum.Fitting:
                result = Accept_Fitting(x);
                break;
        }

        if (result.IsNaN()) result = 0.0;
        return result;
    }

    private double Accept_Theory(double x)
    {
        var dt = LidarArgumentsRepository.GetInstance().GetArguments(LidarArgumentNameEnum.DiameterEmitLight).NowValue;
        var dr = LidarArgumentsRepository.GetInstance().GetArguments(LidarArgumentNameEnum.DiameterReceiveLight).NowValue;
        var thetaT = LidarArgumentsRepository.GetInstance().GetArguments(LidarArgumentNameEnum.AngleEmitLight).NowValue;
        var thetaR = LidarArgumentsRepository.GetInstance().GetArguments(LidarArgumentNameEnum.AngleReceiveLight).NowValue;
        var trDistance = LidarArgumentsRepository.GetInstance().GetArguments(LidarArgumentNameEnum.DistanceBetween).NowValue;
        
        var d1R = dt / 2 + thetaT * x;
        var d1R2 = dt / 2 + thetaT * x * x;
        var d2R = dr / 2 + thetaR * x;
        var d2R2 = dt / 2 + thetaR * x * x;
        var temp1 = (float)((trDistance * trDistance + d1R * d1R - d2R * d2R) / (2 * d1R * trDistance));
        if (temp1 > 1) temp1 = (float.MaxValue - 1) / float.MaxValue;
        if(temp1 < -1) temp1 = -(float.MaxValue - 1) / float.MaxValue;
        var a1R = 2 * MathF.Acos(temp1);
        var temp2 = (float)((trDistance * trDistance + d2R * d2R - d1R * d1R) / (2 * d2R * trDistance));
        if (temp2 > 1) temp2 = (float.MaxValue - 1) / float.MaxValue;
        if(temp2 < -1) temp2 = -(float.MaxValue - 1) / float.MaxValue;
        var a2R = 2 * MathF.Acos(temp2);
        var result = (d2R2 * (a2R - MathF.Sin(a2R)) + d1R2 * (a1R - MathF.Sin(a1R))) /
                     (2 * Math.PI * d1R2);
        return result;
    }

    /**
     * 执行该方法前务必刷新拟合参数
     */
    private double Accept_Fitting(double x)
    {
        var pr = EchoParticleGenerator.Instance.Pr_Calculate(x);
        var cBeta = Math.Pow(Math.E,_fitB);
        var result = (pr * x * x) / (cBeta * Math.Pow(Math.E, _fitA * x));
        return result;
    }

    /**
     * 根据给定的曲线，刷新最小二乘法拟合参数
     * x 距离
     * y 回波粒子数 Ns(r)
     */
    public void Update_Fitting_Arguments(double[] xValues,double[] yValues)
    {
        double xSum = xValues.Sum();
        double ySum = yValues.Sum();
        double xxSum = xValues.Select(x => x * x).Sum();
        double xySum = xValues.Zip(yValues, (x, y) => x * y).Sum();

        double count = xValues.Length;

        // 根据最小二乘法公式计算 a 和 b
        _fitA = (count * xySum - xSum * ySum) / (count * xxSum - xSum * xSum);
        _fitB = (ySum - _fitA * xSum) / count;
        
        Debug.WriteLine("fit_a => "+_fitA);
        Debug.WriteLine("fit_b => "+_fitB);
    }

    private double _fitA = 0;
    private double _fitB = 0;
}