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
        var l1 = GetL1(_trDistance, _thetaT, _thetaR);
        var l2 = GetL2(_trDistance, _thetaT, _thetaR);
        // if (x <= l1)
        // {
        //     return 0;
        // } 
        // if (x >= l2)
        // {
        //     return 1;
        // }
        var D1R = _dt / 2 + _thetaT * x;
        var D1R2 = _dt / 2 + _thetaT * x * x;
        var D2R = _dr / 2 + _thetaR * x;
        var D2R2 = _dt / 2 + _thetaR * x * x;
        var temp1 = (float)((_trDistance * _trDistance + D1R * D1R - D2R * D2R) / (2 * D1R * _trDistance));
        if (temp1 > 1) temp1 = (float.MaxValue - 1) / float.MaxValue;
        if(temp1 < -1) temp1 = -(float.MaxValue - 1) / float.MaxValue;
        var a1R = 2 * MathF.Acos(temp1);
        var temp2 = (float)((_trDistance * _trDistance + D2R * D2R - D1R * D1R) / (2 * D2R * _trDistance));
        if (temp2 > 1) temp2 = (float.MaxValue - 1) / float.MaxValue;
        if(temp2 < -1) temp2 = -(float.MaxValue - 1) / float.MaxValue;
        var a2R = 2 * MathF.Acos(temp2);
        var result = (D2R2 * (a2R - MathF.Sin(a2R)) + D1R2 * (a1R - MathF.Sin(a1R))) /
                     (2 * Math.PI * D1R2);
        return result;
    }

    /**
     * 执行该方法前务必刷新拟合参数
     */
    private double Accept_Fitting(double x)
    {
        var pr = EchoParticleGenerator.Instance.Pr_Calculate(x);
        var cBeta = Math.Pow(Math.E,_fit_b);
        var result = (pr * x * x) / (cBeta * Math.Pow(Math.E, _fit_a * x));
        Debug.WriteLine("pr = "+pr);
        Debug.WriteLine("cBeta = "+cBeta);
        Debug.WriteLine("result = "+result);
        return result;
    }

    /**
     * 根据给定的曲线，刷新最小二乘法拟合参数
     */
    public void Update_Fitting_Arguments(double[] xValues,double[] yValues)
    {
        double xSum = xValues.Sum();
        double ySum = yValues.Sum();
        double xxSum = xValues.Select(x => x * x).Sum();
        double xySum = xValues.Zip(yValues, (x, y) => x * y).Sum();

        double count = xValues.Length;

        // 根据最小二乘法公式计算 a 和 b
        _fit_a = (count * xySum - xSum * ySum) / (count * xxSum - xSum * xSum);
        _fit_b = (ySum - _fit_a * xSum) / count;
    }
    private static double GetL1(double l, double thetaT, double thetaR)
    {
        return l / (Math.Tan(thetaR) + Math.Tan(thetaT));
    }

    private static double GetL2(double l, double thetaT, double thetaR)
    {
        return l / (Math.Tan(thetaR) - Math.Tan(thetaT));
    }

    private double _fit_a = 0;
    private double _fit_b = 0;
    /**
     * 发射光束直径
     */
    private double _dt = 62.5 * Math.Pow(10, -6);
    /**
     * 接收光束直径
     */
    private double _dr = 50 * Math.Pow(10, -3);
    private double _thetaT = 0.715 * Math.Pow(10, -3);

    private double _thetaR = 1.2 * Math.Pow(10, -3);

    private double _trDistance = 120 * Math.Pow(10, -3);
}