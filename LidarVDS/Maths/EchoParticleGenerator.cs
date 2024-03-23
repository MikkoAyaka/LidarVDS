using System;
using System.Diagnostics;
using Microsoft.Research.DynamicDataDisplay;

namespace LidarVDS.Maths;

public class EchoParticleGenerator: AbstractAlgorithm<double,double>
{ 
 private static readonly EchoParticleGenerator instance = new();
    private EchoParticleGenerator() {}
    public static EchoParticleGenerator Instance
    {
        get
        {
            return instance;
        }
    }

    public double Pr_Calculate(double x)
    {
     Double yr = GeometryOverlapFactor.Instance.Accept(x,GeometryOverlapFactor.AlgTypeEnum.Theory);
     var ta = Math.Exp(-3.912 * x / _viewDistance);
     var pr = _p0 * (C * _t / 2) * (_ar / (x * x)) * yr * _scatteringValue * ta * ta * _tt * _tr;
     return pr;
    }
    public override double Accept(double x)
    {
     var pr = Pr_Calculate(x);
     var nsr = ((_eta * _lambda) / (H * C)) * pr * _t;
     var result = nsr;
     if (result.IsNaN()) result = 0;
     if(result.IsInfinite()) result = Double.MinValue;
     return result;
    }
    

    private double _viewDistance = 7000;
    private double _scatteringValue = 0.0005;
    /**
     * 激光功率(瓦)
     */
    private double _p0 = 0.11;

    /**
     * 光速(米/秒)
     */
    private const double C = 299792458;

    /**
     * 脉冲宽度(秒)
     */
    private double _t = 0.00000005;

    /**
     * 接收望远镜面积(平方米)
     */
    private double _ar = Math.PI * 0.05 * 0.05;

    /**
     * 存疑 发射望远镜透过率(0.0~1.0)
     */
    private double _tt = 1.0;

    /**
     * 接收望远镜透过率(0.0~1.0)
     */
    private double _tr = 0.5;

    /**
     * 量子效率(0.0~1.0)
     */
    private double _eta = 0.38;

    /**
     * 波长(m)
     */
    private double _lambda = 905 * Math.Pow(10, -9);

    /**
     * 普朗克常数
     */
    private static readonly double H = 6.62607015 * Math.Pow(10, -34);
}