using System;
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
    public override double Accept(double x)
    {
     var l1 = GetL1(_trDistance, _thetaT, _thetaR);
     var l2 = GetL2(_trDistance, _thetaT, _thetaR);
     Double yr;
     if (x <= l1)
     {
      yr = 0;
     }
     else if (x >= l2 * 0.9)
     {
      yr = 1;
     }
     else
     {
      yr = YrAlg(x);
     }
     var ta = Math.Exp(-3.912 * x / _viewDistance);
     var pr = _p0 * (C * _t / 2) * (_ar / (x * x)) * yr * _scatteringValue * ta * ta * _tt * _tr;
     var nsr = ((_eta * _lambda) / (H * C)) * pr * _t;
     var result = nsr;
     if (result.IsNaN()) result = 0;
     if(result.IsInfinite()) result = Double.MinValue;
     return result;
    }
    private static double GetL1(double l, double thetaT, double thetaR)
    {
     return l / (Math.Tan(thetaR) + Math.Tan(thetaT));
    }

    private static double GetL2(double l, double thetaT, double thetaR)
    {
     return l / (Math.Tan(thetaR) - Math.Tan(thetaT));
    }
    // TODO
    private double YrAlg(double r)
    {
     var D1R = _dt / 2 + _thetaT * r;
     var D1R2 = _dt / 2 + _thetaT * r * r;
     var D2R = _dr / 2 + _thetaR * r;
     var D2R2 = _dt / 2 + _thetaR * r * r;
     var temp1 = (float)((_trDistance * _trDistance + D1R * D1R - D2R * D2R) / (2 * D1R * _trDistance));
     var a1R = 2 * MathF.Acos(temp1);
     var temp2 = (float)((_trDistance * _trDistance + D2R * D2R - D1R * D1R) / (2 * D2R * _trDistance));
     var a2R = 2 * MathF.Acos(temp2);
     var result = (D2R2 * (a2R - MathF.Sin(a2R)) + D1R2 * (a1R - MathF.Sin(a1R))) /
                     (2 * Math.PI * D1R2);
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
    private double _t = 0.0000001;

    /**
     * 接收望远镜面积(平方米)
     */
    private double _ar = Math.PI / 1600;

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

    /**
     * 发射光束直径
     */
    private double _dt = 62.5 * Math.Pow(10, -6);

    private double _thetaT = 0.715 * Math.Pow(10, -3);

    /**
     * 接收光束直径
     */
    private double _dr = 50 * Math.Pow(10, -3);

    private double _thetaR = 1.2 * Math.Pow(10, -3);

    private double _trDistance = 300 * Math.Pow(10, -3);
}